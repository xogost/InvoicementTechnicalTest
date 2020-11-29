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
    [Route("companies")]
    public class CompaniesContoller : ControllerBase
    {
        private readonly ILogger<CompaniesContoller> _logger;

        public CompaniesContoller(ILogger<CompaniesContoller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<CoreCompany> Get()
        {
            Companies ObjCompanies = new Companies();
            var DataCompanies = ObjCompanies.GetCompanies();
            return DataCompanies.ToList<CoreCompany>();
        }

        [HttpPost]
        public ResponseApi Post([FromBody] CoreCompany FormData)
        {
            bool resultTransaction = new Companies().AddCompany(FormData.Identification, FormData.Name);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The company was updated!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }
    }
}
