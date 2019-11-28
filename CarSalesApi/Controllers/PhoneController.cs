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

        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("PhoneController/Phone")]
        //GET ALL THE PHONES - Ariane
        public HttpResponseMessage GetPhones()
        {
            var phones = db.GetPhones();
            return Request.CreateResponse(HttpStatusCode.OK, phones);
        }

        [HttpGet]
        [Route("PhoneController/Phone/id")]
        // GET SPECIFIC PHONE WITH ID - Hicham
        public HttpResponseMessage GetPhone(int id)
        {
            var phone = db.GetPhone(id);

            return Request.CreateResponse(HttpStatusCode.OK, phone);
        }
    }
}