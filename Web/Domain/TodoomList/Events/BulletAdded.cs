using d60.Cirqus.Events;

namespace Web.Model.TodoomList.Events
{
    public class BulletAdded : DomainEvent<TodoomListRoot>
    {
        public string Text { get; set; }
    }
}