namespace _02.Orders
{
    using System.Linq;
    using System.Collections.Generic;
    using _02.Orders.Models;

    public class CategoriesData
    {
        private const string DefaultCategoriesFileName = "../../Data/categories.txt";

        private string categoriesFileName;

        public CategoriesData(string categoriesFileName = DefaultCategoriesFileName)
        {
            this.categoriesFileName = categoriesFileName;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            FileLineReader lineReader = new FileLineReader();

            var categories = lineReader.ReadFileLines(this.categoriesFileName, true);

            return categories
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    ID = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }
    }
}
