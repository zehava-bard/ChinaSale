using Microsoft.EntityFrameworkCore;
using Project.Migrations;
using Project.Models;
using Project.Models.DTO;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
namespace Project.DAL
{
    public class UserDal: IUserDal
    {
        private readonly Context Context;
        private readonly IConfiguration _Config;

        public UserDal(Context Context, IConfiguration config)
        {
            this.Context = Context;
            _Config = config;
        }
        public async Task<User> CheckBuyer(UserDTO2 buyer)
        {
            var user = Context.User.FirstOrDefault(c => c.Name.ToLower() == buyer.Name.ToLower() && c.Password == buyer.Password);
            await Task.Delay(100);
            if (user != null)
            {
               // throw new Exception($"manager {ManName} not found");
                return user;
            }
            return null;
        }

        public async Task<User> RegisterBuyer(User buyer)
        {
            if ((buyer.Phone.Length != 10 && buyer.Phone.Length != 7) || buyer.Name == "" || buyer.Email == ""||buyer.Password==""||buyer.Password.Length<8) //|| !Float(buyer.Phone).nil ? rescue false)
            {
                Console.WriteLine("invalid details to register costumer");
                return new User();
            }           
            try
            {
                buyer.Role = "Costumer";
                Context.User.Add(buyer);
                Context.SaveChanges();           
                await Task.Delay(100);
                int a=buyer.ID;
                return buyer;
            }            
            catch (Exception ex)
            {
                throw;
            }          

        }

        //login
        public string Generate(User buyer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier,buyer.Name),
                    new Claim(ClaimTypes.Email, buyer.Email),
                    new Claim(ClaimTypes.OtherPhone, buyer.Phone),
                    new Claim(ClaimTypes.Role,buyer.Role)
                };
            var token = new JwtSecurityToken(_Config["Jwt:Issuer"],
                _Config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User Authenticate(UserDTO2 buyer)
        {
            var currentUser = Context.User.FirstOrDefault(b => b.Name.ToLower() == buyer.Name.ToLower() && b.Password == buyer.Password);
            if (currentUser != null) { return currentUser; }
            return null;
        }


    }





}
