﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Models
{
    public class FilterParams
    {
        public DateTime FromDate;
        public DateTime ToDate;
        public List<int?> ServiceId;
        public List<int?> HomesteadId;

        public FilterParams()
        {
            ServiceId = new List<int?>();
            HomesteadId = new List<int?>();
        }
    }
}
