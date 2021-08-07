using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCMP1005.Models
{
    public class Blog


    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
       

        public String UserName { get; set; }

        public String Title { get; set; }
        
        public String Content { get; set;}

        
        public String Images { get; set; } 
        
        public DateTime Date { get; set; }
    }
}
