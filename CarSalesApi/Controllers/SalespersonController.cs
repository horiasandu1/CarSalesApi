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
        

        [HttpGet]
        [Route("SalespersonController/Salesperson")]
        //GET ALL THE SALESPERSON - Ariane
        public HttpResponseMessage GetSalespersons()
        {
            var salespersons = DBAccess.GetSalespersons();
            if (salepersons.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, salespersons);
            }

            return response;
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