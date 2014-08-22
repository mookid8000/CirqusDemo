using d60.Cirqus.Events;

namespace Web.Model.TodoomList.Events
{
    public class TitleAssigned : DomainEvent<TodoomListRoot>
    {
        public string Title { get; set; } 
    }
}