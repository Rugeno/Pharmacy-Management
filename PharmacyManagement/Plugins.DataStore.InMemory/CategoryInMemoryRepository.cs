using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            //Adding default Categories

            categories = new List<Category>()
            {
                new Category{CategoryId = 1, Name = "Tablet", Description="Tablet"},
                new Category{CategoryId = 2, Name = "Liquid", Description="Liquid"},
                new Category{CategoryId = 3, Name = "Capsules", Description="Capsules"},
                new Category{CategoryId = 4, Name = "Inhalers", Description="Inhalers"},
                new Category{CategoryId = 5, Name = "Injection", Description="Injection"},


            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            var maxId = categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;

            categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }
    }
}