using login.DTOs;

namespace login.Repo.Login_Repo
{
    public interface Ilogin
    {
        public ProfileDto LoginFunction(string email, string password);
    }
}
