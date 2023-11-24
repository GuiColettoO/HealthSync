using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace HealthSync.Models
{
    [Table("TB_INFOUSER")]
    public class InfoUser
    {
        [Column("id")]
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

        public int Weight { get; set; }

        public int Height { get; set; }

        [DisplayName("Type Restriction Medic")]
        public string? TypeRestrictionMedic { get; set; }
        [DisplayName("Type Restriction Trainne")]
        public string? TypeRestrictionTrainne { get; set; }

        public string Goal { get; set; }

        public IList<InfoMenu> InfosMenus { get; set; }

        public IList<InfoTrainner> InfosTrainners { get; set; }
    }
}
