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
    [Route("invoicement")]
    public class InvoicementController : ControllerBase
    {
        private readonly ILogger<InvoicementController> _logger;

        public InvoicementController(ILogger<InvoicementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<CoreInvoice> Get()
        {
            Invoicement ObjInvoicement = new Invoicement();
            return ObjInvoicement.GetInvoices().ToList();
        }

        [HttpPost]
        public ResponseApi Post([FromBody] Objects.InvoicementDataObject FormData)
        {
            Invoicement ObjInvoicement = new Invoicement();
            ObjInvoicement.CompanyId = Convert.ToInt32(FormData.CompanyId);
            ObjInvoicement.ClientId = Convert.ToInt32(FormData.ClientId);
            ObjInvoicement.Products = FormData.Products;
            ObjInvoicement.Total = Convert.ToInt32(FormData.Total);
            bool resultTransaction = ObjInvoicement.CreateInvoice();
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The Invoice was created!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }

    }
}
