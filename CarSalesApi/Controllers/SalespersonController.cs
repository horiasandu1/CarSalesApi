using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class SalespersonController : ApiController
    {
        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("SalespersonController/Salesperson")]
        //GET ALL THE SALESPERSON - Ariane
        public HttpResponseMessage GetSalespersons()
        {
            var salespersons = db.GetSalespersons();
            return Request.CreateResponse(HttpStatusCode.OK, salespersons);
        }

        [HttpGet]
        [Route("SalespersonController/Saleperson")]
        // GET SPECIFIC SALESPERSON WITH ID - Hicham
        public HttpResponseMessage GetSalesperson(int id)
        {
            var salesperson = db.GetSalesperson(id);

            return Request.CreateResponse(HttpStatusCode.OK, salesperson);
        }

    }
}