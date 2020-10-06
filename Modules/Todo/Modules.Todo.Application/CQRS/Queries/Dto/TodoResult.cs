//Copyright 2020 - 2020  

namespace Modules.Todo.Application.CQRS.Queries.Dto
{
    using System;

    /// <summary>
    /// Defines the <see cref="TodoResult" />.
    /// </summary>
    public class TodoResult
    {
        public string Description { get; set; }

        public Guid Id { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime On { get; set; }

        public DateTime? CompletedOn { get; set; }

    }
}
