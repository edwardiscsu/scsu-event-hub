using SCSUEventHubRepository.Entity;
using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.CategoriesRepositories
{
    public class CategoriesRepository : ContextDisposableRespository, ICategoriesRepository
    {
        public IEnumerable<Category> Categories
        {
            get 
            {
                return DBContext.Categories; 
            }
        }

        public bool AddCategory(Category modelObject)
        {
            DBContext.Categories.Add(modelObject);
            try
            {
                return (DBContext.SaveChanges() > 0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public Category FindCategoryById(int categoryId)
        {
            Category category = DBContext.Categories.Find(categoryId);
            return category;
        }

        public IEnumerable<Category> FindCategoriesByAdminId(int adminId)
        {
            IEnumerable<Category> categories = from category in DBContext.Categories
                                               where category.AdminID == adminId
                                               select category;
            return categories;
        }

        public bool SubscribeCategory(int userId, int categoryId)
        {
            CategorySubscription link = new CategorySubscription { UserID = userId, CategoryID = categoryId };
            DBContext.CategorySubscriptions.Add(link);
            try
            {
                return (DBContext.SaveChanges() > 0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public bool UnsubscribeCategory(int userId, int categoryId)
        {
            CategorySubscription removed = (from link in DBContext.CategorySubscriptions
                                           where link.UserID == userId &&
                                                 link.CategoryID == categoryId
                                           select link).SingleOrDefault();
            DBContext.CategorySubscriptions.Remove(removed);
            try
            {
                return (DBContext.SaveChanges() > 0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public bool UpdateCategory(Category modelObject)
        {
            if (modelObject.ID != 0)
            {
                Category category = DBContext.Categories.Find(modelObject.ID);
                if (category == null)
                {
                    return false;
                }
                category.CategoryName = modelObject.CategoryName;
                category.AdminID = modelObject.AdminID;
                try
                {
                    return (DBContext.SaveChanges() > 0);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool DeleteCategory(int categoryId)
        {
            Category category = DBContext.Categories.Find(categoryId);
            DBContext.Categories.Remove(category);
            try
            {
                return (DBContext.SaveChanges() > 0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
