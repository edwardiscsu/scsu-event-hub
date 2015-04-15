using SCSUEventHubModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Categories { get; }
        bool AddCategory(Category modelObject);
        Category FindCategoryById(int categoryId);
        IEnumerable<Category> FindCategoriesByAdminId(int adminId);
        bool UpdateCategory(Category modelObject);
        bool DeleteCategory(int categoryId);
    }
}
