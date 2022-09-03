using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain.Data.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public Guid CustomerID { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public Customer(Guid customerID, string firstName, string lastName, DateTime birthDate, string middleName = "")
        {
            CustomerID = customerID;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            BirthDate = birthDate;
        }

        public Customer()
        {

        }
    }
}
