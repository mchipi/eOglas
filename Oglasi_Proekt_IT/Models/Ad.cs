using Oglasi_Proekt_IT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oglasi_Proekt_IT.Models
{
    public enum Cities
    {
        Берово,
        Битола,
        Валандово,
        Велес,
        Виница,
        Гевгелија,
        Гостивар,
        Дебар,
        Делчево,
        [Display(Name = "Демир Хисар")]
        ДемирХисар,
        Кавадарци,
        Кичево,
        Кочани,
        Кратово,
        [Display(Name = "Крива Паланка")]
        КриваПаланка,
        Крушево,
        Куманово,
        [Display(Name = "Македонски Брод")]
        МакедонскиБрод,
        Неготино,
        Охрид,
        Прилеп,
        Пробиштип,
        Радовиш,
        Ресен,
        [Display(Name = "Свети Николе")]
        СветиНиколе,
        Скопје,
        Струга,
        Струмица,
        Тетово,
        Штип
    }

    

    public class Ad

    {
        [Key]
        public int IDnum { get; set; }
        [Required] 
        public string  Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Viber { get; set; }
        
        public string Location { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [Display (Name ="URL for your image")]
        public string ImageURL { get; set; }

        public int ViewCounter { get; set; }

        public string UserViews { get; set; }

    }

    
}