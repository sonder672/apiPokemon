using Microsoft.AspNetCore.Mvc;
using pantera.services.contracts;
using pantera.services.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using pantera.customException;

namespace pantera.controller.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceSignUp _signup;
        private readonly IServiceSignIn _signIn;

        public UserController(IConfiguration configuration, IServiceSignUp signUp, IServiceSignIn signIn)
        {
            this._configuration = configuration;
            this._signup = signUp;
            this._signIn = signIn;
        }

        [Route("api/signup")]
        [HttpPost]
        public async Task<IActionResult> newUser([FromBody] SignUpDTO user)
        {
            try
            {
                await this._signup.newUser(
                    user.Email,
                    user.Password
                );

                return StatusCode(201, new { message = "Created" });
            }
            catch (HttpResponseException exception)
            {
                return StatusCode(exception.StatusCode, exception.Value);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { message = exception.Message });
            }
        }

        [Route("api/signin")]
        [HttpPost]
        public async Task<IActionResult> login([FromBody] SignUpDTO user)
        {
            try
            {
                int? userId = await this._signIn.accessTheAccount(
                                user.Email,
                                user.Password
                            );

                string tokenString = GenerateJSONWebToken(userId ?? 0);

                return StatusCode(201, new { token = tokenString });
            }
            catch (HttpResponseException e)
            {
                return StatusCode(e.StatusCode, e.Value);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { message = exception.Message });
            }
        }

        private string GenerateJSONWebToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"])
            );

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[] {
                new Claim("userId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                this._configuration["Jwt:Issuer"],
                this._configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}