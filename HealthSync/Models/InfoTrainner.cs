using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSync.Models
{
    [Table("TB_INFOTRAINNER")]
    public class InfoTrainner
    {
        public int TrainnerId { get; set; }
        public Trainner Trainner { get; set; }
        public InfoUser InfoUser { get; set; }
        public int InfoUserId { get; set; }
    }
}
