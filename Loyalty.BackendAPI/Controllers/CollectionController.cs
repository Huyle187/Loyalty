using Loyalty.BackendAPI.Catalog.Collections;
using Loyalty.BackendAPI.Models.Collections;
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
    public class CollectionController : ControllerBase
    {
        private readonly IManageCollectionService _manageCollectionService;

        public CollectionController(IManageCollectionService manageCollectionService)
        {
            _manageCollectionService = manageCollectionService;
        }

        [HttpGet("public-getAll")]
        public async Task<IActionResult> GetAll()
        {
            var collections = await _manageCollectionService.GetAll();
            return Ok(collections);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageCollectionPagingRequest request)
        {
            var collections = await _manageCollectionService.GetAllPaging(request);
            return Ok(collections);
        }

        [HttpGet("{collectionId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _manageCollectionService.GetById(productId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CollectionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var collectionId = await _manageCollectionService.Create(request);
            if (collectionId == 0)
                return BadRequest();
            var product = await _manageCollectionService.GetById(collectionId);

            return CreatedAtAction(nameof(GetById), new { id = collectionId }, product);
        }

        [HttpPut("{collectionId}")]
        public async Task<IActionResult> Update([FromForm] CollectionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageCollectionService.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{collectionId}")]
        public async Task<IActionResult> Delete(int collectionId)
        {
            var affectedResult = await _manageCollectionService.Delete(collectionId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}