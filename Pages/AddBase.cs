using Microsoft.AspNetCore.Components;
using BlazorElectronApp.Model;
using BlazorElectronApp.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using AntDesign;
using static BlazorElectronApp.Pages.AddItem;

namespace BlazorElectronApp.Pages
{


    public class AddBase:ComponentBase
    {

        
        public CatDbo Models = new();

        public void OnValidSubmit()
        {
            using (var context = new AppDbContext())
            {
                context.Add(Models);
            }
        }
        private async Task OnValidSubmit(EditContext context)
        {
            
            await Task.Delay(3000);
            
        }


    }

}
