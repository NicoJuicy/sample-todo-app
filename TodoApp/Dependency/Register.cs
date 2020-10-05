using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using System.ComponentModel;
using AutoMapper.Configuration;
using System.Collections.Generic;


namespace TodoApp.Dependency
{
    public class Register
    {
        //https://autofaccn.readthedocs.io/en/latest/integration/mvc.html
        public static void RegisterAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            //Loop every assembly
            builder.ScanAssembly(el => el.FullName.Contains("Module"));

            builder.RegisterModule(new Autofac.Integration.Mvc.AutofacWebTypesModule());


            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // Mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();


            //Automapper
            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg =>
            {
                var profiles = ctx.Resolve<Profile[]>();
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                    ;
                }
            })).SingleInstance();
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).SingleInstance();

            //request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



        }
    }


    public static class ContainerBuilderExtensions
    {
        public static void ScanAssembly(this ContainerBuilder builder, Func<Assembly, bool> searchAssembly = null)
        {
            if (searchAssembly == null)
                searchAssembly = (assembly) => true;

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            foreach (Assembly assembly in assemblies.Where(searchAssembly).ToArray())
            {
                //  Gets the all modules from each assembly to be registered.
                //  Make sure that each module **MUST** have a parameterless constructor.
                var modules = assembly.GetTypes()
                                      .Where(p => typeof(IModule).IsAssignableFrom(p)
                                                  && !p.IsAbstract)
                                      .Select(p => (IModule)Activator.CreateInstance(p));

                //

                //  Regsiters each module.
                foreach (var module in modules)
                {
                    builder.RegisterModule(module);
                }

                //        builder.RegisterAssemblyModules(assembly);
                //foreach(var module in assembly.GetTypes().Where(el => el.BaseType == typeof(Autofac.Module)))
                //{
                //    builder.RegisterModule(module);
                //}

            }
        }
    }
}