using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class AccountController : ControllerBase
    {
        public UserManager<ApplicationUser> _userManager { get; }
        public SignInManager<ApplicationUser> _signInManager { get; }
        public IConfiguration _configuration { get; }

        // signup the user
        // database access for saving and retriving the data

        // user manager - provide you a way to save the information
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("signup")]
        public async Task<IdentityResult> SignUp([FromBody] SignUpDTO signUp)
        {
            ApplicationUser appUser = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                UserName = signUp.UserName
            };
            return await _userManager.CreateAsync(appUser, signUp.password);
        }

        // endpoint to generate the token 

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO signUp)
        {
            // validation his credentials
            var signInResult = await _signInManager.PasswordSignInAsync(signUp.UserName, signUp.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(signUp.UserName);
                var issuer = _configuration["Tokens:Issuer"];
                var audience = _configuration["Tokens:Audience"];
                var key = _configuration["Tokens:Key"];
                // jwt token 
                var claims = new[] {
                    new Claim("FirstName", value: user.FirstName),
                    //new Claim(type:JwtRegisteredClaimNames.Email, value: user.Email),
                    new Claim(type:JwtRegisteredClaimNames.Jti, value: user.Id)
                };

                var keyBytes = Encoding.UTF8.GetBytes(key); // private key to create a token
                var theKey = new SymmetricSecurityKey(keyBytes);
                var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Invalid Credentials");
        }
    }

}
