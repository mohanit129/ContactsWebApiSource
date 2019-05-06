using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ContactsWebApi.Attribute
{
    public class EnableETagAttribute : ActionFilterAttribute
    {
        //This could be from a network source e.g database
        private static ConcurrentDictionary<string, EntityTagHeaderValue> _etTagHeaderValues =
        new ConcurrentDictionary<string, EntityTagHeaderValue>();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //Get the request
            var request = actionContext.Request;
            if (request.Method == HttpMethod.Get)
            {
                var key = GetKey(request);

                //Get if If-None match header
                var clientEtags = request.Headers.IfNoneMatch;

                if (clientEtags.Count > 0)
                {
                    EntityTagHeaderValue etag = null;
                    if (_etTagHeaderValues.TryGetValue(key, out etag) && clientEtags.Any(t => t.Tag == etag.Tag))
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotModified);
                        SetCacheControl(actionContext.Response);
                    }
                }
            }
        }

        private void SetCacheControl(HttpResponseMessage httpResponseMessage)
        {
            httpResponseMessage.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromSeconds(60),
                MustRevalidate = true,
                Private = true
            };
        }

        private string GetKey(HttpRequestMessage request)
        {
            return request.RequestUri.ToString();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var request = actionExecutedContext.Request;
            var key = GetKey(request);

            EntityTagHeaderValue entityTag;

            if (!_etTagHeaderValues.TryGetValue(key, out entityTag) || request.Method == HttpMethod.Post || request.Method == HttpMethod.Post)
            {
                entityTag = new EntityTagHeaderValue("\"" + Guid.NewGuid().ToString() + "\"");
                _etTagHeaderValues.AddOrUpdate(key, entityTag, (k, val) => entityTag);
            }

            actionExecutedContext.Response.Headers.ETag = entityTag;
            SetCacheControl(actionExecutedContext.Response);
        }
    }
}