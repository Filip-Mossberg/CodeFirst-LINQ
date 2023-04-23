using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_CodeFirst_LINQ.Models
{
    internal class Subject 
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
