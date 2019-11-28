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
        public HttpResponseMessage GetCustomers()
        {
            var customers = db.GetCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        [Route("CustomerController/Customer/id")]
        // GET SPECIFIC CUSTOMER WITH ID - Hicham
        public HttpResponseMessage GetCustomer(int id)
        {
            var customer = db.GetCustomer(id);

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

    }
}