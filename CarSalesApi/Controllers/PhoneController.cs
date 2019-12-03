using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class PhoneController : ApiController
    {

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("api/Phone")]
        //GET ALL THE PHONES - Ariane
        public HttpResponseMessage GetPhones()
        {
            HttpResponseMessage response;
            var phones = DBAccess.GetPhones();
            if (phones.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, phones);
            }

            return response;
        }

        [HttpGet]
        [Route("api/Phone/{id}")]
        // GET SPECIFIC PHONE WITH ID - Hicham
        public HttpResponseMessage GetPhone(int id)
        {
            HttpResponseMessage response;
            var phone = DBAccess.GetPhone(id);

            if (phone == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No phones were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, phone);
            }

            return response;
        }

        [HttpDelete]
        [Route("api/Phone/{id}")]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                // Persist our change.
                DBAccess.DeletePhone(id);

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