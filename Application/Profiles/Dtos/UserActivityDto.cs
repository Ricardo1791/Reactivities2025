using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles.Dtos
{
    public class UserActivityDto
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
