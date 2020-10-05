//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Infrastructure.Sql.Dependency
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices.ComTypes;
    using Autofac;
    using Autofac.Core;
    using AutoMapper;
    using Modules.Todo.Core.Repositories;
    using Modules.Todo.Core.Specifications;
    using Modules.Todo.Infrastructure.Sql.Repositories;

    /// <summary>
    /// Defines the <see cref="InfrastructureModule" />.
    /// </summary>
    /// <remarks>
    /// https://api.elephantsql.com/console/a4aa110b-c239-40cf-a29b-e5bd94d28fb5/details?
    /// </remarks>
    public class InfrastructureModule : Autofac.Module, IModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //postgres://undhnwrj:LhVyK-AlDR4PnJ83mhLMZKD5XqqWl_cR@kandula.db.elephantsql.com:5432/undhnwrj
            builder.RegisterInstance<TodoDbContext>(CreateDb("Data Source=DESKTOP-JH34EEG\\SQLEXPRESS;Initial Catalog=Temp.Todo;Integrated Security=True")).SingleInstance();

            builder.RegisterType<TodoRepository>().As<ITodoRepository>().InstancePerRequest();

            builder.RegisterType<Modules.Todo.Infrastructure.Sql.Mapper.TodoProfile>().As<Profile>();


        }

        private static TodoDbContext CreateDb(string connString)
        {
            return new TodoDbContext(connString);

        }

    }
}
