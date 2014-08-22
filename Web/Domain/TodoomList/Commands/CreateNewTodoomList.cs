using System;
using System.Collections.Generic;
using d60.Cirqus.Commands;

namespace Web.Model.TodoomList.Commands
{
    public class CreateNewTodoomList : Command<TodoomListRoot>
    {
        public CreateNewTodoomList(Guid aggregateRootId) : base(aggregateRootId)
        {
        }

        public string Title { get; set; }

        public List<string> Bullets { get; set; }

        public override void Execute(TodoomListRoot aggregateRoot)
        {
            aggregateRoot.SetTitle(Title);
            
            Bullets.ForEach(aggregateRoot.AddBullet);
        }
    }
}