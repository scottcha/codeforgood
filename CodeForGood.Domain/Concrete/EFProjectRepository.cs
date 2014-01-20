using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeForGood.Domain.Abstract;
using CodeForGood.Domain.Entities;

namespace CodeForGood.Domain.Concrete
{
    public class EFProjectRepository : IProjectRepository, IDisposable
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Project> Projects
        {
            get { return context.Projects; }
        }

        public void SaveProject(Project project)
        {
            if (project.ProjectId == 0)
            {
                context.Projects.Add(project);
            }
            else
            {
                Project dbEntry = context.Projects.Find(project.ProjectId);
                if (dbEntry != null)
                {
                    dbEntry.ProjectUri = project.ProjectUri;
                }
            }
            context.SaveChanges();
        }

        public Project DeleteProject(int projectId)
        {
            Project dbEntry = context.Projects.Find(projectId);
            if(dbEntry != null)
            {
                context.Projects.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }
    }
}
