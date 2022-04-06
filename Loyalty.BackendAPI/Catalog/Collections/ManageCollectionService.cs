using Loyalty.BackendAPI.Common;
using Loyalty.BackendAPI.Exceptions;
using Loyalty.BackendAPI.Models.Collections;
using Loyalty.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Collections
{
    public class ManageCollectionService : IManageCollectionService
    {
        private readonly LoyaltyEntities _loyalty;

        public ManageCollectionService(LoyaltyEntities loyalty)
        {
            _loyalty = loyalty;
        }

        public async Task<int> Create(CollectionRequest request)
        {
            var collection = new Collection()
            {
                collectionName = request.collectionName,
                typeCollection = request.typeCollection,
                productID = request.productID,
                campaignID = request.campaignID
            };

            _loyalty.Collections.Add(collection);
            await _loyalty.SaveChangesAsync();
            return collection.collectionID;
        }

        public async Task<int> Delete(int collectionID)
        {
            var collection = await _loyalty.Collections.FindAsync(collectionID);
            if (collection == null) throw new loyaltyException($"Can't find a collection: {collectionID}");

            _loyalty.Collections.Remove(collection);
            return await _loyalty.SaveChangesAsync();
        }

        public async Task<int> Update(CollectionRequest request)
        {
            var collection = await _loyalty.Collections.FindAsync(request.collectionID);

            if (collection == null) throw new loyaltyException($"Can't find a collection: {request.collectionID}");

            collection.collectionName = request.collectionName;
            collection.typeCollection = request.typeCollection;
            collection.productID = request.productID;
            collection.campaignID = request.campaignID;

            return await _loyalty.SaveChangesAsync();
        }

        public async Task<PageResult<CollectionViewModel>> GetAllPaging(GetManageCollectionPagingRequest request)
        {
            //Select by join
            var query = from c in _loyalty.Collections
                        join p in _loyalty.Products on c.productID equals p.productID
                        join ca in _loyalty.Campaigns on c.campaignID equals ca.campaignID
                        select new { c, p, ca };

            //Filter
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.ca.campaignName.Contains(request.keyword));
            }
            //Paging
            int totalRow = await query.CountAsync();
            int total = query.Sum(x => x.p.productID);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .Select(x => new CollectionViewModel()
                                   {
                                       collectionName = x.c.collectionName,
                                       campaignName = x.ca.campaignName,
                                       stock = x.p.oldStock,
                                   }).ToListAsync();

            //Select
            var pageResult = new PageResult<CollectionViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pageResult;
        }

        public async Task<CollectionViewModel> GetById(int collectionID)
        {
            var collection = await _loyalty.Collections.FindAsync(collectionID);

            var collectionViewmodel = new CollectionViewModel()
            {
                campaignName = collection.collectionName,
                typeCollection = collection.typeCollection,
                productID = collection.productID,
                campaignID = collection.campaignID
            };

            return collectionViewmodel;
        }
    }
}