using Loyalty.BackendAPI.Common;
using Loyalty.BackendAPI.Models.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Catalog.Collections
{
    public interface IManageCollectionService
    {
        Task<PageResult<CollectionViewModel>> GetAllPaging(GetManageCollectionPagingRequest request);

        Task<CollectionViewModel> GetById(int collectionID);

        Task<List<CollectionViewModel>> GetAll();

        Task<int> Create(CollectionCreateRequest request);

        Task<int> Update(CollectionUpdateRequest request, int collectionID);

        Task<int> Delete(int collectionID);
    }
}