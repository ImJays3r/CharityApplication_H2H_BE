using HeartToHeartNon_Profit.Interfaces;
using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private const string Format = "dd-MM-yyyy";
        private readonly HeartToHeartContext _context;
        private readonly IRandomService _service;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="service"></param>
        public AuthRepository(HeartToHeartContext context, IRandomService service)
        {
            _context = context;
            _service = service;
           
        }

        /// <summary>
        ///  Login authentication by email and password 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> Login(LoginInput userIn)
        {
            var user = await _context.Users.Where(u => u.Email == userIn.Email.ToLower() && u.Status == true && u.RoleName != "SYSADMIN").SingleOrDefaultAsync();
            if (user == null)
                return null;

            if (!_service.VerifyPasswordHash(userIn.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        /// <summary>
        /// Login To ADMIN PAGE
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> LoginAdmin(LoginInput userIn)
        {
            var user = await _context.Users.Where(u => u.Email == userIn.Email.ToLower() && u.Status == true && u.RoleName == "SYSADMIN").SingleOrDefaultAsync();
            if (user == null)
                return null;

            if (!_service.VerifyPasswordHash(userIn.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }


        /// <summary>
        /// Register with auto Role set Member
        /// </summary>
        /// <param name="userIn"></param>
        /// <returns></returns>
        public async Task<bool> Register(Register userIn)
        {
            byte[] passwordHash, passwordSalt;
            _service.CreatePasswordHash(userIn.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                UserName = userIn.UserName,
                CredentialId = userIn.CredentialId,
                DateOfBirth = DateTime.ParseExact(userIn.DateOfBirth, Format, CultureInfo.InvariantCulture),
                Gender = userIn.Gender,
                Email = userIn.Email.ToLower(),
                SignUpDate = DateTime.Now,
                RoleName = "MEMBER",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = userIn.Phone,
                Status = true
            };
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Update avatar after create user
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> UpdateUserPicture(string url, int id)
        {
            try
            {
                var user = await _context.Users.Where(a => a.UserId == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.AvatarUrl = url;
                }
                if (await _context.SaveChangesAsync() > 0)
                    return 1;
                return 3;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// check existed email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }
    }
}
