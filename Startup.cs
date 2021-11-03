using BlazorElectronApp.Data;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorElectronApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddAntDesign();
            services.AddElectron();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            Task.Run(async () =>
            {
                var window = await Electron.WindowManager.CreateWindowAsync(
                            new BrowserWindowOptions
                            {
                                HasShadow = true,
                                AutoHideMenuBar = true, //自动隐藏菜单栏
                    Fullscreenable = true
                            });
                window.SetTitle("Blazor Demo App");
              
                window.OnClose +=  async () =>
                {   
                    var config = new MessageBoxOptions("是否要退出")
                    {
                        Type = MessageBoxType.info,
                        Buttons = new string[] { "是", "否" },
                    };
                    var result = await Electron.Dialog.ShowMessageBoxAsync(config);
                    if (result.Response == 0 )
                    {
                        window.Show();
                    }
                    else
                    {
                        window.Close();
                    };    
                  
                };

            });
        }
    }
}
