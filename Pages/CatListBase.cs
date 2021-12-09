using BlazorElectronApp.Data;
using BlazorElectronApp.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace BlazorElectronApp.Pages
{
    public class CatsDbo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Sex { get; set; }

        public string Category { get; set; }
    };



    public class CatListBase : ComponentBase
    {
        public Cat[] _CatList;

        public CatsDbo[] _catlist;

        public Dictionary<int, string> sex;
        public CatListBase() 
        {
            using (var dbcontext = new AppDbContext())
            {
                _CatList = dbcontext.Cats.ToArray();
            }
            sex = new Dictionary<int, string>();
            sex.Add(-1, "未知");
            sex.Add(0, "雌性");
            sex.Add(1, "雄性");
            foreach (Cat cat in _CatList) 
            {
                var _catsdbo = new CatsDbo();

                _catsdbo.ID = cat.ID;
                _catsdbo.Name = cat.Name;
                _catsdbo.Description = cat.Description;
                _catsdbo.Sex = sex[cat.Sex];
                using (var dbcontext = new AppDbContext())
                {
                    _catsdbo.Category = dbcontext.Categories.Find(cat.ColorIndex).Name;
                }
                _catlist.Append(_catsdbo);
            }
        }
    }
}
