using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Photos
{
    public class ClodinarySettings
    {
        public required string CloudName { get; set; }
        public required string ApiKey { get; set; }
        public required string ApiSecret { get; set; }
    }
}
