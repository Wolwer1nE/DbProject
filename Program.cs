using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DbProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product product1 = new Product { ProductName = "яйцо" };
                Product product2 = new Product { ProductName = "масло" };

                RecipeProduct recipeProduct1 = new RecipeProduct { Product = product1 };
                RecipeProduct recipeProduct2 = new RecipeProduct { Product = product2 };

                db.Products.AddRange(product1, product2);
                db.RecipeProducts.AddRange(recipeProduct1, recipeProduct2);
                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var products = db.Products.ToList();
                Console.WriteLine("Products list:");
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.ProductId} - {p.ProductName}");
                }

                Console.WriteLine();
                var recipeProducts = db.RecipeProducts.ToList();
                Console.WriteLine("RecipeProducts list:");
                foreach (RecipeProduct rp in recipeProducts)
                {
                    Console.WriteLine($"{rp.RecipeProductId} - {rp.ProductId}");
                }
            }
        }
    }
}
