using d60.Cirqus.Aggregates;
using d60.Cirqus.Events;
using Web.Model.TodoomList.Events;

namespace Web.Model.TodoomList
{
    public class TodoomListRoot : AggregateRoot,
        IEmit<TitleAssigned>,
        IEmit<BulletAdded>
    {
        public void SetTitle(string title)
        {
            Emit(new TitleAssigned { Title = title });
        }

        public void AddBullet(string text)
        {
            Emit(new BulletAdded { Text = text });
        }

        public void Apply(TitleAssigned e)
        {
        }

        public void Apply(BulletAdded e)
        {
        }
    }
}