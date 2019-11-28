using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CarApiClasses;
using CustomerEntityLibrary;

namespace CarSalesApi.Models
{
    public class DBAccess 
    {

        private static CarSalesDBEntities2 db = new CarSalesDBEntities2();

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

            return salespersonsApi;
        }

        public static List<ApiSale> GetSales()
        {
            
            var sales = db.Sales.ToList();
            List<ApiSale> salesApi = sales.Select(c => new ApiSale()
            {
                SaleId = c.SaleId,
                CustomerId = c.CustomerId,
                CarId = c.CarId,
                SalespersonId = c.SalespersonId,
                SaleDate = (DateTime)c.SaleDate,
                SaleTotal = (double)c.SaleTotal,
                SaleQuantity = (int)c.SaleQuantity,
            }).ToList<ApiSale>();

            return salesApi;
        }


        public static List<ApiCustomer> GetCustomers()
        {
            
            var customers = db.Customers.ToList();
            List<ApiCustomer> customersApi = customers.Select(c => new ApiCustomer()
            {
                CustomerId = c.CustomerId,
                CustomerFirstName = c.CustomerFirstName,
                CustomerLastName = c.CustomerLastName,
                CustomerPhoneId = (int)c.CustomerPhoneId,
                CustomerAddress = c.CustomerAddress,
                CustomerDob = (DateTime)c.CustomerDob
            }).ToList<ApiCustomer>();

            return customersApi;
           
        }


        public static List<ApiCustomerPhone> GetCustomerPhones()
        {
            
            var customerphones = db.Customer_Phone.ToList();
            List<ApiCustomerPhone> customerphonesApi = customerphones.Select(c => new ApiCustomerPhone()
            {
                CustomerPhoneId = c.CustomerPhoneId,
                CustomerId = c.CustomerId,
                PhoneId = c.PhoneId,
                CustomerPhoneType = c.CustomerPhoneType,
            }).ToList<ApiCustomerPhone>();

            return customerphonesApi;
        }


        public static List<ApiPhone> GetPhones()
        {
            
            var phones = db.Phones.ToList();
            List<ApiPhone> phonesApi = phones.Select(c => new ApiPhone()
            {
                PhoneId = c.PhoneId,
                PhoneNumber = c.PhoneNumber,
            }).ToList<ApiPhone>();

            return phonesApi;
        }

    }
}