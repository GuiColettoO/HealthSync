using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSync.Models
{
    [Table("TB_USERMEDIC")]
    public class Medic
    {
        [Column("ID_USERMEDIC")]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required, Range(0, 5)]
        public int Age { get; set; }

        [Required]
        [DisplayName("CRM")]
        public int NumberofCredential { get; set; }

        //Relação 1:N
        public IList<Menu> Menus { get; set; }
    }
}
