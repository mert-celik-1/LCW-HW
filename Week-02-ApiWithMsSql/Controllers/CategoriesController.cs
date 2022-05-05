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
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm kategorileri döner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Categories()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            var viewModel = _mapper.Map<List<CategoryViewModel>>(categories);

            return Ok(viewModel);
        }

        /// <summary>
        /// Id ye göre kategori döner
        /// </summary>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> Category(string id)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == id);

            var viewModel = _mapper.Map<CategoryViewModel>(category);

            return Ok(viewModel);
        }

        /// <summary>
        /// Toplam kategori sayisini doner
        /// </summary>
        /// <returns></returns>
        [HttpGet("Count")]
        public async Task<ActionResult> Count()
        {
            var count = await _unitOfWork.Categories.CountAsync();

            return Ok(count);
        }


        /// <summary>
        /// Kategoriler icinden arama yapar
        /// </summary>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<ActionResult> Search([FromQuery] SearchQuery searchQuery)
        {
            var searchResult = new List<Category>();

            if (!string.IsNullOrEmpty(searchQuery.Name))
            {
                searchResult = (List<Category>)await _unitOfWork.Categories.Search(x => x.Name == searchQuery.Name);
            }

            if (!string.IsNullOrEmpty(searchQuery.Description))
            {
                searchResult = (List<Category>)await _unitOfWork.Categories.Search(x => x.Description == searchQuery.Description);
            }

            var viewModel = _mapper.Map<List<CategoryViewModel>>(searchResult);

            return Ok(viewModel);
        }

        /// <summary>
        /// Kategori ekler
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);

            category.Id = Guid.NewGuid().ToString();

            await _unitOfWork.Categories.AddAsync(category);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        /// <summary>
        /// Kategori siler
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(string id)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == id);

            await _unitOfWork.Categories.DeleteAsync(category);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        /// <summary>
        /// Kategori gunceller
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Edit(UpdateCategoryViewModel categoryVM)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryVM.Id);

            category.Name = categoryVM.Name;
            category.Description = categoryVM.Description;


            var newCategory = await _unitOfWork.Categories.UpdateAsync(category);

            await _unitOfWork.CommitAsync();

            return Ok(newCategory);
        }
    }
}
