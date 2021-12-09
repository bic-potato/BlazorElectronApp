using System.ComponentModel.DataAnnotations;

namespace BlazorElectronApp.Model
{
    public class Character
    {
        [Key, Required]
        public int ID { get; set; }

        public string Descript { get; set; }
    }
}
