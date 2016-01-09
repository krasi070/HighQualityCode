namespace _02.Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using _02.Orders.Models;

    public class ProductsData
    {
        private const string DefaultProductsFileName = "../../Data/products.txt";

        private string productsFileName;

        public ProductsData(string productsFileName = DefaultProductsFileName)
        {
            this.productsFileName = productsFileName;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            FileLineReader lineReader = new FileLineReader();

            var products = lineReader.ReadFileLines(this.productsFileName, true);

            return products
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    ID = int.Parse(p[0]),
                    Name = p[1],
                    CategoryID = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }
    }
}
