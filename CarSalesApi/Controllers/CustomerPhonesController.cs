using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarApiClasses;

namespace CarSalesApi.Controllers
{
    public class CustomerPhonesController : ApiController
    {

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("api/CustomerPhone")]
        // GET ALL THE CUSTOMERPHONES - Ariane
        public HttpResponseMessage GetCustomerPhones()
        {
            HttpResponseMessage response;
            var customerPhonesApi = DBAccess.GetCustomerPhones();
            if (customerPhonesApi.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customerPhonesApi);
            }

            return response;
        }

        [HttpGet]
        [Route("api/CustomerPhone/{id}")]
        // GET SPECIFIC CUSTOMERPHONES WITH ID - Hicham
        public HttpResponseMessage GetCustomerPhone(int id)
        {
            HttpResponseMessage response;
            var customerPhone = DBAccess.GetCustomerPhone(id);

            if (customerPhone == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No customer phones were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customerPhone);
            }

            return response;
        }

        [HttpDelete]
        [Route("api/CustomerPhone/{id}")]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                // Persist our change.
                DBAccess.DeleteCustomerPhone(id);

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
        [Route("api/CustomerPhones")]
        public HttpResponseMessage PostCustomerPhones([FromBody]ApiCustomerPhone cp)
        {
            try
            {
                DBAccess.PostCustomerPhone(cp);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create record.");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}