//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Infrastructure.Dependency
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices.ComTypes;
    using Autofac;
    using Autofac.Core;
    using AutoMapper;
    using Marten;
    using Modules.Todo.Core.Repositories;
    using Modules.Todo.Infrastructure.Repositories;

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
            builder.RegisterInstance<IDocumentStore>(CreateDocumentStore("User ID=undhnwrj;Password=LhVyK-AlDR4PnJ83mhLMZKD5XqqWl_cR;Database=undhnwrj;Host=kandula.db.elephantsql.com;Port=5432")).SingleInstance();
            builder.Register<IDocumentSession>(ctx => CreateSession(ctx.Resolve<IDocumentStore>())).InstancePerRequest();
            builder.RegisterType<TodoRepository>().As<ITodoRepository>().InstancePerRequest();

            builder.RegisterType<Modules.Todo.Infrastructure.Mapper.TodoProfile>().As<Profile>();


        }

        private static IDocumentSession CreateSession(IDocumentStore documentStore)
        {
            return documentStore.LightweightSession();
        }


        private static IDocumentStore CreateDocumentStore(string connectionString)
        {

            var store = DocumentStore.For(_ =>
            {
                _.Connection(connectionString);
                _.DatabaseSchemaName = "todo_service";
                _.PLV8Enabled = false; // https://jasperfx.github.io/marten/documentation/documents/advanced/javascript_transformations/

                _.Schema.For<Documents.TodoDocument>().Duplicate(el => el.Description, configure: idx =>
        {
            idx.SortOrder = SortOrder.Asc;
        });

                var indexedColumns = new Expression<Func<Documents.TodoDocument, object>>[]
                {
                    x => x.Id,
                    x => x.IsActive
                };

                _.Schema.For<Documents.TodoDocument>().Index(indexedColumns);
                //   _.Schema.For<Documents.ContactDocument>().MultiTenanted();

            });



            return store;
        }
    }
}
