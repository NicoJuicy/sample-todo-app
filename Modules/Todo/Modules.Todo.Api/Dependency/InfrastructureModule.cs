using Autofac;
using Autofac.Core;
using Modules.Todo.Core.Repositories;
using Modules.Todo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Todo.Api.Dependency
{
    public class InfrastructureModule : Autofac.Module, IModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule(new Modules.Todo.Infrastructure.Dependency.InfrastructureModule());
            builder.RegisterModule(new Modules.Todo.Infrastructure.Sql.Dependency.InfrastructureModule());

        }


    }
}