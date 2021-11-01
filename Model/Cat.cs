using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorElectronApp.Model
{
    public class Cat
    {
        [Required, Key]
        public string ID { get; set; }
 
        public string Name { get; set; }
 
        public int isInAtlas { get; set; }
 
        public string nickname { get; set; }
 
        [ForeignKey("Category")]
        public string ColorIndex { get; set; }

        public string Location { get; set; }

        public int Sex { get; set; }
        [Required]
        public string State { get; set; }

        public int isSterilize { get; set; }

        public DateTime SterilizeDate { get; set; }

        public DateTime Birthday { get; set; }

        public string Descript { get; set; }
  
        public DateTime LastUpdated { get; set; }

    }
}
