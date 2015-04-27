using SCSUEventHubModels.Models;
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

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<Category> Get()
        {
            return categoriesRepository.Categories;
        }

        public Category Get(int id)
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
