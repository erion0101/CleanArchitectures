using MediatR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using q.Commands;
using q.DTOs.DTO;
using q.SQL.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace q.Handlers
{
    public class LoginCustomersHandler : IRequestHandler<AuthRequestCommand, TokenDTO>
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomersService _customersService;


        public LoginCustomersHandler(IConfiguration configuration, ICustomersService customersService)
        {
            _configuration = configuration;
            _customersService = customersService;
        }

        public async Task<TokenDTO> Handle(AuthRequestCommand request, CancellationToken cancellationToken)
        {
            var obj = await _customersService.FindCustomersByEmail(request.Email, cancellationToken);
            if (obj != null && BCrypt.Net.BCrypt.Verify(request.Password, obj.Password))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:Expiration"]));

                var customer = await _customersService.GetCustomerById(obj.Id);
                if (customer != null)
                {
                    var roleName = await _customersService.GetRoleNameById(customer.RoleId);
                    if (roleName.Name != null)
                    {
                        if(roleName.PermissionDTO.PermissionName != null)
                        {
                            var claims = new List<Claim>
                            {
                            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                            new Claim(ClaimTypes.Role, roleName.Name),
                            new Claim("Permission", roleName.PermissionDTO.PermissionName)
                            };
                            var tokeen = new JwtSecurityToken(
                                           _configuration["Jwt:Issuer"],
                                           _configuration["Jwt:Issuer"],
                                           expires: expiry,
                                           signingCredentials: signIn,
                                           claims: claims
                                       );
                            return (new TokenDTO { Token = new JwtSecurityTokenHandler().WriteToken(tokeen) });
                        }
                        else
                        {
                            var claimss = new List<Claim>
                            {
                            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                            new Claim(ClaimTypes.Role, roleName.Name),

                            };
                            var token = new JwtSecurityToken(
                                           _configuration["Jwt:Issuer"],
                                           _configuration["Jwt:Issuer"],
                                           expires: expiry,
                                           signingCredentials: signIn,
                                           claims: claimss
                                       );

                            return (new TokenDTO { Token = new JwtSecurityTokenHandler().WriteToken(token) });
                        }
                       
                    }
                    else
                    {
                       
                        var token = new JwtSecurityToken(
                                           _configuration["Jwt:Issuer"],
                                           _configuration["Jwt:Issuer"],
                                           expires: expiry,
                                           signingCredentials: signIn
                                       );
                        return (new TokenDTO { Token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
               
            }
            return null;
        }
        // if (customer != null && customer.RoleId == 2)
        //        {
        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
        //                new Claim(ClaimTypes.Role, "ceo")
        //            };
        //var token = new JwtSecurityToken(
        //                   _configuration["Jwt:Issuer"],
        //                   _configuration["Jwt:Issuer"],
        //                   expires: expiry,
        //                   signingCredentials: signIn,
        //                   claims: claims
        //               );
        //            return (new TokenDTO { Token = new JwtSecurityTokenHandler().WriteToken(token) });
        //        }
    }
}
