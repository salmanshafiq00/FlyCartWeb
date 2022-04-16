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
            using(var context = new FlyCartContext())
            {
              return  context.Products.Include("Catagory").ToList();
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

        public List<Product> searchProduct(string searchString)
        {
            using (var context = new FlyCartContext())
            {
                var product = context.Products.Include("Catagory").ToList();

                if (!string.IsNullOrEmpty(searchString))
                {
                    product = (List<Product>) product.Where(s => s.ProductName.ToUpper().Contains(searchString.ToUpper()));
                    
                }
                return product.ToList();
            }
            

        }
    }
}
