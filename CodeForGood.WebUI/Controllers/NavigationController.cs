using CodeForGood.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeForGood.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProjectRepository repository;

        public NavigationController(IProjectRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Projects
                                                       .Select(x => x.Category)
                                                       .Distinct()
                                                       .OrderBy(x => x);
            return PartialView(categories);
        }
	}
}