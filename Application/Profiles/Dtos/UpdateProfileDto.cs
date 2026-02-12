using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles.Dtos
{
    public class UpdateProfileDto
    {
        public required string DisplayName { get; set; }
        public required string Bio { get; set; }
    }
}
