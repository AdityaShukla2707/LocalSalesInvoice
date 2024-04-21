using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceDOM.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        
       
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public string StateCode { get; set; }
    }
}
