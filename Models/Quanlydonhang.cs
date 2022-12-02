using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom3.Models;

public class Quanlydonhang

{
   [Key]
    [Required(ErrorMessage = "Mã  sản phẩm không được để trống !!!")]
    public string? Madonhang { get; set; }
    [DataType(DataType.Date)]
    public DateTime ngaylamnv { get; set; }
     public string? Masanpham { get; set; }
    [ForeignKey("Masanpham")]
    public Quanlysanpham ?Quanlysanpham { get; set; } 
     public string? Makhachhang { get; set; }
    [ForeignKey("Makhachhang")]
    public Quanlykhachhang ?Quanlykhachhang { get; set; }
}
     
