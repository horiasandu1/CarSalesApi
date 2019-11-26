using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarApiClasses;

namespace CarSalesApi.Models
{
    public class DBAccess
    {

        private CarSalesDBEntities db = new CarSalesDBEntities();

        public List<ApiCar> GetCars()
        {
            // Get from EF

            var cars = db.Cars.ToList();

            // convert to api list see my git example

            //return cars;

            List < ApiCar > newCarList = cars.Select(x => new ApiCar() { CarId = x.CarId }).ToList();



            return newCarList;


        }




    }
}