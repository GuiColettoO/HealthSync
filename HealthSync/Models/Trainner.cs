using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HealthSync.Models
{
    [Table("TB_USERTRAINNER")]
    public class Trainner
    {
        [Column("ID_USERTRAINNER")]
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
        public IList<Workout> Workouts { get; set; }

        public IList<InfoTrainner> InfosTrainners { get; set; }


    }
}
