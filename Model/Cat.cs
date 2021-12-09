using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorElectronApp.Model
{
    public class Cat
    {   
        
        [Required, Key]
        #nullable enable
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int isInAtlas { get; set; }
 
        public string? nickname { get; set; }
 
        [Required, ForeignKey("Category")]
        public int ColorIndex { get; set; }

        public string? Location { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public int isSterilize { get; set; }

        public DateTime? SterilizeDate { get; set; }

        public DateTime? Birthday { get; set; }
        
        public string? Description { get; set; }
        [ForeignKey("Character")]
        public int? Character { get; set; }

        public DateTime? FirstUpdate { get; set; }

        public DateTime? LastUpdated { get; set; }

        public string? FirstUpdatePoistion { get; set; }

        public string? Relationship { get; set; }

        public DateTime? AdoptionTime { get; set; }

        public DateTime? DeathTime { get; set; }

        public string? DeathReason { get; set; }

        public int? Audio { get; set; }
    }
}
