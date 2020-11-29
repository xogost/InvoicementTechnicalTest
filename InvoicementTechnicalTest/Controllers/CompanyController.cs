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
    [Route("company/{id}")]
    public class CompanyContoller : ControllerBase
    {
        private readonly ILogger<CompanyContoller> _logger;

        public CompanyContoller(ILogger<CompanyContoller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public CoreCompany Get(int id)
        {
            Companies ObjCompanies = new Companies();
            CoreCompany ObjCoreCompany = ObjCompanies.GetCompany(id);
            return ObjCoreCompany;
        }

        [HttpPut]
        public ResponseApi Put(int id, [FromBody] CoreCompany FormData)
        {
            bool resultTransaction = new Companies().UpdateCompany(id, FormData.Identification, FormData.Name);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The company was updated!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }

        [HttpDelete]
        public ResponseApi Delete(int id)
        {
            bool resultTransaction = new Companies().DeleteCompany(id);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The company was removed!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }
    }
}
