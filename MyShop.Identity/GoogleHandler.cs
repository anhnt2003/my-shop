using Google.Apis.Auth;

namespace MyShop.Identity;

public class GoogleHandler
{
    private readonly string _clientId;
    public GoogleHandler(string clientId)
    {
        _clientId = clientId;
    }
    public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleTokenAsync(string idToken)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { _clientId }
            };
            var payLoad = await GoogleJsonWebSignature.ValidateAsync (idToken, settings);
            return payLoad;
        } 
        catch (Exception) {
            return null;
        }
    }
}