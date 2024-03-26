namespace MyShop.Identity.Dtos;

public class UserLoginDto
{
    public long UserId { get; set; } = 9999;

    public string UserName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
}