﻿using BusinessLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            System.Diagnostics.Debug.WriteLine("Creating new user");

            string Jsoncontent = request.Content.ReadAsStringAsync().Result;
            //return new clsFanResult(Request);
            //Endpoint for creating a new fan user
            throw new NotImplementedException();
        }

        class JSON
        {
            public int code { get; set; }
            public bool success { get; set; }
            public string data { get; set; }
        }



        [Route("")]
        [HttpGet]
        // api/v1/users/fans?q=form GET
        public HttpResponseMessage GetAllFans(string q)
        {
            System.Diagnostics.Debug.WriteLine(q);
            if (String.Equals(q, "form"))
            {

                /* JSON obj = new JSON();
                 obj.code = 200;
                 obj.success = true;
                 obj.data = new string[] { "Indie", "Rock", "Reggae", "Metal", "Techno", "House" };*/

                FacadeBL facade = new FacadeBL();

                string data = facade.getFanForm();

                JSON json = new JSON();
                json.code = 200;
                json.success = true;
                json.data = data;
             
                string r = JsonConvert.SerializeObject(json);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(r);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                


                return response;

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
