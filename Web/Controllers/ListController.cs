using System.Collections.Generic;
using System.Web.Http;
using Web.Helpers;

namespace Web.Controllers
{
    [RoutePrefix("api/list")]
    public class ListController : ApiController
    {
        readonly SomeService _someService;

        public ListController(SomeService someService)
        {
            _someService = someService;
        }

        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "HEJ";
        }

        [HttpPost]
        [Route("new")]
        public void CreateNewList(CreateListForm form)
        {
        }
    }

    public class CreateListForm
    {
        public string Title { get; set; }

        public List<Bullet> Bullets { get; set; }

        public class Bullet
        {
            public string Text { get; set; }
        }
    }
}