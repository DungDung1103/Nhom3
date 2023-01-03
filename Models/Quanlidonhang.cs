using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Nhom3.Models
{
    public class Quanlidonhang
    {
        [Key]
        [Required(ErrorMessage ="Ma don hang khong duoc bo trong")]
        
        public string? Madonhang { get; set; }
         [Required(ErrorMessage ="Ngay khong duoc bo trong")]
         [DataType(DataType.Date)]
        public DateTime ngay { get; set; }
         [Required(ErrorMessage ="Ma san pham khong duoc bo trong")]
         public string? Masanpham { get; set; }
         [ForeignKey("Masanpham")]
         public Quanlisanpham ?Quanlisanpham {get; set; }
        public string? Makhachhang { get; set; }
        [ForeignKey("Makhachhang")]
        public Quanlikhachhang ?Quanlikhachhang {get; set; }
    }
}