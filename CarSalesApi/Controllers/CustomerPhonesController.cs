using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CarSalesApi.Controllers
{
    public class CustomerPhonesController : ApiController
    {
        

        [HttpGet]
        [Route("CustomerPhoneController/CustomerPhone")]
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
        [Route("CustomerPhoneController/CustomerPhone/id")]
        // GET SPECIFIC CUSTOMERPHONES WITH ID - Hicham
        public HttpResponseMessage GetCustomerPhone(int id)
        {
            var customerPhone = db.GetCustomerPhone(id);

            return Request.CreateResponse(HttpStatusCode.OK, customerPhone);
        }

    }
}