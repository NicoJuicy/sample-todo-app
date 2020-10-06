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

        public DateTime? FinishedOn { get; private set; }

        public bool IsActive { get; private set; } = true;

        public DateTime On { get; private set; }

        public static TodoAggregate Create(string description)
        {
            var note = new TodoAggregate();


            note.Description = description;
            return note;
        }

        public void Complete()
        {
            this.FinishedOn = DateTime.UtcNow;
            this.IsActive = false;
            this.AddEvent(new Events.TodoClosedEvent(this.Id));
        }

        public void Open()
        {
            this.FinishedOn = null;
            this.IsActive = true;
            this.AddEvent(new Events.TodoOpenedEvent(this.Id));
        }
    }
}
