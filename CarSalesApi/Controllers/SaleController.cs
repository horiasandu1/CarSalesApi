using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class SaleController
    {
        DBAccess db = new DBAccess();

        //GET ALL THE SALES - Ariane
        public HttpResponseMessage GetAllSales()
        {
            var sales = db.GetAllSales();
            return Request.CreateResponse(HttpStatusCode.OK, sales);
        }

        // GET SPECIFIC SALE WITH ID - Hicham
        public HttpResponseMessage GetSaleId(int id)
        {
            var sale = db.GetSaleId(id);

            return Request.CreateResponse(HttpStatusCode.OK, sale);
        }
    }
}