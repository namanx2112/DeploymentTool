using DeploymentTool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace DeploymentTool.Helpers
{
    public class BrandDAL
    {
        public void Delete(int brandId, int userId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@nBrandId", brandId),
                new SqlParameter("@nUserID", userId)
            };
            DBHelper.ExecuteNonQuery("SprocBrandDelete", parameters);
        }
        public void Update(Brand brand)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@nBrandID", brand.aBrandId),
                new SqlParameter("@tBrandName", brand.tBrandName),
                new SqlParameter("@tBrandDescription", brand.tBrandDescription),
                new SqlParameter("@tBrandWebsite", brand.tBrandWebsite),
                new SqlParameter("@tBrandCountry", brand.tBrandCountry),
                new SqlParameter("@tBrandEstablished", brand.tBrandEstablished),
                new SqlParameter("@tBrandCategory", brand.tBrandCategory),
                new SqlParameter("@tBrandContact", brand.tBrandContact),
                new SqlParameter("@nBrandLogoAttachmentID", brand.nBrandLogoAttachmentID),
                new SqlParameter("@nUpdateBy", brand.nUpdateBy),
                new SqlParameter("@dtUpdatedOn", brand.dtUpdatedOn),
                new SqlParameter("@bDeleted", brand.bDeleted)
            };

            DBHelper.ExecuteNonQuery("sprocBrandUpdate", parameters);
        }
        public int CreateBrand(Brand brand, int nUserId)
        {
            int brandId = 0;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tBrandName", brand.tBrandName),
                    new SqlParameter("@tBrandDescription", brand.tBrandDescription),
                    new SqlParameter("@tBrandWebsite", brand.tBrandWebsite),
                    new SqlParameter("@tBrandCountry", brand.tBrandCountry),
                    new SqlParameter("@tBrandEstablished", brand.tBrandEstablished),
                    new SqlParameter("@tBrandCategory", brand.tBrandCategory),
                    new SqlParameter("@tBrandContact", brand.tBrandContact),
                    new SqlParameter("@nBrandLogoAttachmentID", brand.nBrandLogoAttachmentID),
                    new SqlParameter("@nUserId", nUserId)
                };
                SqlParameter[] outputParams = new SqlParameter[]
                {
            new SqlParameter("@nBrandID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            }
                };
                DBHelper.ExecuteProcedure<Brand>("sprocBrandCreate", reader =>
                {
                    brandId = reader.GetInt32(0);
                    return null;
                }, ref outputParams, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return brandId;
        }



        public Brand GetBrandById(int id)
        {
            return DBHelper.ExecuteProcedure<Brand>("sprocBrandGet", reader =>
            {
                var brand = new Brand();
                brand.aBrandId = reader["aBrandId"] == null ? -1 : (int)reader["aBrandId"];
                brand.tBrandName = reader["tBrandName"]?.ToString();
                brand.tBrandDescription = reader["tBrandDescription"]?.ToString();
                brand.tBrandWebsite = reader["tBrandWebsite"]?.ToString();
                brand.tBrandCountry = reader["tBrandCountry"]?.ToString();
                brand.tBrandEstablished = reader["tBrandEstablished"] is DBNull ? DateTime.MinValue : (DateTime)reader["dtCreatedOn"]; ;
                brand.tBrandCategory = reader["tBrandCategory"]?.ToString();
                brand.tBrandContact = reader["tBrandContact"]?.ToString();
                brand.nBrandLogoAttachmentID = reader["nBrandLogoAttachmentID"] is DBNull ? 0 : (int)reader["nBrandLogoAttachmentID"];
                brand.nCreatedBy = reader["nCreatedBy"] is DBNull ? 0 : (int)reader["nCreatedBy"];
                brand.nUpdateBy = reader["nUpdateBy"] is DBNull ? 0 : (int)reader["nUpdateBy"];
                brand.dtCreatedOn = reader["dtCreatedOn"] is DBNull ? DateTime.MinValue : (DateTime)reader["dtCreatedOn"];
                brand.dtUpdatedOn = reader["dtUpdatedOn"] is DBNull ? DateTime.MinValue : (DateTime)reader["dtUpdatedOn"];
                brand.bDeleted = (bool)reader["bDeleted"];
                return brand;
            }, new SqlParameter("@BrandId", id));
        }
        public List<Brand> GetBrands(int pageSize, int pageNumber)
        {
            var parameters = new SqlParameter[]
            {
            new SqlParameter("@nUserID", ""),
            new SqlParameter("@nPageSize", pageSize),
            new SqlParameter("@nPageNumber", pageNumber)
            };

            return DBHelper.ExecuteProcedure<List<Brand>>("sprocBrandGet", reader =>
            {
                var brands = new List<Brand>();

                while (reader.Read())
                {
                    var brand = new Brand();

                    brand.aBrandId = reader["aBrandId"] == null ? -1 : (int)reader["aBrandId"];
                    brand.tBrandName = reader["tBrandName"]?.ToString();
                    brand.tBrandDescription = reader["tBrandDescription"]?.ToString();
                    brand.tBrandWebsite = reader["tBrandWebsite"]?.ToString();
                    brand.tBrandCountry = reader["tBrandCountry"]?.ToString();
                    brand.tBrandEstablished = reader["tBrandEstablished"] is DBNull ? DateTime.MinValue : (DateTime)reader["dtCreatedOn"];
                    brand.tBrandCategory = reader["tBrandCategory"]?.ToString();
                    brand.tBrandContact = reader["tBrandContact"]?.ToString();
                    brand.nBrandLogoAttachmentID = reader["nBrandLogoAttachmentID"] is DBNull ? 0 : (int)reader["nBrandLogoAttachmentID"];
                    brand.nCreatedBy = reader["nCreatedBy"] is DBNull ? 0 : (int)reader["nCreatedBy"];
                    brand.nUpdateBy = reader["nUpdateBy"] is DBNull ? 0 : (int)reader["nUpdateBy"];
                    brand.dtCreatedOn = reader["dtCreatedOn"] is DBNull ? DateTime.MinValue : (DateTime)reader["dtCreatedOn"];
                    brand.dtUpdatedOn = reader["dtUpdatedOn"] is DBNull ? DateTime.MinValue : (DateTime)reader["dtUpdatedOn"];
                    brand.bDeleted = (bool)reader["bDeleted"];

                    brands.Add(brand);
                }

                return brands;
            }, parameters);
        }
    }
}