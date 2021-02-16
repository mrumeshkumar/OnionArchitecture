using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using OnionArchitectureDotNet.Core.Interfaces.Repository;
using OnionArchitectureDotNet.Core.Interfaces.Services;
using OnionArchitectureDotNet.Service;
using OnionArchitectureDotNet.Infrastructure.Repository;

namespace OnionArchitectureDotNet.App_Start
{
    public static class IocContainer
    {
        public static UnityContainer ConfigureRepositories(UnityContainer container)
        {
            container.RegisterType<ITaskItemRepository, TaskItemRepository>().
                RegisterType<IDbContext, DbContext>();

            return container;
        }
        public static UnityContainer ConfigureServices(UnityContainer container)
        {
            container.RegisterType<ITaskItemService, TaskItemService>() ;

            return container;
        }
    }
}