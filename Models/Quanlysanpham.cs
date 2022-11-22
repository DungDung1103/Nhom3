using System.ComponentModel.DataAnnotations;

namespace BTLNhom3.Models;

public class Quanlysanpham
{
    [Key]
    public string? Masanpham { get; set; }
    public string? Tensanpham { get; set; }
  
    public int size { get; set; }
     public int soluong { get; set; }
    public string? mausac { get; set; }
    public decimal giatien { get; set; }
}