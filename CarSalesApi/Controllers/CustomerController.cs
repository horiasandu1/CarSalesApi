using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class CustomerController : ApiController
    {
        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("CustomerController/Customer")]
        //GET ALL THE CUSTOMER - Ariane
        public HttpResponseMessage GetAllCustomers()
        {
            var customers = db.GetAllCustomer();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        [Route("CustomerController/Customer/id")]
        // GET SPECIFIC CUSTOMER WITH ID - Hicham
        public HttpResponseMessage GetCustomerId(int id)
        {
            var customer = db.GetCustomerId(id);

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

    }
}