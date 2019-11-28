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
        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("CustomerPhoneController/CustomerPhone")]
        // GET ALL THE CUSTOMERPHONES - Ariane
        public HttpResponseMessage GetCustomerPhones()
        {
            var customerPhones = db.GetCustomerPhones();
            return Request.CreateResponse(HttpStatusCode.OK, customerPhones);
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