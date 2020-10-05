using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutoMapper;

namespace Modules.Todo.Api.Dependency
{
    public class ApiControllerModule : Autofac.Module, IModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Mapper.TodoProfile>().As<Profile>();

        }
    }
}