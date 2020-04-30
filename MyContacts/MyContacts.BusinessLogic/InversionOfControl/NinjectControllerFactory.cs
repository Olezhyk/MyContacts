using System;
using System.Web.Mvc;
using System.Web.Routing;
using MyContacts.BusinessLogic.Log;
using MyContacts.BusinessLogic.Services.ServiceImplementation;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.DataAccess.Implementation;
using MyContacts.DataAccess.Interfaces;
using Ninject;

namespace MyContacts.BusinessLogic.InversionOfControl
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IContactService>().To<ContactService>();
            ninjectKernel.Bind(typeof(IRepo<>)).To(typeof(Repo<>));
        }
    }
}