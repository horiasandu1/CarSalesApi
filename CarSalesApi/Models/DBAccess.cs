using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CarApiClasses;
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
                SaleTotal = (Decimal)c.SaleTotal,
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

            PropertyCopier<Car, ApiCar>.Copy(car, carApi,true);

            return carApi;
        }

        public static ApiCustomer GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);

            var customerApi = new ApiCustomer();

            PropertyCopier<Customer, ApiCustomer>.Copy(customer, customerApi,true);

            return customerApi;
        }

        public static ApiCustomerPhone GetCustomerPhone(int id)
        {
            var customerPhone = db.Customer_Phone.Find(id);

            var customerPhoneApi = new ApiCustomerPhone();

            PropertyCopier<Customer_Phone, ApiCustomerPhone>.Copy(customerPhone, customerPhoneApi,true);

            return customerPhoneApi;
        }

        public static ApiLocation GetLocation(int id)
        {
            var location = db.Locations.Find(id);

            var locationApi = new ApiLocation();

            PropertyCopier<Location, ApiLocation>.Copy(location, locationApi,true);

            return locationApi;
        }

        public static ApiPhone GetPhone(int id)
        {
            var phone = db.Phones.Find(id);

            var phoneApi = new ApiPhone();

            PropertyCopier<Phone, ApiPhone>.Copy(phone, phoneApi,true);

            return phoneApi;
        }

        public static ApiSale GetSale(int id)
        {
            var sale = db.Sales.Find(id);

            var saleApi = new ApiSale();

            PropertyCopier<Sale, ApiSale>.Copy(sale, saleApi,true);

            return saleApi;
        }

        public static ApiSalesperson GetSalesperson(int id)
        {
            var salesperson = db.Salespersons.Find(id);

            var salespersonApi = new ApiSalesperson();

            PropertyCopier<Salesperson, ApiSalesperson>.Copy(salesperson, salespersonApi,true);

            return salespersonApi;
        }

        public static void PostCar(ApiCar ac)
        {

            // Create a new EF Customer.
            Car c = new Car();

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiCar, Car>.Copy(ac, c,true);

            // Tell EF we want to add the customer.
            db.Cars.Add(c);

            //Save changes
            db.SaveChanges();
        }

        public static void PostCustomer(ApiCustomer ac)
        {

            // Create a new EF Customer.
            Customer c = new Customer();            

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiCustomer, Customer>.Copy(ac, c,true);

            // Tell EF we want to add the customer.
            db.Customers.Add(c);

            //Save changes
            db.SaveChanges();
        }

        public static void PostSale(ApiSale sa)
        {

            // Create a new EF Customer.
            Sale s = new Sale();

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiSale, Sale>.Copy(sa, s,true);

            // Tell EF we want to add the customer.
            db.Sales.Add(s);

            //Save changes
            db.SaveChanges();
        }

        public static void PostSalesPerson(ApiSalesperson sp)
        {

            // Create a new EF Customer.
            Salesperson s = new Salesperson();

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiSalesperson, Salesperson>.Copy(sp, s,true);

            // Tell EF we want to add the customer.
            db.Salespersons.Add(s);

            //Save changes
            db.SaveChanges();
        }

        public static void PostPhone(ApiPhone ph)
        {

            // Create a new EF Customer.
            Phone p = new Phone();

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiPhone, Phone>.Copy(ph, p,true);

            // Tell EF we want to add the customer.
            db.Phones.Add(p);

            //Save changes
            db.SaveChanges();
        }

        public static void PostCustomerPhone(ApiCustomerPhone pc)
        {

            // Create a new EF Customer.
            Customer_Phone p = new Customer_Phone();

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiCustomerPhone, Customer_Phone>.Copy(pc, p,true);

            // Tell EF we want to add the customer.
            db.Customer_Phone.Add(p);

            //Save changes
            db.SaveChanges();
        }

        public static void PostLocation(ApiLocation lo)
        {

            // Create a new EF Customer.
            Location l = new Location();

            // Copy the Simplified customer to the EF customer using the tool I provided.
            PropertyCopier<ApiLocation, Location>.Copy(lo, l,true);

            // Tell EF we want to add the customer.
            db.Locations.Add(l);

            //Save changes
            db.SaveChanges();
        }

        public static void DeleteCar(int id)
        {
            Car c = db.Cars.Find(id);

            if (c == null)
            {
                throw new Exception("Sale Not found");
            }

            db.Cars.Remove(c);

            db.SaveChanges();
        }

        public static void DeleteCustomer(int id)
        {

            Customer c = db.Customers.Find(id);

            if (c == null)
            {
                throw new Exception("Sale Not found");
            }

            db.Customers.Remove(c);

            db.SaveChanges();
        }

        public static void DeleteCustomerPhone(int id)
        {
            Customer_Phone c = db.Customer_Phone.Find(id);

            if (c == null)
            {
                throw new Exception("Sale Not found");
            }

            db.Customer_Phone.Remove(c);

            db.SaveChanges();
        }

        public static void DeleteLocation(int id)
        {

            Location c = db.Locations.Find(id);

            if (c == null)
            {
                throw new Exception("Location Not found");
            }

            db.Locations.Remove(c);

            db.SaveChanges();
        }

        public static void DeletePhone(int id)
        {
            Phone c = db.Phones.Find(id);

            if (c == null)
            {
                throw new Exception("Phone Not found");
            }

            db.Phones.Remove(c);

            db.SaveChanges();
        }

        public static void DeleteSale(int id)
        {

            Sale c = db.Sales.Find(id);

            if (c == null)
            {
                throw new Exception("Sale Not found");
            }

            db.Sales.Remove(c);

            db.SaveChanges();
        }

        public static void DeleteSalesperson(int id)
        {

            Salesperson c = db.Salespersons.Find(id);

            if (c == null)
            {
                throw new Exception("Sales person Not found");
            }

            db.Salespersons.Remove(c);

            db.SaveChanges();
        }


        public static void PutCar(int id, ApiCar ac)
        {
            // Create a new car
            Car c = new Car();

            // Copy car
            PropertyCopier<ApiCar, Car>.Copy(ac, c,true);

            c.CarId = id;

            db.Entry(c).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public static void PutCustomer(int id, ApiCustomer ac)
        {
            // Create a new car
            Customer c = new Customer();

            // Copy car
            PropertyCopier<ApiCustomer, Customer>.Copy(ac, c,true);

            c.CustomerId = id;

            db.Entry(c).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public static void PutCustomerPhone(int id, ApiCustomerPhone acp)
        {
            // Create a new car
            Customer_Phone cp = new Customer_Phone();

            // Copy car
            PropertyCopier<ApiCustomerPhone, Customer_Phone>.Copy(acp, cp,true);

            cp.CustomerPhoneId = id;

            db.Entry(cp).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public static void PutPhone(int id, ApiPhone ap)
        {
            // Create a new car
            Phone p = new Phone();

            // Copy car
            PropertyCopier<ApiPhone, Phone>.Copy(ap, p,true);

            p.PhoneId = id;

            db.Entry(p).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public static void PutLocation(int id, ApiLocation al)
        {
            // Create a new car
            Location l = new Location();

            // Copy car
            PropertyCopier<ApiLocation, Location>.Copy(al, l,true);

            l.LocationId = id;

            db.Entry(l).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public static void PutSale(int id, ApiSale aps)
        {
            // Create a new car
            Sale s = new Sale();

            // Copy car
            PropertyCopier<ApiSale, Sale>.Copy(aps, s,true);

            s.SaleId = id;

            db.Entry(s).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public static void PutSalesperson(int id, ApiSalesperson asp)
        {
            // Create a new car
            Salesperson sp = new Salesperson();

            // Copy car
            PropertyCopier<ApiSalesperson, Salesperson>.Copy(asp, sp,true);

            sp.SalespersonId = id;

            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

    }
}