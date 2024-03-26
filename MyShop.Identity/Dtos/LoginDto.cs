namespace MyShop.Identity.Dtos;

public class LoginDto
{
    public long UserId { get; set; }
    
    public string UserName { get; set; }
    
    public string FullName { get; set; }
    
    public string Password { get; set; }
    
    public string VerifyPassword { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public bool IsRemembered { get; set; }
}