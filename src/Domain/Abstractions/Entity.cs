using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        [NotMapped] // Tell EF Core to ignore domain events
        private readonly List<IDomainEvent> _domainEvents = new();  // for aggregate root to manage its events
        [NotMapped] // Also ignore this property
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();  // for application layer to access

        protected void Raise(IDomainEvent @event) => _domainEvents.Add(@event);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}