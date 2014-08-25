using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using d60.Cirqus.MongoDb.Views;
using d60.Cirqus.Views.ViewManagers.Locators;
using Web.Views;

namespace Web.Controllers
{
    [RoutePrefix("api/main")]
    public class MainController : ApiController
    {
        readonly MongoDbViewManager<ListOfTodoomListsView> _listOfTodoomLists;

        public MainController(MongoDbViewManager<ListOfTodoomListsView> listOfTodoomLists)
        {
            _listOfTodoomLists = listOfTodoomLists;
        }

        [Route("index")]
        public ListOfTodoomLists Get()
        {
            var view = _listOfTodoomLists.Load(GlobalInstanceLocator.GetViewInstanceId());

            return new ListOfTodoomLists
            {
                Lists = view != null
                    ? view.TitlesById.Select(kvp => new TodoomList
                    {
                        Id = kvp.Key,
                        Title = kvp.Value
                    })
                        .ToList()
                    : new List<TodoomList>()
            };
        }

        public class ListOfTodoomLists
        {
            public List<TodoomList> Lists { get; set; }
        }

        public class TodoomList
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }
    }
}