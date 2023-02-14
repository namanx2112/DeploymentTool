using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using DeploymentTool.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Web;

namespace DeploymentTool.Controller
{
    public class BrandController : ApiController
    {
        
        [AllowAnonymous]
        // GET api/<controller>
        [HttpGet]
        [ActionName("GetBrands")]
        public HttpResponseMessage GetBrands()
        {
            var result = DBHelper.ExecuteProcedure<List<Brand>>("sprocBrandGet", reader =>
            {
                var brands = new List<Brand>();
                while (reader.Read())
                {
                    var brand = new Brand();
                    brand.aBrandId = reader["aBrandId"] == null ? -1 : (int)reader["aBrandId"];
                    brand.tBrandName = reader["tBrandName"].ToString();
                    brand.tBrandDescription = reader["tBrandDescription"].ToString();
                    brand.tBrandWebsite = reader["tBrandWebsite"].ToString();
                    brand.tBrandCountry = reader["tBrandCountry"].ToString();
                    brand.tBrandEstablished = (DateTime)reader["tBrandEstablished"];
                    brand.tBrandCategory = reader["tBrandCategory"].ToString();
                    brand.tBrandContact = reader["tBrandContact"].ToString();
                    brand.nBrandLogoAttachmentID = (int)reader["nBrandLogoAttachmentID"];
                    brand.nCreatedBy = (int)reader["nCreatedBy"];
                    brand.nUpdateBy = (int)reader["nUpdateBy"];
                    brand.dtCreatedOn = (DateTime)reader["dtCreatedOn"];
                    brand.dtUpdatedOn = (DateTime)reader["dtUpdatedOn"];
                    brand.bDeleted = (bool)reader["bDeleted"];
                    brands.Add(brand);
                }
                return brands;
            });

            if (result == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<List<Brand>>(result, new JsonMediaTypeFormatter())
                };
            }
        }


        [AllowAnonymous]
        // GET api/<controller>/5
        [ActionName("{GetbyBrand}")]
        [HttpGet]
        public HttpResponseMessage GetbyBrand(int id)
        {
            var context = HttpContext.Current.Request;
            var result = DBHelper.ExecuteProcedure<Brand>("sprocBrandGet", reader =>
            {
                var brand = new Brand();
                brand.aBrandId = (int)reader["aBrandId"];
                brand.tBrandName = reader["tBrandName"].ToString();
                brand.tBrandDescription = reader["tBrandDescription"].ToString();
                brand.tBrandWebsite = reader["tBrandWebsite"].ToString();
                brand.tBrandCountry = reader["tBrandCountry"].ToString();
                brand.tBrandEstablished = (DateTime)reader["tBrandEstablished"];
                brand.tBrandCategory = reader["tBrandCategory"].ToString();
                brand.tBrandContact = reader["tBrandContact"].ToString();
                brand.nBrandLogoAttachmentID = (int)reader["nBrandLogoAttachmentID"];
                brand.nCreatedBy = (int)reader["nCreatedBy"];
                brand.nUpdateBy = (int)reader["nUpdateBy"];
                brand.dtCreatedOn = (DateTime)reader["dtCreatedOn"];
                brand.dtUpdatedOn = (DateTime)reader["dtUpdatedOn"];
                brand.bDeleted = (bool)reader["bDeleted"];
                return brand;
            }, new SqlParameter("@BrandId", id));

            if (result == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<Brand>(result, new JsonMediaTypeFormatter())
                };
            }
        }
        [Authorize]
        [HttpPost]
        [Route("api/Brand/create")]
        // POST api/<controller>
        public HttpResponseMessage CreateBrand([FromBody] Brand brand)
        {

          
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@tBrandName", brand.tBrandName),
                    new SqlParameter("@tBrandDescription", brand.tBrandDescription),
                    new SqlParameter("@tBrandWebsite", brand.tBrandWebsite),
                    new SqlParameter("@tBrandCountry", brand.tBrandCountry),
                    new SqlParameter("@tBrandEstablished", brand.tBrandEstablished),
                    new SqlParameter("@tBrandCategory", brand.tBrandCategory),
                    new SqlParameter("@tBrandContact", brand.tBrandContact),
                    new SqlParameter("@nBrandLogoAttachmentID", brand.nBrandLogoAttachmentID),
                    new SqlParameter("@nUserId","")
                };
            SqlParameter[] arroutParam = new SqlParameter[1];
                SqlParameter outParam = new SqlParameter();
                outParam.ParameterName = "@BrandID";
                outParam.SqlDbType = SqlDbType.Int;
                outParam.Direction = ParameterDirection.Output;
                outParam.Value = 0;
            arroutParam[0] = outParam;

            var result = DBHelper.ExecuteProcedure<Brand>("sp_InsertBrand", reader =>
            {
                return new Brand();
            },ref arroutParam, parameters);
            brand.aBrandId  = (int)arroutParam[0].Value;
            
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Brand>(brand, new JsonMediaTypeFormatter())
            };

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Brand/update")]
        // PUT api/<controller>/5
        public HttpResponseMessage Update([FromBody] Brand brand)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@tBrandName", brand.tBrandName),
                    new SqlParameter("@tBrandDescription", brand.tBrandDescription),
                    new SqlParameter("@tBrandWebsite", brand.tBrandWebsite),
                    new SqlParameter("@tBrandCountry", brand.tBrandCountry),
                    new SqlParameter("@tBrandEstablished", brand.tBrandEstablished),
                    new SqlParameter("@tBrandCategory", brand.tBrandCategory),
                    new SqlParameter("@tBrandContact", brand.tBrandContact),
                    new SqlParameter("@nBrandLogoAttachmentID", brand.nBrandLogoAttachmentID),
                    new SqlParameter("@nCreatedBy", brand.nCreatedBy),
                    new SqlParameter("@nUpdateBy", brand.nUpdateBy),
                    new SqlParameter("@dtCreatedOn", brand.dtCreatedOn),
                    new SqlParameter("@dtUpdatedOn", brand.dtUpdatedOn),
                    new SqlParameter("@bDeleted", brand.bDeleted)
                };
            DBHelper.ExecuteNonQuery("sprocBrandUpdate", parameters);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Brand>(brand, new JsonMediaTypeFormatter())
            };

        }

        // DELETE api/<controller>/5
       
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Brand/delete")]
        public HttpResponseMessage Delete(Brand brand)
        {
            var parameters = new SqlParameter[]
               {
                    new SqlParameter("@nBrandId", brand.aBrandId),
                    new SqlParameter("@nUserID", User.Identity)
               };
            DBHelper.ExecuteNonQuery("SprocBrandDelete", parameters);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Brand>(new Brand(), new JsonMediaTypeFormatter())
            };


        }
    }
}