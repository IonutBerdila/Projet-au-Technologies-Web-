using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.User.DBModel
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [
            Display(Name = "Prenume"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            MinLength(4, ErrorMessage = "Lungimea minimă 4 caractere."),
            MaxLength(20, ErrorMessage = "Lungimea maximă 20 caractere.")
        ]
        public string Name { get; set; }

        [
            Display(Name = "Adresa de email"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            DataType(DataType.EmailAddress, ErrorMessage = "Introduce-ți o adresă de email validă.")
        ]
        public string Email { get; set; }

        [
            Display(Name = "Parolă"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            MinLength(8, ErrorMessage = "Lungimea minimă 8 caractere."),
            MaxLength(40, ErrorMessage = "Lungimea maximă 40 caractere."),
            DataType(DataType.Password)
        ]
        public string Password { get; set; }

        public UserRole Level { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateRegisterDate { get; set; }

        [StringLength(15)]
        public string PrivateIp { get; set; }

        [DataType(DataType.Date)]
        public Nullable<DateTime> LastLogin { get; set; }
    }
}
