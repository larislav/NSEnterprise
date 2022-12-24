using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace NSE.WebAPI.Core.Usuario
{

    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _acessor;
        public AspNetUser(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }
        public string Name => _acessor.HttpContext.User.Identity.Name;

        public bool EstaAutenticado()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _acessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _acessor.HttpContext;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _acessor.HttpContext.User.GetUserEmail() : "";
        }

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_acessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _acessor.HttpContext.User.GetUserToken() : "";
        }

        public bool PossuiRole(string role)
        {
            return _acessor.HttpContext.User.IsInRole(role);
        }
    }
}
