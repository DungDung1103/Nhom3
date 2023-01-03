using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BTL_Nhom3.Models;

namespace BTL_Nhom3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<BTL_Nhom3.Models.Quanlikhachhang> Quanlikhachhang { get; set; } = default!;
    public DbSet<BTL_Nhom3.Models.QuanliNCC> QuanliNCC { get; set; } = default!;
    public DbSet<BTL_Nhom3.Models.Quanlisanpham> Quanlisanpham { get; set; } = default!;
    public DbSet<BTL_Nhom3.Models.Quanlidonhang> Quanlidonhang { get; set; } = default!;
}
