using Loyalty.BackendAPI.Catalog.Collections;
using Loyalty.BackendAPI.Common;
using Loyalty.BackendAPI.Exceptions;
using Loyalty.BackendAPI.Models.EF;
using Loyalty.BackendAPI.Models.Entities;
using Loyalty.BackendAPI.Models.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Stores
{
    public class ManageStoreService : IManageStoreService
    {
        private readonly LoyaltyDBContext _loyalty;

        public ManageStoreService(LoyaltyDBContext loyalty)
        {
            _loyalty = loyalty;
        }

        public async Task<int> Create(StoreCreateRequest request)
        {
            var store = new Store()
            {
                storeName = request.storeName,
                Email = request.Email,
                phoneNumber = request.phoneNumber,
                Country = request.Country,
                City = request.City,
                District = request.District,
                Ward = request.Ward,
                Address = request.Address,
            };

            _loyalty.Store.Add(store);
            await _loyalty.SaveChangesAsync();
            return store.storeID;
        }

        public async Task<int> Update(StoreUpdateRequest request, int storeID)
        {
            var store = await _loyalty.Store.FindAsync(storeID);

            if (store == null) throw new loyaltyException($"Can't find a collection: {storeID}");

            store.storeName = request.storeName;
            store.Email = request.Email;
            store.phoneNumber = request.phoneNumber;
            store.Country = request.Country;
            store.City = request.City;
            store.District = request.District;
            store.Ward = request.Ward;
            store.Address = request.Address;

            return await _loyalty.SaveChangesAsync();
        }

        public async Task<int> Delete(int storeID)
        {
            var store = await _loyalty.Store.FindAsync(storeID);
            if (store == null) throw new loyaltyException($"Can't find a collection: {storeID}");

            _loyalty.Store.Remove(store);
            return await _loyalty.SaveChangesAsync();
        }

        public async Task<List<StoreViewModel>> GetAll()
        {
            var query = from s in _loyalty.Store
                            //join cp in _loyalty.Campaign on s.storeID equals cp.storeID
                        select new { s };
            var data = await query
                       .Select(x => new StoreViewModel()
                       {
                           storeID = x.s.storeID,
                           storeName = x.s.storeName,
                           Email = x.s.Email,
                           phoneNumber = x.s.phoneNumber,
                           Country = x.s.Country,
                           City = x.s.City,
                           District = x.s.District,
                           Ward = x.s.Ward,
                           Address = x.s.Address
                       }).ToListAsync();
            return data;
        }

        public async Task<PageResult<StoreViewModel>> GetAllPaging(GetManageStorePagingRequest request)
        {
            //Select by join
            var query = from s in _loyalty.Store
                        join cp in _loyalty.Campaign on s.storeID equals cp.storeID
                        select new { s, cp };

            //Filter
            if (!string.IsNullOrEmpty(request.Country) &&
                !string.IsNullOrEmpty(request.City) &&
                !string.IsNullOrEmpty(request.District) &&
                !string.IsNullOrEmpty(request.Ward))
            {
                query = query.Where(x => x.cp.storeID == x.s.storeID &&
                                        x.s.Country.Contains(request.Country) &&
                                        x.s.City.Contains(request.City) &&
                                        x.s.District.Contains(request.District) &&
                                        x.s.Ward.Contains(request.Ward)
                                        );
            }
            //Paging
            int totalRow = await query.CountAsync();
            var data = await query
                       .Select(x => new StoreViewModel()
                       {
                           storeID = x.s.storeID,
                           storeName = x.s.storeName,
                           Email = x.s.Email,
                           phoneNumber = x.s.phoneNumber,
                           Country = x.s.Country,
                           City = x.s.City,
                           District = x.s.District,
                           Ward = x.s.Ward,
                           Address = x.s.Address
                       }).ToListAsync();

            //Select
            var pageResult = new PageResult<StoreViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pageResult;
        }

        public async Task<StoreViewModel> GetById(int storeID)
        {
            var store = await _loyalty.Store.FindAsync(storeID);

            var storeViewmodel = new StoreViewModel()
            {
                storeID = store.storeID,
                storeName = store.storeName,
                Email = store.Email,
                phoneNumber = store.phoneNumber,
                Country = store.Country,
                City = store.City,
                District = store.District,
                Ward = store.Ward,
                Address = store.Address
            };

            return storeViewmodel;
        }
    }
}