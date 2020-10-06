//Copyright 2020 - 2020  

namespace Modules.Todo.Infrastructure.Documents
{
    using System;

    /// <summary>
    /// Create your db entity here.
    /// </summary>
    public class TodoDocument
    {
        public string Description { get; set; }

        public DateTime? CompletedOn { get; set; }

        public Guid Id { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime On { get; set; }
    }
}
