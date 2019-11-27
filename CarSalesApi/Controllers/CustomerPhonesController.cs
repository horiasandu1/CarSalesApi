using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CarSalesApi.Controllers
{
    public class CustomerPhonesController
    {
        DBAccess db = new DBAccess();

        // GET ALL THE CUSTOMERPHONES - Ariane
        public HttpResponseMessage GetAllCustomerPhones()
        {
            var customerPhones = db.GetAllCustomerPhones();
            return Request.CreateResponse(HttpStatusCode.OK, customerPhones);
        }

        // GET SPECIFIC CUSTOMERPHONES WITH ID - Hicham
        public HttpResponseMessage GetCustomerPhonesId(int id)
        {
            var customerPhone = db.GetCustomerPhone(id);

            return Request.CreateResponse(HttpStatusCode.OK, customerPhone);
        }

    }
}