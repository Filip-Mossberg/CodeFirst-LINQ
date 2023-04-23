using Labb2_CodeFirst_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_CodeFirst_LINQ.ContextDB
{
    internal class SchoolContext : DbContext
    {
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Connect> connects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = FILIPS-HP;Initial Catalog=SchoolCV;Integrated Security = True;");
        }
    }
}
