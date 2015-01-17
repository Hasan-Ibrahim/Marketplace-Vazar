namespace Data.TokenStorages
{
    public interface ITokenStorage
    {
        string CreateToken(string userId);
        bool TokenExists(string token);
        string GetLoginId(string token);
        bool DeleteToken(string token);
    }
}
