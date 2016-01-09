namespace _02.Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class OrdersProgram
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var categoriesData = new CategoriesData();
            var categories = categoriesData.GetAllCategories();

            var productsData = new ProductsData();
            var products = productsData.GetAllProducts();

            var ordersData = new OrdersData();
            var orders = ordersData.GetAllOrders();

            var fiveMostExpensiveProducts = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);

            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            var numberOfProducts = products
                .GroupBy(p => p.CategoryID)
                .Select(grp => new { Category = categories.First(c => c.ID == grp.Key).Name, Count = grp.Count() })
                .ToList();

            foreach (var item in numberOfProducts)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            var fiveMostOrderedProducts = orders
                .GroupBy(o => o.ProductID)
                .Select(grp => new { Product = products.First(p => p.ID == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var item in fiveMostOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            var mostProfitableCategory = orders
                .GroupBy(o => o.ProductID)
                .Select(g => new { categoryID = products.First(p => p.ID == g.Key).CategoryID, price = products.First(p => p.ID == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(gg => gg.categoryID)
                .Select(grp => new { CategoryName = categories.First(c => c.ID == grp.Key).Name, TotalQuantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.TotalQuantity)
                .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.CategoryName, mostProfitableCategory.TotalQuantity);
        }
    }
}
