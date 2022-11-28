using System.ComponentModel.DataAnnotations;

namespace BTLNhom3.Models;

public class QuanlyNCC
{
    [Key]
     [Required(ErrorMessage = "Mã  sản phẩm không được để trống !!!")]
    public string? MasanNCC { get; set; }
    public string? TenNCC { get; set; }
    
    public string? Masanpham { get; set; }

     public int sodienthoai { get; set; }
    public string? diachi { get; set; }
    
    public string? email { get; set; }
}