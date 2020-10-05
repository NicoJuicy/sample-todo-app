//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Infrastructure.Documents
{
    using System;

    /// <summary>
    /// Create your db entity here.
    /// </summary>
    public class TodoDocument
    {
        public string Description { get; set; }

        public DateTime? FinishedOn { get; set; }

        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime On { get; set; }
    }
}
