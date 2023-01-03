
using System.ComponentModel.DataAnnotations;

namespace BTL_Nhom3.Models
{
    public class Quanlikhachhang
    {
        [Key]
        [Required(ErrorMessage ="Ma khach hang khong duoc bo trong")]
        public string? Makhachhang {get; set;}
        [Required(ErrorMessage ="Ten khach hang khong duoc bo trong")]
        public string? Tenkhachhang {get; set;}
        public string? Diachi { get; set; }
        public int Sodienthoai { get; set; }
    }
}