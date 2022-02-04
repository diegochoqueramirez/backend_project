using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace online_store.Core.Models
{
    public class TodoTask
    {
        public Guid TaskId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public Guid CategoryId { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public Guid UserId { get; set; }
    }
}
