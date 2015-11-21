using LibraryInformation.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //获取应用环境服务
            var appEnv = services.BuildServiceProvider().GetRequiredService<IApplicationEnvironment>();

            //添加entity framework服务
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<MemberContext>(x => x.UseSqlite("Date source=" + appEnv.ApplicationBasePath + "/member.db"));

            //添加identity服务
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MemberContext>()
                .AddDefaultTokenProviders();
            //添加mvc服务
            services.AddMvc();
            services.AddSmartUser<User, string>();
        }

        public async void Configure(IApplicationBuilder app)
        {
            //用staticFiles就会为WWROOT下的文件添加到路由规则中
            app.UseStaticFiles();
            //使用Identity中间件可以使标记有[Authorize] 的action在未登录时跳转到登录页面
            app.UseIdentity();
            //mvc中间件
            app.UseMvc(x => x.MapRoute("default", "{controller=Home}/{action=Index}/{id=?}"));
            //初始化数据库并添加初始数据
            await SampleData.InitDB(app.ApplicationServices);


        }
    }
}
