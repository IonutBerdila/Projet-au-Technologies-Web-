using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class Career
    {
        [Required]
        [Display(Name = "Nume și Prenume")]
        public string FullName { get; set; }

        [Required]
        [Range(18, 65, ErrorMessage = "Vârsta trebuie să fie între 18 și 65 de ani.")]
        [Display(Name = "Vârsta")]
        public int Age { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Locuri de muncă restaurant")]
        public string RestaurantJob { get; set; }

        [Display(Name = "Locuri de muncă din fabrică")]
        public string FactoryJob { get; set; }

        [Display(Name = "Ce limbi cunoașteți?")]
        public string Languages { get; set; }

        [Display(Name = "Sunt dispus să lucrez")]
        public string WorkType { get; set; }

        [Display(Name = "În care rețea de restaurante?")]
        public string RestaurantNetwork { get; set; }
    }
}