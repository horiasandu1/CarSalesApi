using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class SaleController : ApiController
    {
        

        [HttpGet]
        [Route("SaleController/Sale")]
        //GET ALL THE SALES - Ariane
        public HttpResponseMessage GetSales()
        {
            HttpResponseMessage response;
            var sales = DBAccess.GetSales();
            if (sales.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sales);
            }

            return response;
        }

        [HttpGet]
        [Route("SaleController/Sale/id")]
        // GET SPECIFIC SALE WITH ID - Hicham
        public HttpResponseMessage GetSale(int id)
        {
            var sale = db.GetSale(id);

            return Request.CreateResponse(HttpStatusCode.OK, sale);
        }
    }
}