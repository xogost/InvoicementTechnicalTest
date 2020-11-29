using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoicementTechnicalBusiness;
using InvoicementTechincalData.Database;
using Microsoft.AspNetCore.Cors;
using InvoicementTechnicalTest.Objects;

namespace InvoicementTechnicalTest.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("product/{id}")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public CoreProduct Get(int id)
        {
            Products ObjProducts = new Products();
            CoreProduct ObjCoreProduct = ObjProducts.GetProduct(id);
            return ObjCoreProduct;
        }

        [HttpPut]
        public ResponseApi Put(int id, [FromBody] CoreProduct FormData)
        {
            bool resultTransaction = new Products().UpdateProduct(FormData.Id, FormData.Name, (int)FormData.Cost, FormData.Reference, (int)FormData.Quantity);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The product was updated!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }

        [HttpDelete]
        public ResponseApi Delete(int id)
        {
            bool resultTransaction =  new Products().DeleteProduct(id);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The Product was removed!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }
    }
}
