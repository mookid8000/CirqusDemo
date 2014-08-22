using System;
using System.Collections.Generic;
using d60.Cirqus.Extensions;
using d60.Cirqus.Views.ViewManagers;
using d60.Cirqus.Views.ViewManagers.Locators;
using Web.Model.TodoomList.Events;

namespace Web.Views
{
    public class ListOfTodoomListsView : IViewInstance<GlobalInstanceLocator>,
        ISubscribeTo<TitleAssigned>
    {
        public ListOfTodoomListsView()
        {
            TitlesById = new Dictionary<Guid, string>();
        }

        public string Id { get; set; }
        
        public long LastGlobalSequenceNumber { get; set; }

        public Dictionary<Guid, string> TitlesById { get; set; }

        public void Handle(IViewContext context, TitleAssigned domainEvent)
        {
            TitlesById[domainEvent.GetAggregateRootId()] = domainEvent.Title;
        }
    }
}