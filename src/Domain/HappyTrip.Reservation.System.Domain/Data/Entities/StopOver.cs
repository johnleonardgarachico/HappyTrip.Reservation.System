using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain.Data.Entities
{
    [Table("StopOvers")]
    public class StopOver
    {
        [Key]
        public Guid TripID { get; set; }
        [Required]
        public int Sequence { get; set; }
        [Required, MaxLength(30)]
        public string Area { get; set; }
        [Required]
        public TimeSpan Period { get; set; }

        public StopOver(Guid tripID, int sequence, string area, TimeSpan period)
        {
            TripID = tripID;
            Sequence = sequence;
            Area = area ?? throw new ArgumentNullException(nameof(area));
            Period = period;
        }

        public StopOver()
        {

        }
    }
}
