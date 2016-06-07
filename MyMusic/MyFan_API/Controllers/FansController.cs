﻿using System;
using System.Net.Http;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/fans")]
    public class FansController : ApiController
    {
        [Route("")]
        [HttpPost]
        // api/v1/users/fans POST
        public IHttpActionResult CreateFan(HttpRequestMessage request)
        {
            string RequestBody = request.Content.ReadAsStringAsync().Result;

            System.Diagnostics.Debug.WriteLine(RequestBody);
            //return new clsFanResult(Request);
            //Endpoint for creating a new fan user
            throw new NotImplementedException();
        }



        [Route("")]
        [HttpGet]
        // api/v1/users/fans?q=form GET
        public IHttpActionResult GetAllFans(string q)
        {
            if (String.Equals(q, "form"))
            {
                /*FacadeBL facade = new FacadeBL();

                string ResponseBody = facade.getFanForm();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(ResponseBody);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                return response;*/

                return new GetForm(Request);
            }
            //Endpoint for retrieving all fans
            throw new NotImplementedException();
        }

        [Route("{fanId}")]
        [HttpGet]
        // api/v1/users/fans/1 GET
        public IHttpActionResult GetOneFan(int fanId)
        {


            //Endpoint for retrieving one fan
            throw new NotImplementedException();
        }

        [Route("{fanId}")]
        [HttpPut]
        // api/v1/users/fans/1 PUT
        public IHttpActionResult UpdateOneFan(int fanId)
        {
            //Endpoint for updating one fan
            throw new NotImplementedException();
        }

        [Route("{fanId}")]
        [HttpDelete]
        // api/v1/users/fans/1 DELETE
        public IHttpActionResult DeleteOneFan(int fanId)
        {
            //Endpoint for deleting one fan
            throw new NotImplementedException();
        }

    }
}
