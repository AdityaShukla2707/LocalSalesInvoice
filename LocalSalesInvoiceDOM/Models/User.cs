using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceDOM.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int ZipCode { get; set; }
        public int MobileNo { get; set; }
        public string UIDNumber { get; set; }
       
        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

    }
}
