using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository: IProductRepository
    {
        public void SaveProduct(Product p) => ProductDao.SaveProduct(p);
        public void UpdateProduct(Product p) => ProductDao.UpdateProduct(p);
        public void DeleteProduct(Product p) => ProductDao.DeleteProduct(p);
        public Product GetProductById(int id) => ProductDao.FindProductById(id);
        public List<Category> GetCategories() => CategoryDao.GetCategories();
        public List<Product> GetProducts() => ProductDao.GetProducts();
    }
}
