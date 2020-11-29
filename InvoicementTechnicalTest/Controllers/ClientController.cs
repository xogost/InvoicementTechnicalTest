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
    [Route("client/{id}")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public CoreClient Get(int id)
        {
            Clients ObjClients = new Clients();
            CoreClient ObjCoreClient= ObjClients.GetClient(id);
            return ObjCoreClient;
        }

        [HttpPut]
        public ResponseApi Put(int id, [FromBody] CoreClient FormData)
        {
            bool resultTransaction = new Clients().UpdateClient(id, FormData.Name, FormData.Age);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The Client was update!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }

        [HttpDelete]
        public ResponseApi Delete(int id)
        {
            bool resultTransaction = new Clients().DeleteClient(id);
            ResponseApi ObjResponseApi = new ResponseApi();
            ObjResponseApi.Result = resultTransaction;
            if (resultTransaction)
                ObjResponseApi.Message = "The Client was removed!";
            else
                ObjResponseApi.Message = "Error, try again.";
            return ObjResponseApi;
        }
    }
}
