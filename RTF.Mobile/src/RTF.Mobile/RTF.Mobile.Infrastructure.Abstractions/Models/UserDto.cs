﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
