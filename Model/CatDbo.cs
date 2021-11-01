using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorElectronApp.Model
{
    public class CatDbo
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int isInAtlas { get; set; }

        public string? nickname { get; set; }
        [Required]
        public int? ColorIndex { get; set; }

        public string? Location { get; set; }
        [Required]
        public int? Sex { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public int? isSterilize { get; set; }

        public DateTime? SterilizeDate { get; set; }

        public DateTime? Birthday { get; set; }

        

        public DateTime? LastUpdated { get; set; }

        public string? Description { get; set; }

    }
}
