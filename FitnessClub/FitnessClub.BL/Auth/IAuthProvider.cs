using FitnessClub.BL.Auth.Entities;

namespace FitnessClub.BL.Auth;

public interface IAuthProvider
{
    Task<TokensResponse> AuthorizeUser(string email, string password);
    //register - do by yourself
}