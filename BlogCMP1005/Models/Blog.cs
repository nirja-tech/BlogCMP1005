using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCMP1005.Models
{
    public class Blog


    {    
        [Key]
        public int Id { get; set; }
        [Required]

        public String UserName { get; set; }

        [Required]
        public String Title { get; set; }
        [Required]
        public String Content { get; set;}

        [Required]
        public String Images { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
