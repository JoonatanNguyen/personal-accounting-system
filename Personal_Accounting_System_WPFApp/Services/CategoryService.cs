using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Accounting_System_WPFApp.Services
{
    class CategoryService
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public void AddCategory(CategoryDto category)
        {
            categoryRepository.AddCategory(category);
        }

        public List<CategoryDto> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public void ModifyCategory(CategoryDto category)
        {
            categoryRepository.ModifyCategory(category);
        }

        public void DisableCategory(CategoryDto category)
        {
            categoryRepository.DisableCategory(category);
        }
    }
}
