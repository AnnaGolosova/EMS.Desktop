using System;
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
        public List<int?> HomesteadNumber;
        public string HomesteadOwnerName;
        public int ServicId;
        public int HomesteadNumbr;
        public bool IsArear;
        public bool isBadReport; // Отобразить должников - тех, кто не платил за определенный период      

        public List<int> ServiceId;
        public List<int> HomesteadId;
        public List<string> HomesteadOwnName;

        public FilterParams()
        {
            ServiceId = new List<int>();
            HomesteadId = new List<int>();
            HomesteadNumber = new List<int?>();
            HomesteadOwnName = new List<string>();
        }
    }
}
