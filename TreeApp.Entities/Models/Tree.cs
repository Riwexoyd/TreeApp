using System;

namespace TreeApp.Entities.Models
{
    public sealed class Tree : IEntity
    {
        public Guid Id { get; set; }

        public User Owner { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsPublic { get; set; }

        public string Title { get; set; }
    }
}
