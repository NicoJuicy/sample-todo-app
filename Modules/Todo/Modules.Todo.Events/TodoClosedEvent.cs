//Copyright 2020 - 2020  

namespace Modules.Todo.Events
{
    using System;
    using BuildingBlock.Domain;
    using MediatR;

    /// <summary>
    /// Defines the <see cref="TodoClosedEvent" />.
    /// </summary>
    public class TodoClosedEvent : IDomainEvent, INotification
    {
        public TodoClosedEvent(Guid noteId)
        {
            NoteId = noteId;
        }

        public Guid NoteId { get; private set; }
    }
}
