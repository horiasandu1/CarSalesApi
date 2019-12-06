using CarApiClasses;
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
        [Route("api/Salesperson")]
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
                response = Request.CreateResponse(HttpStatusCode.OK, salespersonsApi);
            }

            return response;
        }

        [HttpGet]
        [Route("api/Salesperson/{id}")]
        // GET SPECIFIC SALESPERSON WITH ID - Hicham
        public HttpResponseMessage GetSalesperson(int id)
        {
            HttpResponseMessage response;
            var salesperson = DBAccess.GetSalesperson(id);

            if (salesperson == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No salesperson were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, salesperson);
            }

            return response;
        }
        [HttpDelete]
        [Route("api/Salesperson/{id}")]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                // Persist our change.
                DBAccess.DeleteSalesperson(id);

            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured, Cannot delete current record !");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/Salesperson")]
        public HttpResponseMessage PostSalesperson([FromBody]ApiSalesperson sp)
        {
            try
            {
                DBAccess.PostSalesPerson(sp);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create record.");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/Salesperson/{id}")]
        public HttpResponseMessage PutSalesperson(int id, [FromBody]ApiSalesperson asp)
        {
            try
            {
                // Persist our change.
                DBAccess.PutSalesperson(id, asp);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot update record: " + e);
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}