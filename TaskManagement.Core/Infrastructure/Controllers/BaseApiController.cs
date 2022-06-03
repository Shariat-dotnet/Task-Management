using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

using TaskManagement.Core.Domains;
using TaskManagement.Core.Extensions;
using TaskManagement.Core.Implements.Http;


namespace TaskManagement.Core.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual IActionResult JsonResponse(Implements.Http.HttpResponse response, int statusCode = (int)HttpStatusCode.OK)
        {
            return StatusCode(statusCode, new { statusCode = response.StatusCode, response.Data, response.Paging, response.Message });
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void create_audit<G>(ref G model) where G : AuditableEntity
        {
            model.CreatedByUser= Guid.NewGuid();
            model.CreateDate = DateTime.Now;
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void update_audit<G>(ref G model) where G : AuditableEntity
        {
            model.UpdateDate = DateTime.Now;
            model.UpdatedByUser = Guid.NewGuid(); 
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void delete_audit<G>(ref G model) where G : AuditableEntity
        {
            model.DeleteDate = DateTime.Now;
            model.DeletedtedByUser = Guid.NewGuid();
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected G Deserialize<G>(string data)
        {
            if (data == null)
            {
                return JsonSerializer.Deserialize<G>("{}");
            }
            return JsonSerializer.Deserialize<G>(data);
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected string Serialize<G>(G data)
        {
            if (data != null)
            {
                return JsonSerializer.Serialize<G>(data);
            }
            else
            {
                return null;
            }

        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected string GetSesionString(string key)
        {
            var item = HttpAppContext.Current.Session.GetString(key);
            if (!string.IsNullOrWhiteSpace(item))
            {
                return item;
            }
            return "";
        }
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected G GetSesionObject<G>(string key)
        {
            var item = HttpAppContext.Current.Session.GetObject<G>(key);
            if (item != null)
            {
                return item;
            }
            return (G)Activator.CreateInstance(typeof(G));
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected List<G> GetSesionObjects<G>(string key)
        {
            var item = HttpAppContext.Current.Session.GetObject<List<G>>(key);
            if (item != null)
            {
                return item;
            }
            return (List<G>)Activator.CreateInstance(typeof(List<G>));
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void SetSesionString(string key, string value = null)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                HttpAppContext.Current.Session.SetString(key, "");
                HttpAppContext.Current.Session.SetString(key, value);
            }
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void SetSesionObject<G>(string key, G value)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                HttpAppContext.Current.Session.SetObject(key, "");
                HttpAppContext.Current.Session.SetObject(key, value);
            }
        }
        [NonAction]

        [ApiExplorerSettings(IgnoreApi = true)]
        protected void SetSesionObjects<G>(string key, List<G> value = null)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                HttpAppContext.Current.Session.SetObject(key, "");
                HttpAppContext.Current.Session.SetObject(key, value);
            }
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        protected string GetDefaultSession(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                //var r = HttpContext.Request.Current;
                var Queries = HttpAppContext.Current.Request.Query.Keys;
                if (Queries.Contains(key))
                {
                    var value = HttpContext.Request.Query[key].ToString();
                    HttpContext.Session.SetString(key, value);
                    return value;
                }

            }
            return "";
        }
    }
}
