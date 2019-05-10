using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmOS.Models
{
    public class Alarmy
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa alarmu")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Data wygaśnięcia")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Opis")]
        public string About { get; set; }

        public int Level { get; set; }
        
        [Display(Name = "Poziom alarmu")]
        public string Level2 { get; set; }

        public string UseId { get; set; }
    }
}
