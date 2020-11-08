using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer : BaseEntity
    {
        public  int id { get; set; }
        public string name { get; set; }
        public bool IsSubcribedToNewsLetter{ get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MemberShipTypeId { get; set; }
    }
}