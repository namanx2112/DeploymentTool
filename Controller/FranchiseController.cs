using DeploymentTool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DeploymentTool.Controller
{
    public class FranchiseController : ApiController
    {
        // [AllowAnonymous]
        // GET api/<controller>
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{

        //    var result = DBHelper.ExecuteProcedure<List<Franchise>>("sprocFranchiseGet", reader =>
        //    {
        //        var franchises = new List<Franchise>();
        //        while (reader.Read())
        //        {
        //            var franchise = new Franchise();
        //            franchise.aFranchiseId = (int)reader["aFranchiseId"];
        //            franchise.tFranchiseName = reader["tFranchiseName"].ToString();
        //            franchise.nBrandId = (int)reader["nBrandId"];
        //            franchise.tFranchiseDescription = reader["tFranchiseDescription"].ToString();
        //            franchise.tFranchiseLocation = reader["tFranchiseLocation"].ToString();
        //            franchise.dFranchiseEstablished = (DateTime)reader["dFranchiseEstablished"];
        //            franchise.tFranchiseContact = reader["tFranchiseContact"].ToString();
        //            franchise.tFranchiseOwner = reader["tFranchiseOwner"].ToString();
        //            franchise.tFranchiseEmail = reader["tFranchiseEmail"].ToString();
        //            franchise.tFranchisePhone = reader["tFranchisePhone"].ToString();
        //            franchise.tFranchiseAddress = reader["tFranchiseAddress"].ToString();
        //            franchise.nFranchiseEmployeeCount = (int)reader["nFranchiseEmployeeCount"];
        //            franchise.nFranchiseRevenue = (int)reader["nFranchiseRevenue"];
        //            franchise.nCreatedBy = (int)reader["nCreatedBy"];
        //            franchise.nUpdateBy = (int)reader["nUpdateBy"];
        //            franchise.dtCreatedOn = (DateTime)reader["dtCreatedOn"];
        //            franchise.dtUpdatedOn = (DateTime)reader["dtUpdatedOn"];
        //            franchise.bDeleted = (bool)reader["bDeleted"];
        //            franchises.Add(franchise);
        //        }
        //        return franchises;
        //    });

        //    if (result == null)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NoContent);
        //    }
        //    else
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.OK)
        //        {
        //            Content = new ObjectContent<List<Franchise>>(result, new JsonMediaTypeFormatter())
        //        };
        //    }
        //}
        // GET api/<controller>/5
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Get([FromBody] Franchise objFranchise)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@nFranchiseId", objFranchise.aFranchiseId),
                new SqlParameter("@tFranchiseName", objFranchise.tFranchiseName),
                new SqlParameter("@nBrandID", objFranchise.nBrandId),
                new SqlParameter("@tFranchiseEmail", objFranchise.tFranchiseEmail),
                new SqlParameter("@tFranchiseOwner", objFranchise.tFranchiseOwner),
                new SqlParameter("@tFranchisePhone", objFranchise.tFranchisePhone),
                new SqlParameter("@nUserID", objFranchise.nUserID),
            };
            var result = DBHelper.ExecuteProcedure<Franchise>("sprocFranchiseGet", reader =>
            {
                var franchise = new Franchise();
                franchise.aFranchiseId = reader["aFranchiseId"] == DBNull.Value ? default : (int)reader["aFranchiseId"];
                franchise.tFranchiseName = reader["tFranchiseName"] == DBNull.Value ? null : reader["tFranchiseName"].ToString();
                franchise.nBrandId = reader["nBrandId"] == DBNull.Value ? default : (int)reader["nBrandId"];
                franchise.tFranchiseDescription = reader["tFranchiseDescription"] == DBNull.Value ? null : reader["tFranchiseDescription"].ToString();
                franchise.tFranchiseLocation = reader["tFranchiseLocation"] == DBNull.Value ? null : reader["tFranchiseLocation"].ToString();
                if (reader["dFranchiseEstablished"] != DBNull.Value)
                {
                    franchise.dFranchiseEstablished = (DateTime)reader["dFranchiseEstablished"];
                   // franchise.dFranchiseEstablished = reader["dFranchiseEstablished"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["dFranchiseEstablished"];
                }
                franchise.tFranchiseContact = reader["tFranchiseContact"] == DBNull.Value ? null : reader["tFranchiseContact"].ToString();
                franchise.tFranchiseOwner = reader["tFranchiseOwner"] == DBNull.Value ? null : reader["tFranchiseOwner"].ToString();
                franchise.tFranchiseEmail = reader["tFranchiseEmail"] == DBNull.Value ? null : reader["tFranchiseEmail"].ToString();
                franchise.tFranchisePhone = reader["tFranchisePhone"] == DBNull.Value ? null : reader["tFranchisePhone"].ToString();
                franchise.tFranchiseAddress = reader["tFranchiseAddress"] == DBNull.Value ? null : reader["tFranchiseAddress"].ToString();
                franchise.nFranchiseEmployeeCount = reader["nFranchiseEmployeeCount"] == DBNull.Value ? default : (int)reader["nFranchiseEmployeeCount"];
                franchise.nFranchiseRevenue = reader["nFranchiseRevenue"] == DBNull.Value ? default : (int)reader["nFranchiseRevenue"];
                franchise.nCreatedBy = reader["nCreatedBy"] == DBNull.Value ? default : (int)reader["nCreatedBy"];
                franchise.nUpdateBy = reader["nUpdateBy"] == DBNull.Value ? default : (int)reader["nUpdateBy"];
                //franchise.dtCreatedOn = reader["dtCreatedOn"] == DBNull.Value ? default : (DateTime)reader["dtCreatedOn"];
                //franchise.dtUpdatedOn = reader["dtUpdatedOn"] == DBNull.Value ? default : (DateTime)reader["dtUpdatedOn"];
                franchise.bDeleted = reader["bDeleted"] == DBNull.Value ? default : (bool)reader["bDeleted"];
                return franchise;
            }, parameters);

            if (result == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<Franchise>(result, new JsonMediaTypeFormatter())
                };
            }
        }
        // POST api/<controller>
        //public HttpResponseMessage Post([FromBody] dynamic franchise)
        //{
        //    var parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@tFranchiseName", franchise.tFranchiseName),
        //            new SqlParameter("@nBrandID", franchise.nBrandId),
        //            new SqlParameter("@tFranchiseDescription", franchise.tFranchiseDescription),
        //            new SqlParameter("@tFranchiseLocation", franchise.tFranchiseLocation),
        //            new SqlParameter("@dFranchiseEstablished", franchise.dFranchiseEstablished),
        //            new SqlParameter("@tFranchiseContact", franchise.tFranchiseContact),
        //            new SqlParameter("@tFranchiseOwner", franchise.tFranchiseOwner),
        //            new SqlParameter("@tFranchiseEmail", franchise.tFranchiseEmail),
        //            new SqlParameter("@tFranchisePhone", franchise.tFranchisePhone),
        //            new SqlParameter("@tFranchiseAddress", franchise.tFranchiseAddress),
        //            new SqlParameter("@nFranchiseEmployeeCount", franchise.nFranchiseEmployeeCount),
        //            new SqlParameter("@nFranchiseRevenue", franchise.nFranchiseRevenue),
        //            new SqlParameter("@nUserId",franchise.nUserId)

        //        };
        //    SqlParameter[] arroutParam = new SqlParameter[1];
        //    SqlParameter outParam = new SqlParameter();
        //    outParam.ParameterName = "@nFranchiseID";
        //    outParam.SqlDbType = SqlDbType.Int;
        //    outParam.Direction = ParameterDirection.Output;
        //    outParam.Value = 0;
        //    arroutParam[0] = outParam;

        //    var result = DBHelper.ExecuteProcedure<Franchise>("sprocFranchiseCreate", reader =>
        //    {
        //        return new Franchise();
        //    }, ref arroutParam, parameters);
        //    int franchiseID = (int)arroutParam[0].Value;
        //    return new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ObjectContent<dynamic>(new { FranchiseID = franchiseID }, new JsonMediaTypeFormatter())
        //    };

        //}
        //[HttpPost]
        //// PUT api/<controller>/5
        //public HttpResponseMessage Put([FromBody] Franchise franchise)
        //{
        //    var parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@nFranchiseId", franchise.aFranchiseId),
        //            new SqlParameter("@tFranchiseName", franchise.tFranchiseName),
        //            new SqlParameter("@nBrandID", franchise.nBrandId),
        //            new SqlParameter("@tFranchiseDescription", franchise.tFranchiseDescription),
        //            new SqlParameter("@tFranchiseLocation", franchise.tFranchiseLocation),
        //            new SqlParameter("@dFranchiseEstablished", franchise.dFranchiseEstablished),
        //            new SqlParameter("@tFranchiseContact", franchise.tFranchiseContact),
        //            new SqlParameter("@tFranchiseOwner", franchise.tFranchiseOwner),
        //            new SqlParameter("@tFranchiseEmail", franchise.tFranchiseEmail),
        //            new SqlParameter("@tFranchisePhone", franchise.tFranchisePhone),
        //            new SqlParameter("@tFranchiseAddress", franchise.tFranchiseAddress),
        //            new SqlParameter("@nFranchiseEmployeeCount", franchise.nFranchiseEmployeeCount),
        //            new SqlParameter("@nFranchiseRevenue", franchise.nFranchiseRevenue),
        //            //new SqlParameter("@nUserId",franchise.nUserId)
        //            new SqlParameter("@nCreatedBy", franchise.nCreatedBy),
        //            new SqlParameter("@nUpdateBy", franchise.nUpdateBy),
        //            new SqlParameter("@dtCreatedOn", franchise.dtCreatedOn),
        //            new SqlParameter("@dtUpdatedOn", franchise.dtUpdatedOn),
        //            new SqlParameter("@bDeleted", franchise.bDeleted)
        //        };
        //    DBHelper.ExecuteNonQuery("sprocFranchiseUpdate", parameters);
        //    return new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ObjectContent<string>("Updated Successfully....", new JsonMediaTypeFormatter())
        //    };

        //}
        //// DELETE api/<controller>/5
        //[HttpPost]
        //public HttpResponseMessage Delete(dynamic body)
        //{
        //    var parameters = new SqlParameter[]
        //       {
        //            new SqlParameter("@nFranchiseId", body.nFranchiseId),
        //            new SqlParameter("@nUserID", body.nUserID)
        //       };
        //    DBHelper.ExecuteNonQuery("sprocFranchiseDelete", parameters);
        //    return new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ObjectContent<string>("Deleted Successfully....", new JsonMediaTypeFormatter())
        //    };


        //}
    }
}
