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
            var customerPhone = db.GetCustomerPhone(id);

            return Request.CreateResponse(HttpStatusCode.OK, customerPhone);
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

    }
}