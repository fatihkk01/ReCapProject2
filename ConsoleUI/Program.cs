using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Core.Entities.Concrete;
using Entities.Concrete;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //ColorTest();

            //BrandTest();

            //CarDtoTest();

            //UserTest();

            //CustomerTest();

            //RentalTest();

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);


        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.CheckReturnDate(1);

            Console.WriteLine(result.Message);

            var result2 = rentalManager.UpdateReturnDate(1);

            Console.WriteLine(result2.Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("CustomerId : " + customer.UserId);
                    Console.WriteLine("CompanyName : " + customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //var result = userManager.GetAll();

            //if (result.Success)
            //{
            //    Console.WriteLine("--------------------------------------");
            //    foreach (var user in result.Data)
            //    {
            //        Console.WriteLine("UserId : " + user.Id);
            //        Console.WriteLine("FirstName : " + user.FirstName);
            //        Console.WriteLine("LastName : " + user.LastName);
            //        Console.WriteLine("Email : " + user.Email);
            //        Console.WriteLine("PasswordHash : " + user.PasswordHash);
            //        Console.WriteLine("PasswordSalt : " + user.PasswordSalt);
            //        Console.WriteLine("--------------------------------------");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : " + car.CarId);
                    Console.WriteLine("Color Name : " + car.ColorName);
                    Console.WriteLine("Brand Name : " + car.BrandName);
                    Console.WriteLine("Daily Price : " + car.DailyPrice);
                    Console.WriteLine("Model Year : " + car.ModelYear);
                    Console.WriteLine("Description : " + car.Description);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Brand Id : " + brand.BrandId);
                    Console.WriteLine("Brand Name : " + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("ColorId : " + color.ColorId);
                    Console.WriteLine("ColorName : " + color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAllByDailyPrice(1000, 100);

            if (result.Success)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarId : " + car.CarId);
                    Console.WriteLine("ColorId : " + car.ColorId);
                    Console.WriteLine("BrandId : " + car.BrandId);
                    Console.WriteLine("DailyPrice : " + car.DailyPrice);
                    Console.WriteLine("ModelYear : " + car.ModelYear);
                    Console.WriteLine("Description : " + car.Description);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
