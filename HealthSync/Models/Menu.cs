using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSync.Models
{
    [Table("TB_MENU")]
    public class Menu
    {
        [Column("id")]
        public int Id { get; set; }

        public string NumberOfDays { get; set; }

        public string Breakfast { get; set; }

        public string Lunch { get; set; }

        public string AfternoonSnack { get; set; }

        public string Dinner { get; set; }

        //Relação 1:N
        public Medic Medic { get; set; }

        public int MedicId { get; set; }

        public IList<InfoMenu> InfosMenus { get; set; }

    }
}
