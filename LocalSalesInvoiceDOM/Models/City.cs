using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceDOM.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityCode { get; set; }
        public string Name { get; set; }    
        
        public int StateId { get; set; }
         
        

    }
}
