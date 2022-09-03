using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyTrip.Reservation.System.Domain.Data.Entities
{
    [Table("Terminals")]
    public class Terminal
    {
        [Key]
        public Guid TerminalID { get; set; }
        [Required, MaxLength(30)]
        public string Company { get; set; }
        [Required, MaxLength(30)]
        public string Area { get; set; }

        public Terminal(Guid terminalID, string company, string area)
        {
            TerminalID = terminalID;
            Company = company ?? throw new ArgumentNullException(nameof(company));
            Area = area ?? throw new ArgumentNullException(nameof(area));
        }

        public Terminal()
        {

        }
    }
}
