using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Bookstore
{
	public class Startup
	{

		public Startup(IConfiguration configuration) => Configuration = configuration;
		public IConfiguration Configuration { get; }

	public Startup(IWebHostEnvironment env)
	{ 
		Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build(); 
	}




	// This method gets called by the runtime. Use this method to add services to the container.
	// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public void ConfigureServices(IServiceCollection services)
		{
		services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionString:BookstoreConnectionStr"]));
		services.AddTransient<IBookRepository, EFBookRepository>();
		services.AddTransient<IBookRepository, FakeBookRepository>();
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			//app.UseMvcWithDefaultRoute();

			app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Book}/{action=List}/{id?}"));

			SeedData.EnsurePopulated(app);
		}
	}
}
