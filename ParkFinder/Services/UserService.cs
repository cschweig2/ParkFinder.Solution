using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkFinder.Models;
using ParkFinder.Helpers;

namespace ParkFinder.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private ParkFinderContext _db;

        public UserService(IOptions<AppSettings> appSettings, ParkFinderContext db)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }

        public User Authenticate(string username, string password)
        {
            var user = _db.Users.SingleOrDefault(entry => entry.Username == username && entry.Password == password);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList().Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}