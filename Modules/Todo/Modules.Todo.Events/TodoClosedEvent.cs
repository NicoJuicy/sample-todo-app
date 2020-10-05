//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

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
