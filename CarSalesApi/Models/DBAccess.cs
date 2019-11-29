using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CarApiClasses;
using CustomerEntityLibrary;
using Utils;

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

        public static ApiCar GetCar(int id)
        {
            var car = db.Cars.Find(id);

            var carApi = new ApiCar();

            PropertyCopier<Car, ApiCar>.Copy(car, carApi);

            return carApi;
        }

        public static ApiCustomer GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);

            var customerApi = new ApiCustomer();

            PropertyCopier<Customer, ApiCustomer>.Copy(customer, customerApi);

            return customerApi;
        }

        public static ApiCustomerPhone GetCustomerPhone(int id)
        {
            var customerPhone = db.Customer_Phone.Find(id);

            var customerPhoneApi = new ApiCustomerPhone();

            PropertyCopier<Customer_Phone, ApiCustomerPhone>.Copy(customerPhone, customerPhoneApi);

            return customerPhoneApi;
        }

        public static ApiLocation GetLocation(int id)
        {
            var location = db.Locations.Find(id);

            var locationApi = new ApiLocation();

            PropertyCopier<Location, ApiLocation>.Copy(location, locationApi);

            return locationApi;
        }

        public static ApiPhone GetPhone(int id)
        {
            var phone = db.Phones.Find(id);

            var phoneApi = new ApiPhone();

            PropertyCopier<Phone, ApiPhone>.Copy(phone, phoneApi);

            return phoneApi;
        }

        public static ApiSale GetSale(int id)
        {
            var sale = db.Sales.Find(id);

            var saleApi = new ApiSale();

            PropertyCopier<Sale, ApiSale>.Copy(sale, saleApi);

            return saleApi;
        }

        public static ApiSalesperson GetSalesperson(int id)
        {
            var salesperson = db.Salespersons.Find(id);

            var salespersonApi = new ApiSalesperson();

            PropertyCopier<Salesperson, ApiSalesperson>.Copy(salesperson, salespersonApi);

            return salespersonApi;
        }
    }
}