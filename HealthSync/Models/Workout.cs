using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSync.Models
{
    [Table("TB_WORKOUT")]
    public class Workout
    {
        [Column("id")]
        public int Id { get; set; }

        public TypeWorkout TypeWorkout { get; set; }

        public string Description { get; set; }

        [DisplayName("Quantity for Week")]
        public int QtdForWeek { get; set; }
        [DisplayName("Quantity for time day")]
        public int QtdTime { get; set; }

        //Relação 1:N
        public Trainner Trainner { get; set; }
        public int TrainnerId { get; set; }

    }

    public enum TypeWorkout
    {
        Cardiovascular, Definition, Strength, Functional, HIIT, Hypertrophy, MuscleResistance, Therapeutic
    }
}
