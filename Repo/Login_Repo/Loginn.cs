using login.DTOs;

namespace login.Repo.Login_Repo
{
    public class Loginn : Ilogin
    {
        private readonly Appdbcontext _context;
        public Loginn(Appdbcontext context)
        {
          _context = context;
        }

        
        public ProfileDto LoginFunction(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                return new ProfileDto
                {
                    Name = user.Name,
                    Email = email,
                    Age = user.Age,
                    Country = user.Country,
                    ImageP  = user.ImageP,
                    Location = user.Location,
                    PhoneNum = user.PhoneNum,
                    School = user.School,
                    Id = user.Id,
                    Status = true,
                    Message = "Login Successfull",
                    Owner = "Cycleny"
                };
            }
            else
            {
                return new ProfileDto
                {
                    Status = false,
                    Message = "Invalid Email or Password",
                    Owner = "Cycleny"
                };
            }
        }
    }
}
