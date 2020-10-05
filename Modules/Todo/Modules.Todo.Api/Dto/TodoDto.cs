//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Api.Dto
{
    using System;

    /// <summary>
    /// Defines the <see cref="TodoDto" />.
    /// </summary>
    public class TodoDto
    {
        public string Description { get; set; }

        public DateTime? FinishedOn { get; set; }

        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime On { get; set; }
    }
}
