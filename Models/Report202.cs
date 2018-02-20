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
        public  List<Rate> localRates;
        public List<ReportData> datas;
        //?????????
        //Will we use it?
        public List<string> descriptions;

        public class ReportData
        {
            #region fields
            int _rateId;
            int _hameSteadNumber;
            string _ownerName;
            DateTime _date;
            double _arrear; //задолжность
            public List<MeterInfo> meterInfo;
            #endregion

            #region propertioes
            public int RateId
            {
                get { return _rateId; }
                set { _rateId = value; }
            }
            public int HomeSteadNumber
            {
                get { return _hameSteadNumber; }
                set { _hameSteadNumber = value; }
            }
            public string OwnerName
            {
                get { return _ownerName; }
                set { _ownerName = value; }
            }
            public DateTime Date
            {
                get { return _date; }
                set { _date = value; }
            }
            public double Arrear
            {
                get { return _arrear; }
                set { _arrear = value; }
            }
            #endregion

            public class MeterInfo
            {
                public int LocalRateId;
                public double Value;
            }
        }

        //Example method
        public void Example()
        {
            Report202 rep = new Report202();
            rep.localRates = new List<Rate>()
            {
                new Rate{ Id = 1, IdService = 2, Value = 0.1246 },
                new Rate{ Id = 2, IdService = 2, Value = 0.1458 },
                new Rate{ Id = 3, IdService = 2, Value = 0.1549 }
            };

            rep.datas = new List<ReportData>();
            rep.datas.Add(new ReportData() {
                RateId = 2,
                Arrear = 0,
                Date = new DateTime(2017, 9, 1),
                HomeSteadNumber = 5,
                OwnerName = "Owner",
                meterInfo = new List<ReportData.MeterInfo>() {
                    new ReportData.MeterInfo() { LocalRateId = 1, Value = 458 },
                    new ReportData.MeterInfo() { LocalRateId = 1, Value = 4524 }
                }
            });
        }
    }
}
