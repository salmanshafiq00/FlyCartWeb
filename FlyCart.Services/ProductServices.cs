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
            using (var context = new FlyCartContext())
            {
                return context.Products.ToList();

            }
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
    }
}
