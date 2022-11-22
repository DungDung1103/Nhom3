using System.ComponentModel.DataAnnotations;

namespace BTLNhom3.Models;

public class Admin
{
    public int Id { get; set; }
    public string? Username { get; set; }
  
    public string? PassWord { get; set; }
}