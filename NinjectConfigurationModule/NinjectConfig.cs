using BusinessLogicLayer;
using BusinessLogicLayer.SubSystemInterfaces;
using BusinessLogicLayer.SubSystems;
using DataAccessLayer;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer;

namespace NinjectConfigurationModule
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<DbContext>().To<NewsModel>();
            Bind<ISystemFacade>().To<SystemFacade>();
            Bind<IPresentSubSystem>().To<PresentSubSystem>();
            Bind<IEditSubSystem>().To<EditSubSystem>();
            Bind<ILoggingSubSystem>().To<LoggingSubSystem>();
        }
    }
}
