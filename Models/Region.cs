﻿using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public short CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
    }
}
