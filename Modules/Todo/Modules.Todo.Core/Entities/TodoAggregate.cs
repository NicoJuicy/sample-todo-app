//Copyright 2020 - 2020  

namespace Modules.Todo.Core.Entities
{
    using System;
    using System.Linq;
    using BuildingBlock.Domain.Aggregate;

    /// <summary>
    /// Defines the <see cref="TodoAggregate" />.
    /// </summary>
    public class TodoAggregate : AggregateRoot
    {
        private TodoAggregate()
        {
            Id = Guid.NewGuid();
            On = DateTime.UtcNow;
            this.Open();
        }

        public string Description { get; private set; }

        public DateTime? CompletedOn { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime On { get; private set; }

        public static TodoAggregate Create(string description)
        {
            var note = new TodoAggregate();

            note.Description = description;
            return note;
        }

        public void Complete()
        {
            this.CompletedOn = DateTime.UtcNow;
            this.IsCompleted = true;
            this.AddEvent(new Events.TodoClosedEvent(this.Id));
        }

        public void Open()
        {
            this.CompletedOn = null;
            this.IsCompleted = false;
            this.AddEvent(new Events.TodoOpenedEvent(this.Id));
        }
    }
}
