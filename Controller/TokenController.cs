using DeploymentTool.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DeploymentTool.Controller
{
    public class TokenController : ApiController
    {

        [HttpPost]
        [AllowAnonymous]
        public AuthResponse Get(UserForAuthentication request)
        {
            if (CheckUser(request.UserName, request.Password))
            {
                return JwtManager.GenerateToken(request.UserName);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }

    }
}