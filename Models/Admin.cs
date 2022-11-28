using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom3.Models;

public class Admin
{
    public int Id { get; set; } 
    public string? Username { get; set; }
  
    public string? PassWord { get; set; }
    public string? Makhachhang { get; set; }
    [ForeignKey("Makhachhang")]
    public Quanlykhachhang Quanlykhachhang { get; set; }
}