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
        Category FindCategoryById(int categoryId);
        IEnumerable<Category> FindCategoriesByAdminId(string adminId);
        bool SubscribeCategory(int userId, int categoryId);
        bool UnsubscribeCategory(int userId, int categoryId);
        bool AddCategory(Category modelObject);
        bool UpdateCategory(Category modelObject);
        bool DeleteCategory(int categoryId);
    }
}
