using Microsoft.AspNetCore.Components;
using BlazorElectronApp.Model;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using AntDesign;
using System;
using System.Text.Json;
using System.Collections.Generic;
using BlazorElectronApp.Data;
using System.Linq;

namespace BlazorElectronApp.Pages
{


    public class AddBase : ComponentBase
    {
        public Cat Models;
        private MessageService _message = new();
        public List<Category> categories = new List<Category>();
        public List<Character> characters = new List<Character>();
        AppService Service = new AppService();

        public AddBase()
        {
            Models = new();
            using (var dbcontext = new AppDbContext())
            {
                categories = dbcontext.Categories.ToList();
                characters = dbcontext.Characters.ToList();
            }



        }

        public async Task OnValidSubmit(EditContext context)
        {
            if (await Service.CatService.UpdateAsync(Models))
            {
                await _message.Success("提交成功！数据已写入数据库缓存中！");
                Console.WriteLine($"Success:{JsonSerializer.Serialize(Models)}");
            }
            {
                await _message.Error("提交失败！由于未知错误，数据未能写入数据库缓存中!");
                Console.WriteLine($"Error:{JsonSerializer.Serialize(Models)}");
            }

        }


    }

}
