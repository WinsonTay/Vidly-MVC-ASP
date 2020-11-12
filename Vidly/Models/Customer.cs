using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer : BaseEntity
    {
        public  int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool IsSubcribedToNewsLetter{ get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MemberShipTypeId { get; set; }
        public DateTime? BirthDate{ get; set; }
    }
}