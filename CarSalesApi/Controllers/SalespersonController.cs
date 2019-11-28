using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class SalespersonController
    {
        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("SalespersonController/Salesperson")]
        //GET ALL THE SALESPERSON - Ariane
        public HttpResponseMessage GetAllSalesperson()
        {
            var salepersons = db.GetAllSalesperson();
            return Request.CreateResponse(HttpStatusCode.OK, salespersons);
        }

        [HttpGet]
        [Route("SalespersonController/Saleperson")]
        // GET SPECIFIC SALESPERSON WITH ID - Hicham
        public HttpResponseMessage GetSalespersonId(int id)
        {
            var salesperson = db.GetSalespersonId(id);

            return Request.CreateResponse(HttpStatusCode.OK, salesperson);
        }

    }
}