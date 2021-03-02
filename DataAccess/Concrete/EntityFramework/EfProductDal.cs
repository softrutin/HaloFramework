using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<NorthwindContext, Product>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var result = from p in db.Products
                             join c in db.Categories on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 CategoryId = p.CategoryId,
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();
            }
        }
    }
}
