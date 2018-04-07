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
        public List<int?> HomesteadNumber;
        public string HomesteadOwnerName;
        public int ServicId;
        public int HomesteadNumbr;


        public FilterParams()
        {
            ServiceId = new List<int?>();
            HomesteadId = new List<int?>();
            HomesteadNumber = new List<int?>();
        }
    }
}
