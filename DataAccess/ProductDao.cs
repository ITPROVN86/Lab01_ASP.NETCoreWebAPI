using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDao
    {
        public static List<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (var context = new MyDBContext())
                {
                    list = context.Products.ToList();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
            return list;
        }

        public static Product FindProductById(int id)
        {
            Product p = new Product();
            try
            {
                using (var context = new MyDBContext())
                {
                    p = context.Products.SingleOrDefault(x => x.ProductId == id);
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    var p1 = context.Products.SingleOrDefault(x => x.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
