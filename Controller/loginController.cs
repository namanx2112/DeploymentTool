using DeploymentTool.Jwt.Filters;
using DeploymentTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DeploymentTool.Controller
{
    public class loginController : ApiController
    {

       // [JwtAuthentication]
        public string Get()
        {
            return "value";
        }

        // POST api/<controller>
        public dynamic Post([FromBody] dynamic input)
        {
            

            User objUser = new User();
            objUser.userName = input.UserName;
            objUser.password  = input.Password;
            


            DBHelper.login(ref objUser);


            return objUser;
        }

        
    }
}