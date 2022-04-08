using Loyalty.BackendAPI.Catalog.Stores;
using Loyalty.BackendAPI.Models.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IManageStoreService _manageStoreService;

        public StoreController(IManageStoreService manageStoreService)
        {
            _manageStoreService = manageStoreService;
        }

        [HttpGet("public-getAll")]
        public async Task<IActionResult> GetAll()
        {
            var stores = await _manageStoreService.GetAll();
            return Ok(stores);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageStorePagingRequest request)
        {
            var stores = await _manageStoreService.GetAllPaging(request);
            return Ok(stores);
        }

        [HttpGet("{storeID}")]
        public async Task<IActionResult> GetById(int storeID)
        {
            var stores = await _manageStoreService.GetById(storeID);
            if (stores == null)
                return BadRequest("Cannot find product");
            return Ok(stores);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] StoreCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storeID = await _manageStoreService.Create(request);
            if (storeID == 0)
                return BadRequest();
            var store = await _manageStoreService.GetById(storeID);

            return CreatedAtAction(nameof(GetById), new { id = storeID }, store);
        }

        [HttpPut("Update/{storeID}")]
        public async Task<IActionResult> Update([FromForm] StoreUpdateRequest request, int storeID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageStoreService.Update(request, storeID);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("Delete/{storeID}")]
        public async Task<IActionResult> Delete(int storeID)
        {
            var affectedResult = await _manageStoreService.Delete(storeID);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}