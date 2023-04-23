using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_CodeFirst_LINQ.Models
{
    internal class Connect
    {
        [Key]
        public int ConnectID { get; set; }
        public string Name { get; set; }
        public List<Teacher> TeacherList { get; set; }
        public List<Student> StudentList { get; set; }
        public Subject Subject { get; set; }
    }
}
