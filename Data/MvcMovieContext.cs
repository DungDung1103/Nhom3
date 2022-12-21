using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLNhom3.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        

        public DbSet<BTLNhom3.Models.Quanlysanpham> Quanlysanpham { get; set; } = default!;

        public DbSet<BTLNhom3.Models.Quanlykhachhang> Quanlykhachhang { get; set; } = default!;

        public DbSet<BTLNhom3.Models.Quanlyncc> Quanlyncc { get; set; } = default!;

        public DbSet<BTLNhom3.Models.Quanlydonhang> Quanlydonhang { get; set; } = default!;
        
    }
}
