using System.ComponentModel.DataAnnotations;

namespace BTLNhom3.Models;

public class Quanlysanpham
{
    [Key]
     [Required(ErrorMessage = "Mã  sản phẩm không được để trống !!!")]
    public string? Masanpham { get; set; }
    [Required(ErrorMessage = "Tên sản phẩm không được để trống !!!")]
    public string? Tensanpham { get; set; }
    [Required(ErrorMessage = "Size không được để trống !!!")]
    public int size { get; set; }
    [Required(ErrorMessage = "Số lượng không được để trống !!!")]
     public int soluong { get; set; }
     [Required(ErrorMessage = "Màu sắc không được để trống !!!")]
    public string? mausac { get; set; }
    [Required(ErrorMessage = "Giá tiền không được để trống !!!")]
    
    public decimal giatien { get; set; }
}