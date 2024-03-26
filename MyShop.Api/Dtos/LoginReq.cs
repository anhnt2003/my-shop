using System.ComponentModel.DataAnnotations;

namespace MyShop.Identity.Dtos;

public class LoginReq
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string FullName { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string VerifyPassword { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public bool IsRemembered { get; set; }
}