using BlazorElectronApp.Model;
using BlazorElectronApp.Utils;
using System.Linq;

namespace BlazorElectronApp.Data
{
    public class AppService
    {
        public DbUtils<Cat> CatService;
        public DbUtils<Category> CategoryService;

        public AppService()
        {
            var CatService = new DbUtils<Cat>();
            var CategoryService = new DbUtils<Category>();
            var CharacterService = new DbUtils<Character>();
            using(var context = new AppDbContext())
            {
                var _list = context.Categories.ToArray();

                if (_list.Length == 0)
                {
                    var _ = CategoryService.InsertAsync(new Category { Name = "狸花" });
                    _ = CategoryService.InsertAsync(new Category { Name = "橘猫及橘白" });
                    _ = CategoryService.InsertAsync(new Category { Name = "奶牛" });
                    _ = CategoryService.InsertAsync(new Category { Name = "玳瑁及三花" });
                    _ = CategoryService.InsertAsync(new Category { Name = "纯色" });

                    var _list_ = context.Characters.ToArray();
                    if (_list_.Length == 0)
                    {
                        var __ = CharacterService.InsertAsync(new Character { Descript = "亲人可抱" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "亲人不可抱 可摸" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "薛定谔亲人" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "吃东西时可以一直摸" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "吃东西时可以摸一下" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "怕人 安全距离1m以内" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "怕人 安全距离1m以外" });
                        __ = CharacterService.InsertAsync(new Character { Descript = "未知 数据缺失" });

                    }
                    
                }

            }
            
            
        }
    }
}
