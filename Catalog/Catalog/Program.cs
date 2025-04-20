// See https://aka.ms/new-console-template for more information
using System;
using Catalog;
using System.Collections.Generic;



namespace Catalog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Catalog Service is running...");


            List<Product> GetAllProducts = await ProductManager.GetAllProducts();
            List<string> titleList = await ProductManager.GetProjectTitles();

            foreach (Product title in GetAllProducts)
            {
                Console.WriteLine(title.Category);
            }
            Console.WriteLine("-------------------------------------------------------------------");

            foreach (string title in titleList)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine("-------------------------------------------------------------------");
    
            Product p = await ProductManager.Get(1);
            Console.WriteLine(p.Category);
        }
    }
}

