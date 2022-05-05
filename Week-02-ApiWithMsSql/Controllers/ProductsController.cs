using ApiWithMsSql.Entities;
using ApiWithMsSql.Repositories.Abstract;
using ApiWithMsSql.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithMsSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm ürünleri döner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Products()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            var viewModel = _mapper.Map<List<ProductViewModel>>(products);
           
            return Ok(viewModel);
        }

        /// <summary>
        /// Kategorilere gore tüm ürünleri döner
        /// </summary>
        /// <returns></returns>
        [HttpGet("ByCategoryId")]
        public async Task<ActionResult> ProductsByCategoryId(string categoryId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(x=>x.CategoryId==categoryId);

            var viewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(viewModel);
        }

        /// <summary>
        /// Id ye göre ürün döner
        /// </summary>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> Product(string id)
        {
            var product = await _unitOfWork.Products.GetAsync(x=>x.Id==id);

            var viewModel = _mapper.Map<ProductViewModel>(product);

            return Ok(viewModel);
        }

        /// <summary>
        /// Toplam urun sayisini doner
        /// </summary>
        /// <returns></returns>
        [HttpGet("Count")]
        public async Task<ActionResult> Count()
        {
            var count = await _unitOfWork.Products.CountAsync();

            return Ok(count);
        }


        /// <summary>
        /// Urunler icinden arama yapar
        /// </summary>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery]SearchQuery searchQuery)
        {
            var searchResult = new List<Product>();

            if (!string.IsNullOrEmpty(searchQuery.Name))
            {
                searchResult = (List<Product>)await _unitOfWork.Products.Search(x => x.Name == searchQuery.Name);
            }

            if (!string.IsNullOrEmpty(searchQuery.Description))
            {
                searchResult = (List<Product>)await _unitOfWork.Products.Search(x => x.Description == searchQuery.Description);
            }

            var viewModel = _mapper.Map<List<ProductViewModel>>(searchResult);

            return Ok(viewModel);
        }

        /// <summary>
        /// Ürün ekler
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            product.Id = Guid.NewGuid().ToString();

            await _unitOfWork.Products.AddAsync(product);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        /// <summary>
        /// Ürün siler
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(string id)
        {
            var product = await _unitOfWork.Products.GetAsync(x=>x.Id==id);

            await _unitOfWork.Products.DeleteAsync(product);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        /// <summary>
        /// Ürün gunceller
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Edit(UpdateProductViewModel productVM)
        {
            var product = await _unitOfWork.Products.GetAsync(x => x.Id == productVM.Id);

            product.Name = productVM.Name;
            product.Description = productVM.Description;
            product.Price = productVM.Price;
            product.Quantity = productVM.Quantity;
            product.CategoryId = productVM.CategoryId;

            var newProduct = await _unitOfWork.Products.UpdateAsync(product);

            await _unitOfWork.CommitAsync();

            return Ok(newProduct);
        }

    }
}
