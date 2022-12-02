using System.ComponentModel.DataAnnotations;

namespace BTLNhom3.Models;

public class Quanlykhachhang
{
    [Key]
     [Required(ErrorMessage = "Mã  khách  hàng không được để trống !!!")]
    public string? Makhachhang { get; set; }
    [Required(ErrorMessage = "Tên khách hàng không được để trống !!!")]
    public string? Tenkhachhang{ get; set; }
  
    public string? Diachi { get; set; }
     public int Sodienthoai { get; set; }
     
}