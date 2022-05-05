using ExampleApi.Dtos;
using ExampleApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers
{
    /// <summary>
    /// Ürünler için oluşturulmuş API endpointleri
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }

        /// <summary>
        /// Tüm ürünleri döner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllProducts()
        {
           return Ok(_productRepository.GetProducts());
        }

        /// <summary>
        /// Id'ye göre ürün getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Id")]
        public ActionResult GetProductById(int id)
        {
            return Ok(_productRepository.GetProductById(id));
        }

        /// <summary>
        /// Ürün ekler
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProduct(ProductDto product)
        {
            _productRepository.AddProduct(product);

            return Ok();
        }

        /// <summary>
        /// Ürün siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);

            return Ok();
        }

        /// <summary>
        /// Ürünü günceller
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult EditProduct(ProductDto product)
        {
            var result=_productRepository.EditProduct(product);

            return Ok(result);
        }

    }
}
