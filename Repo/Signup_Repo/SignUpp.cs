using login.DTOs;
using login.Models;
using Microsoft.EntityFrameworkCore;

namespace login.Repo.Signup_Repo
{
    public class SignUpp : ISignUP
    {

        private readonly Appdbcontext _context;
        public SignUpp(Appdbcontext context)
        {
            _context = context;
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(i => i.Id == id);
        }


        public SignUpMeesage DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return new SignUpMeesage
                {
                    Status = false,
                    Message = "User not found",
                    Owner = "Cycleny"
                };
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return new SignUpMeesage
            {
                Status = true,
                Message = "User deleted successfully",
                Owner = "Cycleny"
            };
        }

        public SignUpMeesage SignUpFunction(SignUpAdd sign)
        {
            var serach = _context.Users.FirstOrDefault(i => i.Email == sign.Email);
            if (serach == null)
            {
                var user = new User
                {
                    Email = sign.Email,
                    Password = sign.Password,
                    Name = sign.Name,
                    ConfairmPassword = sign.ConfairmPassword,
                    Age = sign.Age,
                    Country = sign.Country,
                    ImageP = sign.ImageP,
                    Location = sign.Location,
                    School = sign.School,
                    PhoneNum = sign.PhoneNum,
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return new SignUpMeesage
                {
                    Status = true,
                    Message = "SignUp Successfully",
                    Owner = "Cycleny"

                };
            }
            else
            {
                return new SignUpMeesage
                {
                    Status = false,
                    Message = "This Email is already existed",
                    Owner = "Cycleny"

                };
            }
        }

        public SignUpUpadte UpdateUser(int id, SignUpUpadte sign)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return new SignUpUpadte
                {
                    Status = false,
                    Message = "User not found",
                    Owner = "Cycleny"
                };
            }
            user.Name = sign.Name;
            user.Email = sign.Email;
            user.PhoneNum = sign.PhoneNum;
            user.Age = sign.Age;
            user.Location = sign.Location;
            user.School = sign.School;
            user.Country = sign.Country;
            user.ImageP = sign.ImageP;
            user.Password = sign.Password;
            _context.Users.Update(user);
            _context.SaveChanges();

            return new SignUpUpadte
            {
                Status = true,
                Message = "User updated successfully",
                Owner = "Cycleny"
            };
        }
    }
}
