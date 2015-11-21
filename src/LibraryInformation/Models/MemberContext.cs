using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Models
{
    public class MemberContext:IdentityDbContext<User>
    {
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Member>(e =>
         {
                //建立索引，为以后添加注册成员按id进行升降序功能预留
                e.Index(x => x.Id);
         });
        }
    }
}
