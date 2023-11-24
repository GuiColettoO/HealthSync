using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSync.Models
{
    [Table("TB_INFOMENU")]
    public class InfoMenu
    {
            public int MenuId { get; set; }
            public Menu Menu { get; set; }
            public InfoUser InfoUser { get; set; }
            public int InfoUserId { get; set; }
    }
}
