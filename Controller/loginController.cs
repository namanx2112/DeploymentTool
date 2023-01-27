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
       

        // POST api/<controller>
        public dynamic Post([FromBody] dynamic input)
        {
            string procName = "sproc_UserLogin";
            string tUserName, tPassword;
            string tName = string.Empty;
            string tEmail = string.Empty;
            int nRoleType = -1;
            int nUserID = -1;

            tUserName = input.UserName;
            tPassword = input.Password;


            DBHelper.login(tUserName, tPassword, out  tName, out  tEmail, out  nRoleType, out  nUserID);


            return new {
                tUserName = tUserName,
                tName = tName,
                tEmail = tEmail,
                nRoleType = nRoleType,
                nUserID = nUserID

            };
        }

        
    }
}