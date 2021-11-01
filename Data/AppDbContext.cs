using BlazorElectronApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorElectronApp.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./data.db");
        }
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的 属性“Cats”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
        public DbSet<Cat> Cats { get; set; }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的 属性“Cats”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的 属性“Categories”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
        public DbSet<Category> Categories { get; set; }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的 属性“Categories”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
    }
}
