using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CarApiClasses;

namespace CarSalesApi.Models
{
    public class DBAccess 
    {

        private static CarSalesDBEntities db = new CarSalesDBEntities();

        //Brendan demo
        /*public List<ApiCar> GetCars()
        {
            // Get from EF
            var cars = db.Cars.ToList();
            // convert to api list see my git example
            //return cars;
            List < ApiCar > newCarList = cars.Select(x => new ApiCar() { CarId = x.CarId }).ToList();
            return newCarList;
        }*/

    //Get all
        public static List<ApiCar> GetCars()
        {
            
            var cars = db.Cars.ToList();

            List<ApiCar> carsApi = cars.Select(c => new ApiCar()
            {
                CarId = c.CarId,
                CarColor = c.CarColor,
                CarType = c.CarType,
                CarModel = c.CarModel,
                CarPrice = (double)c.CarPrice,
                CarCommission = (double)c.CarCommission
            }).ToList<ApiCar>();
            return carsApi;

        }


        public static List<ApiLocation> GetLocations()
        {
            
            var locations = db.Locations.ToList();
            List<ApiLocation> locationsApi = locations.Select(c => new ApiLocation()
            {
                LocationId = c.LocationId,
                LocationStateProv = c.LocationStateProv,
                LocationAddress = c.LocationAddress
            }).ToList<ApiLocation>();

            return locationsApi;
           
        }


        public static List<ApiSalesperson>GetSalespersons()
        {
            HttpResponseMessage response;
            var salespersons = db.Salespersons.ToList();
            List<ApiSalesperson> salespersonsApi = salespersons.Select(c => new ApiSalesperson()
            {
                SalespersonId = c.SalespersonId,
                //DANGER DANGER, ITS SHITTY BUT IT WORKS, FIRST AND LAST NAME AND SA
                SalespersonFirstName = c.SalespersonFirstName,
                SalespersonLastName = c.SalespersonLastName,
                SalespersonAddress = c.SalespersonAddress,
                SalespersonPhoneNumber = c.SalespersonPhoneNumber,
                LocationId = c.LocationId,
            }).ToList<ApiSalesperson>();

            return salespersons;
        }

        public HttpResponseMessage GetSales()
        {
            HttpResponseMessage response;
            var sales = db.Sale.ToList();
            List<ApiSale> sales = sales.Select(c => new ApiSale()
            {
                Id = c.SaleId,
                CustomerId = c.CustomerId,
                CarId = c.CarId,
                SalespersonId = c.SalespersonId,
                Date = c.SaleDate,
                Total = c.SaleTotal,
                Quantity = c.SaleQuantity,
            }).ToList<ApiSale>();

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


        public HttpResponseMessage GetCustomers()
        {
            HttpResponseMessage response;
            var customers = db.Customer.ToList();
            List<ApiCustomer> customers = customers.Select(c => new ApiCustomer()
            {
                Id = c.CustomerId,
                FirstName = c.CustomerFirstName,
                LastName = c.CustomerLastName,
                PhoneId = c.CustomerPhoneId,
                Address = c.CustomerAddress,
                Dob = c.CustomerDob
            }).ToList<ApiCustomer>();

            if (customers.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customers);
            }

            return response;
        }


        public HttpResponseMessage GetCustomerPhones()
        {
            HttpResponseMessage response;
            var customerphones = db.CustomerPhone.ToList();
            List<ApiCustomerPhone> customerphones = customerphones.Select(c => new ApiCustomerPhone()
            {
                CustomerPhoneId = c.CustomerPhoneId,
                CustomerId = c.CustomerId,
                PhoneId = c.PhoneId,
                Type = c.CustomerPhoneType,
            }).ToList<ApiCustomerPhone>();

            if (customerphones.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customerphones);
            }

            return response;
        }


        public HttpResponseMessage GetPhones()
        {
            HttpResponseMessage response;
            var phones = db.Phone.ToList();
            List<ApiPhone> phones = phones.Select(c => new ApiPhone()
            {
                PhoneId = c.PhoneId,
                PhoneNumber = c.PhoneNumber,
            }).ToList<ApiPhone>();

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

    }
}