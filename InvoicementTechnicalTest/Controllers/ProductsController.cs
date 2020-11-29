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
    [Route("company/{companyId}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<CoreProduct> Get(int companyId)
        {
            Products ObjProducts = new Products();
            var DataProducts = ObjProducts.GetProductsByCompany(companyId);
            return DataProducts.ToList<CoreProduct>();
        }

        [HttpPost]
        public ResponseApi Post(int companyId, [FromBody] CoreProduct FormData)
        {
            bool resultTransaction = new Products().AddProduct(companyId, FormData.Name, (int)FormData.Cost, FormData.Reference, (int)FormData.Quantity);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The product was created!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }
    }
}
