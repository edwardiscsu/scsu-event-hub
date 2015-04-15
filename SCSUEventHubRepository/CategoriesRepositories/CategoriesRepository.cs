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
    public class CategoriesRepository : ICategoriesRepository
    {
        private EventHubDBEntities context;
        protected bool disposed = false;

        public CategoriesRepository()
        {
            context = new EventHubDBEntities();
        }

        public CategoriesRepository(EventHubDBEntities contextParam)
        {
            context = contextParam;
        }

        IEnumerable<Category> Categories
        {
            get 
            { 
                return context.Categories; 
            }
        }

        public bool AddCategory(Category modelObject)
        {
            context.Categories.Add(modelObject);
            try
            {
                return (context.SaveChanges() > 0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        Category FindCategoryById(int categoryId)
        {
            Category category = context.Categories.Find(categoryId);
            return category;
        }

        IEnumerable<Category> FindCategoriesByAdminId(int adminId)
        {
            IEnumerable<Category> categories = from category in context.Categories
                                               where category.AdminID == adminId
                                               select category;
            return categories;
        }

        bool UpdateCategory(Category modelObject)
        {
            if (modelObject.ID != 0)
            {
                Category category = context.Categories.Find(modelObject.ID);
                if (category == null)
                {
                    return false;
                }
                category.CategoryName = modelObject.CategoryName;
                category.AdminID = modelObject.AdminID;

                return (context.SaveChanges() > 0);
            }
            else
            {
                return false;
            }

        }

        bool DeleteCategory(int categoryId)
        {
            Category category = context.Categories.Find(categoryId);
            context.Categories.Remove(category);
            return (context.SaveChanges() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                context.Dispose();
            }

            disposed = true;
        }
    }
}
