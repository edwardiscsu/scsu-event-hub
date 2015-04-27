using SCSUEventHubModels.Models;
using SCSUEventHubRepository.CategoriesRepositories;
using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SCSUEventHubClient.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesController()
        {
            this.categoriesRepository = new CategoriesRepository();
        }

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoriesRepository.Categories;
        }

        public Category GetCategory(int id)
        {
            Category category = categoriesRepository.FindCategoryById(id);
            if (category == null)
            {
                //return NotFound();
            }
            return category;
            //return Ok(category);
        }
    }
}
