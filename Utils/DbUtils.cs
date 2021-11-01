using BlazorElectronApp.Data;
using System.Threading.Tasks;

namespace BlazorElectronApp.Utils
{
    public class DbUtils
    {
        static DbUtils()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreatedAsync();
            }

        }

    }
}
