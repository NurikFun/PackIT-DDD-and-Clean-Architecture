using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackIT.Shared.Abstractions.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new();

        private bool isIncremented;


        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !isIncremented)
            {
                Version++;
                _events.Add(@event);
                isIncremented = true;
            }
        }

        public void ClearEvents() => _events.Clear();


        protected void IncrementVersion()
        {
            if (isIncremented)
                return;

            Version++;
            isIncremented = true;
        }

    }
}
