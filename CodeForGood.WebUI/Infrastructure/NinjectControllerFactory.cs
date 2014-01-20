using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using CodeForGood.Domain.Abstract;
using CodeForGood.Domain.Entities;
using CodeForGood.Domain.Concrete;
using System.Web.Mvc;

namespace CodeForGood.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory, IDisposable
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProjectRepository>().To<EFProjectRepository>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (ninjectKernel != null)
                {
                    ninjectKernel.Dispose();
                    ninjectKernel = null;
                }
            }
        }
    }
}