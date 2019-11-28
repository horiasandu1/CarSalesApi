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

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("SalespersonController/Salesperson")]
        //GET ALL THE SALESPERSON - Ariane
        public HttpResponseMessage GetSalespersons()
        {
            HttpResponseMessage response;
            var salespersonsApi = DBAccess.GetSalespersons();
            if (salespersonsApi.Count == 0)
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
        public HttpResponseMessage Delete(int id)
        {
            Salesperson c = db.Salespersons.Find(id);

            if (c == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.Salespersons.Remove(c);

            try
            {
                // Persist our change.
                db.SaveChanges();
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured, Cannot delete current record !");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}