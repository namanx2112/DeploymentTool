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
using DeploymentTool.Helpers;

namespace DeploymentTool.Controller
{
    public class BrandController : ApiController
    {

        [AllowAnonymous]
        // GET api/<controller>
        [HttpPost]
        [ActionName("GetBrands")]
        public HttpResponseMessage GetBrands([FromBody] Brand inputbrand)
        {
            var dal = new BrandDAL();
            var result = dal.GetBrands(inputbrand.nPageSize, inputbrand.nPageNumber);

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

            var brandDAL = new BrandDAL();
            var result = brandDAL.GetBrandById(id);

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
        [Route("api/Brand/CreateBrand")]
        // POST api/<controller>
        public HttpResponseMessage CreateBrand([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            int nuserid = 1;
            var brandDAL = new BrandDAL();
            int brandId = brandDAL.CreateBrand(brand, nuserid);
            brand.aBrandId = brandId;

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Brand>(brand, new JsonMediaTypeFormatter())
            };
        }









        [Authorize]
        [HttpPost]
        [Route("api/Brand/update")]
        // PUT api/<controller>/5
        public HttpResponseMessage Update([FromBody] Brand brand)
        {
            var context = HttpContext.Current.Request;
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var brandDAL = new BrandDAL();
            brandDAL.Update(brand);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Brand>(brand, new JsonMediaTypeFormatter())
            };

        }

        // DELETE api/<controller>/5

        [Authorize]
        [HttpPost]
        [Route("api/Brand/delete")]
        public HttpResponseMessage Delete(Brand brand)
        {
            var context = HttpContext.Current.Request;
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            int nUserid = 0;
            var brandDAL = new BrandDAL();
            brandDAL.Delete(brand.aBrandId, nUserid);

            return new HttpResponseMessage(HttpStatusCode.OK);


        }
    }
}