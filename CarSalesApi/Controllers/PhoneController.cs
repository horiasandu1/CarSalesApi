using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class PhonesController
    {

        DBAccess db = new DBAccess();

        [HttpGet]
        [Route("PhoneController/Phone")]
        //GET ALL THE PHONES - Ariane
        public HttpResponseMessage GetAllPhone()
        {
            var phones = db.GetAllPhone();
            return Request.CreateResponse(HttpStatusCode.OK, phones);
        }

        [HttpGet]
        [Route("PhoneController/Phone/id")]
        // GET SPECIFIC PHONE WITH ID - Hicham
        public HttpResponseMessage GetPhoneId(int id)
        {
            var phone = db.GetPhoneId(id);

            return Request.CreateResponse(HttpStatusCode.OK, phone);
        }
    }
}