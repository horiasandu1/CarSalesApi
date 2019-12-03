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
        public HttpResponseMessage Delete(int id)
        {
            Customer_Phone c = db.Customer_Phone.Find(id);

            if (c == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.Customer_Phone.Remove(c);

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