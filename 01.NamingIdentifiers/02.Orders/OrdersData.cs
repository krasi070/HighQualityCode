namespace _02.Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using _02.Orders.Models;

    public class OrdersData
    {
        private const string DefaultOrdersFileName = "../../Data/orders.txt";

        private string ordersFileName;

        public OrdersData(string ordersFileName = DefaultOrdersFileName)
        {
            this.ordersFileName = ordersFileName;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            FileLineReader lineReader = new FileLineReader();

            var orders = lineReader.ReadFileLines(this.ordersFileName, true);

            return orders
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    ID = int.Parse(p[0]),
                    ProductID = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }
    }
}
