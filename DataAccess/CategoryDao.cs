using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDao
    {
        public static List<Category> GetCategories()
        {
            var list = new List<Category>();
            try
            {
                using (var context = new MyDBContext())
                {
                    list = context.Categories.ToList();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
            return list;
        }
    }
}
