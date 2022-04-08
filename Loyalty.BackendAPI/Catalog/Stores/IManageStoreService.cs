using Loyalty.BackendAPI.Catalog.Collections;
using Loyalty.BackendAPI.Common;
using Loyalty.BackendAPI.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Stores
{
    public interface IManageStoreService
    {
        Task<PageResult<StoreViewModel>> GetAllPaging(GetManageStorePagingRequest request);

        Task<StoreViewModel> GetById(int storeID);

        Task<List<StoreViewModel>> GetAll();

        Task<int> Create(StoreCreateRequest request);

        Task<int> Update(StoreUpdateRequest request, int storeID);

        Task<int> Delete(int storeID);
    }
}