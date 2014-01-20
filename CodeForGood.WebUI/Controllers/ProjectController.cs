using CodeForGood.Domain.Abstract;
using CodeForGood.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeForGood.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository repository;

        public int PageSize = 25;

        public ProjectController(IProjectRepository projectRepository)
        {
            this.repository = projectRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProjectListViewModel model = new ProjectListViewModel
            {
                Projects = repository.Projects
                                        .Where(p => category== null || p.Category == category)
                                        .OrderBy(p => p.ProjectId)
                                        .Skip((page - 1)*PageSize)
                                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                                repository.Projects.Count() :
                                repository.Projects.Count(e => e.Category == category)

                },
                CurrentCateogry = category
            };
            return View(model);
        }
	}
}