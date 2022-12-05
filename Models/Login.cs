using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom3.Models{
   public class Login
   {
    [Key]
     [Required(ErrorMessage =("Họ tên không được bỏ trống"))]
    public string? FullName { get; set; }
     [Required(ErrorMessage =("Username không được bỏ trống"))]
    public string? Username { get; set; }
     [Required(ErrorMessage =("Password không được bỏ trống"))]
    public string? Password { get; set; }
     [Required(ErrorMessage =("ConfirmPassword không được bỏ trống"))]
     [System.ComponentModel.DataAnnotations.Compare("Password")]
    public string? ConfirmPassword { get; set; }
     [Required(ErrorMessage =("Email không được bỏ trống"))]
    public string? Email { get; set; }
    
    
   }
}