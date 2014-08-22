using System.Web.Http;

namespace Web.Controllers
{
    [RoutePrefix("api/main")]
    public class MainController : ApiController
    {
        [Route("index")]
        public object Get()
        {
            return new SomeResponse { Text = "hello from the server" };
        }

        class SomeResponse
        {
            public string Text { get; set; }
        }
    }
}