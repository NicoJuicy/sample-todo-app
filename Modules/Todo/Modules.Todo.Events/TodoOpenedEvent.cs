//Copyright 2020 - 2020  

namespace Modules.Todo.Events
{
    using System;
    using BuildingBlock.Domain;
    using MediatR;

    /// <summary>
    /// Defines the <see cref="TodoOpenedEvent" />.
    /// </summary>
    public class TodoOpenedEvent : IDomainEvent, INotification
    {
        public TodoOpenedEvent(Guid noteId)
        {
            NoteId = noteId;
        }

        public Guid NoteId { get; private set; }
    }
}
