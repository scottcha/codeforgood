using CodeForGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeForGood.Domain.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<Project> Projects { get; }
        void SaveProject(Project project);
        Project DeleteProject(int projectId);
    }
}
