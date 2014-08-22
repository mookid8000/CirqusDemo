using System.Collections.Generic;
using System.Web.Http;

namespace Web.Controllers
{
    [RoutePrefix("api/list")]
    public class ListController : ApiController
    {
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