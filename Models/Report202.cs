using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Models
{
    public class Report202
    {
        //Set Date field as null or _date value
        public  List<Rate> LocalRates;
        public List<ReportData> Datas;
        //?????????
        //Will we use it?
        public List<string> Descriptions;

        public class ReportData
        {

            #region fields
            public int ServiceId;
            public int HomeSteadNumber;
            public string OwnerName;
            public DateTime Date;
            public double Arrear;
            public double Introdused;
            public double Entered;
            public List<MeterInfo> meterInfo;
            #endregion

            public class MeterInfo
            {
                public int? LocalRateId;
                public double Value;
            }

            public ReportData()
            {
                meterInfo = new List<MeterInfo>();
            }
        }
    }
}
