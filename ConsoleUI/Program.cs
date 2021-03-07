using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDetailTest();
            //ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());

            Console.WriteLine("********************CATEGORY******************");

            foreach (var item in cm.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager mg = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            Console.WriteLine("********************PRODUCT******************");

            var result = mg.GetAll();

            foreach (var item in result.Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }


        private static void ProductDetailTest()
        {
            ProductManager mg = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            Console.WriteLine("********************ProductDetailTest******************");

            var result = mg.GetProductDetails();

            foreach (var item in result.Data)
            {
                Console.WriteLine($"{item.CategoryName}  - {item.ProductName}  - {item.UnitsInStock}"); ;
            }
        }
    }
}
