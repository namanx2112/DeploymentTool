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

namespace DeploymentTool.Controller
{
    public class BrandController : ApiController
    {
        [Route("api/GetAll")]
        [AllowAnonymous]
        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get()
        {

            var result = DBHelper.ExecuteProcedure<List<Brand>>("sprocBrandGet", reader =>
            {
                var brands = new List<Brand>();
                while (reader.Read())
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


        // GET api/<controller>/5

        [Route("api/Get")]
        [HttpPost]
        public HttpResponseMessage Get([FromBody] dynamic Brand)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@BrandId", Brand.BrandId),
                new SqlParameter("@tBrandName", Brand.tBrandName),
                new SqlParameter("@nUserID", Brand.nUserID),
            };
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
            }, parameters);
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

        [Route("api/CreateBrand")]
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage CreateBrand(Brand brand)
        {
            if (brand.aBrandId > 0) {
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
                return Request.CreateResponse(HttpStatusCode.OK, brand);
            }
            else
            {
                //brand.aBrandId = 111;
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
                    new SqlParameter("@nUserId",brand.nCreatedBy),
                   };
                SqlParameter[] arroutParam = new SqlParameter[1];
                SqlParameter outParam = new SqlParameter();
                outParam.ParameterName = "@nBrandID";
                outParam.SqlDbType = SqlDbType.Int;
                outParam.Direction = ParameterDirection.Output;
                outParam.Value = 0;
                arroutParam[0] = outParam;

                var result = DBHelper.ExecuteProcedure<Brand>("sprocBrandCreate", reader =>
                {
                    return new Brand();
                }, ref arroutParam, parameters);
                brand.aBrandId = (int)arroutParam[0].Value;

                return Request.CreateResponse(HttpStatusCode.OK, brand);
            }
        }

        [Route("api/Post")]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] dynamic brand)
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
                    new SqlParameter("@nUserId",brand.nUserId)
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
            int brandID = (int)arroutParam[0].Value;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<dynamic>(new {BrandID = brandID }, new JsonMediaTypeFormatter())
            };

        }
        [Route("api/Put")]
        [HttpPost]
        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody] Brand brand)
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
                Content = new ObjectContent<string>("Updated Successfully....", new JsonMediaTypeFormatter())
            };

        }

        [Route("api/Delete")]
        // DELETE api/<controller>/5
        [HttpPost]
        public HttpResponseMessage Delete(dynamic body)
        {
            var parameters = new SqlParameter[]
               {
                    new SqlParameter("@nBrandId", body.nBrandId),
                    new SqlParameter("@nUserID", body.nUserID)
               };
            DBHelper.ExecuteNonQuery("SprocBrandDelete", parameters);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<string>("Deleted Successfully....", new JsonMediaTypeFormatter())
            };


        }
    }
}