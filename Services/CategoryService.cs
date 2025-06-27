using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository icategoryRepository;

        public CategoryService()
        {
            icategoryRepository = new CategoryRepository();
        }

        public bool AddCategory(Category category)
        {
            return icategoryRepository.AddCategory(category);
        }

        public List<Category> GenerateSampleDataset()
        {
            return icategoryRepository.GenerateSampleDataset();
        }

        public List<Category> GetCategories()
        {
            return icategoryRepository.GetCategories();
        }

        public bool RemoveCategory(int categoryId)
        {
            return icategoryRepository.RemoveCategory(categoryId);
        }

        public Category SearchCategory(int categoryId)
        {
            return icategoryRepository.SearchCategory(categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            return icategoryRepository.UpdateCategory(category);
        }
    }
}
