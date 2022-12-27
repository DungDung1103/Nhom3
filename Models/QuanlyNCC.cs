using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom3.Models;

public class Quanlyncc
{
    [Key]

   [Required(ErrorMessage = "Mã NCC không được để trống !!!")]
    public string? Mancc { get; set; }
    [Required(ErrorMessage = "Tên NCC không được để trống !!!")]
    public string? Tenncc { get; set; }
     [Required(ErrorMessage = "Số điện thoại không được để trống !!!")]
     public int sodienthoai { get; set; }
    public string? diachi { get; set; }
    
    public string? email { get; set; }
     
}