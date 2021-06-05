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
                db.Products.AddRange(product1, product2);
                
                var recipe1 = new Recipe { Name = "Яичница"};
                recipe1.Products.Add(product1);
                
                var recipe2 = new Recipe { Name = "Яичница с маслом"};
                recipe2.Products.Add(product1);
                recipe2.Products.Add(product2);

                db.Recipes.AddRange(recipe1, recipe2);
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
                var recipes = db.Recipes
                    .Include(c => c.Products)
                    .ToList();
                
                Console.WriteLine("RecipeProducts list:");
                foreach (var rp in recipes)
                {
                    Console.WriteLine($"{rp.Name}:");
                    foreach (var p in rp.Products)
                    {
                        Console.WriteLine($"      {p.ProductName}");
                    }
                }
            }
        }
    }
}
