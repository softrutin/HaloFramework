using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());

            Console.WriteLine("********************CATEGORY******************");

            foreach (var item in cm.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager mg = new ProductManager(new EfProductDal());

            Console.WriteLine("********************PRODUCT******************");

            foreach (var item in mg.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
