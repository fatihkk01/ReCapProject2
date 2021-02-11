using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

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

        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("CarId : " + car.CarId);
                Console.WriteLine("ColorName : " + car.ColorName);
                Console.WriteLine("BrandName : " + car.BrandName);
                Console.WriteLine("DailyPrice : " + car.DailyPrice);
                Console.WriteLine("ModelYear : " + car.ModelYear);
                Console.WriteLine("Description : " + car.Description);

            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId : " + brand.BrandId);
                Console.WriteLine("BrandName : " + brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId : " + color.ColorId);
                Console.WriteLine("ColorName : " + color.ColorName);
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
