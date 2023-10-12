using AutoMapper;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utilities;
using WebApi.Auth;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        public AuthController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRq loginRq)
        {
            var account = await _accountService.GetByUserName(loginRq.UserName);
            if (account != null)
            {
                bool verify = AuthExtension.VerifyPasswordHash(loginRq.Password, account.Password);
                if (verify)
                {
                    string token = AuthExtension.GenerateJWTToken(account);
                    Response.Cookies.Append("Access-Token", token, new CookieOptions()
                    {
                        HttpOnly = true,
                        Expires = DateTime.Now.AddMinutes(30)
                    });
                    var result = _mapper.Map<LoginRp>(account);
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var token = Request.Cookies["Access-Token"];
            if (token.IsNotBlank())
            {
                var principal = AuthExtension.GetPrincipalFromExpiredToken(token);
                var userName = principal.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userName.IsNotBlank())
                {
                    var account = await _accountService.GetByUserName(userName);
                    var result = _mapper.Map<LoginRp>(account);
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpDelete]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Access-Token");
            return Ok();
        }
    }
}
