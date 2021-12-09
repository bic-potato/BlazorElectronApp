﻿using System.ComponentModel.DataAnnotations;

namespace BlazorElectronApp.Model
{
    public class Category
    {

        public string Name { get; set; }


        [Required, Key]

        public int ID { get; set; }
    }
}
