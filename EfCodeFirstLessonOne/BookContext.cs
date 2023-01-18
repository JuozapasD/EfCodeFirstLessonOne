using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstLessonOne
{
    public class BookContext : DbContext
    {

        // tai yra musu lenteles duomenu bazeje
        public DbSet<Page> Pages { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;");
        }
    }
}
