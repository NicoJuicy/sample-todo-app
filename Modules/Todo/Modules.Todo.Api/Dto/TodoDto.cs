//Copyright 2020 - 2020  

namespace Modules.Todo.Api.Dto
{
    using System;

    /// <summary>
    /// Defines the <see cref="TodoDto" />.
    /// </summary>
    public class TodoDto
    {
        public string Description { get; set; }

        public DateTime? CompletedOn { get; set; }

        public Guid Id { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime On { get; set; }
    }
}
