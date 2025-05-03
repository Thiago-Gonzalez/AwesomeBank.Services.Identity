using AwesomeBank.Services.Identity.Domain.Events;

namespace AwesomeBank.Services.Identity.Domain.Entities
{
    public class AggregateRoot : BaseEntity
    {
        public AggregateRoot()
            : base() { }

        private List<IDomainEvent> _events = [];
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event) => _events.Add(@event);
    }
}
