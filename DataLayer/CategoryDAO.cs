using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class CategoryDAO
    {
        
        static List<Category> categories = new List<Category>();
        private bool isGenerated = false;
        public List<Category> GenerateSampleDataset()
            {
            if (isGenerated) {
                return categories;
            }

                categories.Add(new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Do uong",
                    Description = "Nuoc ngot, ca phe, tra, bia"
                });

                categories.Add(new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Gia vi",
                    Description = "Tuong, muoi, nuoc mam, sa te"
                });

                categories.Add(new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Keo banh",
                    Description = "Keo mut, banh ngot, banh quy"
                });

                categories.Add(new Category()
                {
                    CategoryID = 4,
                    CategoryName = "San pham tu sua",
                    Description = "Pho mai, sua tuoi, sua chua"
                });

                categories.Add(new Category()
                {
                    CategoryID = 5,
                    CategoryName = "Ngu coc",
                    Description = "Banh mi, mi, com, ngu coc an lien"
                });
                isGenerated = true;
                return categories;
            }

            public List<Category> GetCategories()
            {
                return categories;
            }

            public bool AddCategory(Category category)
            {
                Category c = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
                if (c != null)
                {
                    return false; 
                }

                categories.Add(category);
                return true;
            }

            public bool RemoveCategory(int categoryId)
            {
                Category c = categories.FirstOrDefault(c => c.CategoryID == categoryId);
                if (c == null)
                {
                    return false;
                }

                categories.Remove(c);
                return true;
            }

            public Category SearchCategory(int categoryId)
            {
                return categories.FirstOrDefault(c => c.CategoryID == categoryId);
            }

            public bool UpdateCategory(Category category)
            {
                Category c = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
                if (c == null)
                {
                    return false;
                }

                c.CategoryName = category.CategoryName;
                c.Description = category.Description;

                return true;
            }
    }
}

