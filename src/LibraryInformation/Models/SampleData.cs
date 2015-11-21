using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Models
{
    public class SampleData
    {
        public async static Task InitDB(IServiceProvider service)
        {
            //获取上下文实例
            var db = service.GetRequiredService<MemberContext>();

            //获取UserManager实例
            var userManager = service.GetRequiredService<UserManager<User>>();

            if (db.Database != null && db.Database.EnsureCreated())
            {
                //创建初始用户
                await userManager.CreateAsync(new User
                {
                    UserName = "admin",
                    Email = "627148026@qq.com"
                }, "admin");

                //创建用户信息示例，int型ID会根据seed自动递增
                db.Members.Add(new Member
                {
                    bookName = "JAVA程序设计案例教程",
                    writer = "18845294217",
                    publishing = "627148026@qq.com",
                    callNumber = "TP312JA/774",
                    barCode = "52434872",
                    Note = "无"
                });

                db.Members.Add(new Member
                {
                    bookName = "WEB开发经典",
                    writer = "18845296028",
                    publishing = "627148026@qq.com",
                    callNumber = "TP312JA/774",
                    barCode = "52434872",
                    Note = "无"
                });

                db.Members.Add(new Member
                {
                    bookName = "电锯惊魂夜2",
                    writer = "18845290000",
                    publishing = "627148026@qq.com",
                    callNumber = "TP312JA/774",
                    barCode = "52434872",
                    Note = "这个是测试"
                });
                db.SaveChanges();
            }
        }
    }
}
