using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.BussinessObject
{
    public class SysCompanyBO
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string UserAdmin { get; set; }
        public string IsDeleted { get; set; }
        public string DeletedUser { get; set; }
        public DateTime DeletedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
