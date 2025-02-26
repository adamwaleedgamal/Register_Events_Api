using login.DTOs;
using login.Models;

namespace login.Repo.Signup_Repo
{
    public interface ISignUP
    {
        public SignUpMeesage SignUpFunction(SignUpAdd sign);
        public SignUpUpadte UpdateUser(int id, SignUpUpadte sign);
        public SignUpMeesage DeleteUser(int id);
        public User? GetUserById(int id); 
    }
}
