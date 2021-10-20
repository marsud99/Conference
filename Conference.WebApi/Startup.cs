using Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Conference.Application;
using Conference.WebApi.Swagger;
using MediatR;
using Conference.Application.Queries;
using Conference.ExternalService;
using MediatR.Pipeline;
using FluentValidation;
using Conference.WebApi.MediatorPipeline;
using Conference.WebApi.Middleware;
using Conference.Data;

namespace Conference.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(o => o.EnableEndpointRouting = false);

/*            services.Scan(scan => scan
                .FromAssemblyOf<GetConferences>()
                .AddClasses(classes => classes.AssignableTo<IValidator>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());*/

            services.AddMediatR(typeof(GetConferences).Assembly); // get all IRequestHandler and INotificationHandler classes

            /*            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
                        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
                        services.AddScoped(typeof(IRequestPreProcessor<>), typeof(ValidationPreProcessor<>));*/

            services.AddConferenceDataAccess(Configuration);
            services.RegisterBusinessServices(Configuration);
            services.AddSwagger(Configuration["Identity:Authority"]);

            // NEVER USE
            //services.BuildServiceProvider(); => serviceProvider...lista de "matrite"
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseMiddleware<ErrorMiddleware>(); // error 
            app.UseCors(cors =>
            {
                cors
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

#pragma warning disable MVC1005 // Cannot use UseMvc with Endpoint Routing.
            app.UseMvc();
#pragma warning restore MVC1005 // Cannot use UseMvc with Endpoint Routing.

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference Api");
                //c.OAuthClientId("CharismaFinancialServices");
                //c.OAuthScopeSeparator(" ");
                c.EnableValidator(null);
            });

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Suggestion}/{action=Index}");
            });
        }
    }
}
