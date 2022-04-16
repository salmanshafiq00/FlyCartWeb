using FlyCart.Database;
using FlyCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCart.Services
{
    public class ProductServices
    {
        public Product GetProduct(int Id)
        {
            using (var context = new FlyCartContext())
            {
                return context.Products.Find(Id);
            }
        }
        public List<Product> GetProducts()
        {
            //using (var context = new FlyCartContext())
            //{
            var context = new FlyCartContext();
            //var pList = from p in context.Products.Include("Catagory") select p;
            var pList = context.Products.Include("Catagory");
                return pList.ToList();

            //}
        }
        public void CreateProduct(Product product)
        {
            using (var context = new FlyCartContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            using (var context = new FlyCartContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new FlyCartContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> searchProduct(string searchString)
        {
            using (var context = new FlyCartContext())
            {
                var product = from p in context.Products select p;

                if (!string.IsNullOrEmpty(searchString))
                {
                    product = product.Where(s => s.ProductName.ToUpper().Contains(searchString));
                    
                }
                return product.ToList();
            }
            

        }
    }
}
