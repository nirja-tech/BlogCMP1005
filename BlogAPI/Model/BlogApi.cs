using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Model
{
    public class BlogApi
    {

           [Key]
            public int Id { get; set; }
    
            public String UserName { get; set; }

            public String Title { get; set; }

            public String Content { get; set; }


            public String Images { get; set; }

            public DateTime Date { get; set; }

             public String Likes { get; set; }
            
            
             
            
        }
    }

