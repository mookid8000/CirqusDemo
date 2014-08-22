using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using d60.Cirqus;
using Web.Model.TodoomList.Commands;

namespace Web.Controllers
{
    [RoutePrefix("api/list")]
    public class ListController : ApiController
    {
        readonly ICommandProcessor _commandProcessor;

        public ListController(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpPost]
        [Route("new")]
        public void CreateNewList(CreateListForm form)
        {
            _commandProcessor.ProcessCommand(new CreateNewTodoomList(Guid.NewGuid())
            {
                Title = form.Title,
                Bullets = form.Bullets.Select(b => b.Text).ToList()
            });
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