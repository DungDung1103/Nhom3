using System.ComponentModel.DataAnnotations;
namespace BTL_Nhom3.Models
{
    public class QuanliNCC
    {
        [Key]
        [Required(ErrorMessage ="Ma NCC khong duoc de trong")]
        public string? MaNCC { get; set; }
        [Required(ErrorMessage ="Ten NCC khong duoc de trong")]
        public string? TenNCC { get; set; }
         [Required(ErrorMessage ="SDT khong duoc de trong")]
        public int Sodienthoai { get; set; }
        public string? Diachi { get; set; }
        public string? Emai {get; set; }
    }
}