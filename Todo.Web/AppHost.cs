using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Funq;
using ServiceStack;
using ServiceStack.Razor;

namespace Todo.Web
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Test Razor", typeof(AppHost).Assembly) { }

        public override void Configure(Container container)
        {
            //   LogManager.LogFactory = new ConsoleLogFactory();

            Plugins.Add(new RazorFormat());
            //   Plugins.Add(new MarkdownFormat());

            //container.Register<IDbConnectionFactory>(
            //    new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));

            //using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
            //{
            //    db.CreateTableIfNotExists<Rockstar>();
            //    db.InsertAll(RockstarsService.SeedData);
            //}

            this.CustomErrorHttpHandlers[HttpStatusCode.NotFound] = new RazorHandler("/notfound");
            this.CustomErrorHttpHandlers[HttpStatusCode.Unauthorized] = new RazorHandler("/login");

            //AddAuthentication(container); //Uncomment to enable User Authentication
            SetConfig(new HostConfig { DebugMode = true });
        }

        //private void AddAuthentication(Container container)
        //{
        //    container.Register<IUserAuthRepository>(c =>
        //        new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

        //    container.Resolve<IUserAuthRepository>().InitSchema();

        //    Plugins.Add(new AuthFeature(() => new AuthUserSession(),
        //        new IAuthProvider[] {
        //            new CredentialsAuthProvider(),
        //        }
        //    ));
        //}
    }
}