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
    [Route("company/{companyId}/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<CoreClient> Get(int companyId)
        {
            Clients ObjClients = new Clients();
            var DataClients = ObjClients.GetClientsByCompany(companyId);
            return DataClients.ToList<CoreClient>();
        }

        [HttpPost]
        public ResponseApi Post(int companyId, [FromBody] CoreClient FormData)
        {
            bool resultTransaction = new Clients().AddClient(FormData.Name, FormData.Age, companyId);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The Client was created!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }
    }
}
