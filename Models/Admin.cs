using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom3.Models;

public class Admin
{
    [Key]
    [Required(ErrorMessage="ID không được bỏ trống")]
    public int Id { get; set; } 
    [Required(ErrorMessage="Username không được bỏ trống")]
    public string? Username { get; set; }
    [Required(ErrorMessage="Password không được bỏ trống")]
    public string? PassWord { get; set; }
    
}