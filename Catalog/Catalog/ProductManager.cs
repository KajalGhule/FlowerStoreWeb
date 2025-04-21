using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class ProductManager
    {
       
        public static async Task<List<string>> GetProjectTitles()
        {
            List<Product> products = await GetAllProducts();

            var productNames = products.Select(prod => prod.Title).ToList();

            return productNames;
        }

        public static async Task<List<Product>> GetAllProducts()
        {
            await Task.Delay(10);
            List<Product> allProducts = new List<Product>();
            allProducts = GetAllProductsFromDatabase();
            return allProducts;
        }
        public static List<Product> GetAllProductsFromDatabase()
        {
            List<Product> allProducts = ProductDBManager.GetAll();
            return allProducts;
        }
        //public static Product Get(int id)
        //{
        //    List<Product> products = GetAllProducts();
        //    Product theProduct = products.FirstOrDefault(p => p.Id == id);
        //    return theProduct;
        //}

        //public static Product Get(int id)
        //{
        //    List<Product> products = GetAllProducts();
        //    Product theProduct = products.FirstOrDefault(p => p.Id == id);
        //    return theProduct;
        //}

        public static async Task<Product?> Get(int id)
        {
            var products = await GetAllProducts();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public static async Task<List<Product?>> GetSoldOutProducts()
        {
            List<Product> products = await GetAllProducts();
            var soldOutProducts = from prod in products
                                  where prod.Quantity == 0
                                  select prod;
            return soldOutProducts as List<Product>;
        }

        public static async Task<Dictionary<string, List<Product>>> GetProductsGroupByCategory()
        {
            var products = await GetAllProducts();
            return products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }


    }
}
