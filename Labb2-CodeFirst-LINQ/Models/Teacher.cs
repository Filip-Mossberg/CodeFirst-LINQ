using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_CodeFirst_LINQ.Models
{
    internal class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Connect Tconnect { get; set; }
    }
}
