using Loyalty.BackendAPI.Common;
using Loyalty.BackendAPI.Exceptions;
using Loyalty.BackendAPI.Models.Collections;
using Loyalty.BackendAPI.Models.EF;
using Loyalty.BackendAPI.Models.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Collections
{
    public class ManageCollectionService : IManageCollectionService
    {
        private readonly LoyaltyDBContext _loyalty;

        public ManageCollectionService(LoyaltyDBContext loyalty)
        {
            _loyalty = loyalty;
        }

        public async Task<int> Create(CollectionCreateRequest request)
        {
            var collection = new Collection()
            {
                collectionName = request.collectionName,
                typeCollection = request.typeCollection,
                productID = request.productID,
                campaignID = request.campaignID
            };

            _loyalty.Collection.Add(collection);
            await _loyalty.SaveChangesAsync();
            return collection.collectionID;
        }

        public async Task<int> Delete(int collectionID)
        {
            var collection = await _loyalty.Collection.FindAsync(collectionID);
            if (collection == null) throw new loyaltyException($"Can't find a collection: {collectionID}");

            _loyalty.Collection.Remove(collection);
            return await _loyalty.SaveChangesAsync();
        }

        public async Task<int> Update(CollectionUpdateRequest request, int collectionID)
        {
            var collection = await _loyalty.Collection.FindAsync(collectionID);

            if (collection == null) throw new loyaltyException($"Can't find a collection: {collectionID}");

            collection.collectionName = request.collectionName;
            collection.typeCollection = request.typeCollection;
            collection.productID = request.productID;
            collection.campaignID = request.campaignID;

            return await _loyalty.SaveChangesAsync();
        }

        public async Task<PageResult<CollectionViewModel>> GetAllPaging(GetManageCollectionPagingRequest request)
        {
            //Select by join
            var query = from c in _loyalty.Collection
                        join p in _loyalty.Product on c.productID equals p.productID
                        join ca in _loyalty.Campaign on c.campaignID equals ca.campaignID
                        select new { c, p, ca };

            //Filter
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.ca.campaignName.Contains(request.keyword));
            }
            //Paging
            int totalRow = await query.CountAsync();
            var countProduct = (from c in _loyalty.Product select c.productID).Count();
            var data = await query
                       .Select(x => new CollectionViewModel()
                       {
                           collectionID = x.c.collectionID,
                           typeCollection = x.c.typeCollection,
                           productID = x.c.productID,
                           collectionName = x.c.collectionName,
                           campaignID = x.c.campaignID,
                           campaignName = x.ca.campaignName,
                           stock = x.p.oldStock,
                           totalProduct = countProduct
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
            var collection = await _loyalty.Collection.FindAsync(collectionID);

            var collectionViewmodel = new CollectionViewModel()
            {
                campaignName = collection.collectionName,
                typeCollection = collection.typeCollection,
                productID = collection.productID,
                campaignID = collection.campaignID
            };

            return collectionViewmodel;
        }

        public async Task<List<CollectionViewModel>> GetAll()
        {
            var query = from c in _loyalty.Collection
                        join p in _loyalty.Product on c.productID equals p.productID
                        join ca in _loyalty.Campaign on c.campaignID equals ca.campaignID
                        select new { c, p, ca };
            var countProduct = (from c in _loyalty.Product select c.productID).Count();
            var data = await query
                       .Select(x => new CollectionViewModel()
                       {
                           collectionID = x.c.collectionID,
                           typeCollection = x.c.typeCollection,
                           productID = x.c.productID,
                           collectionName = x.c.collectionName,
                           campaignID = x.c.campaignID,
                           campaignName = x.ca.campaignName,
                           stock = x.p.oldStock,
                           totalProduct = countProduct
                       }).ToListAsync();
            return data;
        }
    }
}