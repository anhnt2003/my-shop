namespace MyShop.Identity.Dtos;

public class ExternalLoginDto
{
    public string Provider { get; set; } = string.Empty;

    public string IdToken { get; set; } = string.Empty;
}