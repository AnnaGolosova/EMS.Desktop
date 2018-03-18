using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Models
{
    public class Report210
    {
        public List<ReportData> Datas;
        public int FileId;

        public class ReportData
        {
            public int Id;
            public int ServiceId;
            public int HomeSteadNumber;
            public string OwnerName;
            public DateTime Date;
            public double Introduced; // Внесено пользователем
            public double Arrer; //Задолженность
            public double Entered; // Зачислено
            public string Code; //Строка, состоящая из даты платежа и абракадабры.
            public List<MeterInfo> meterInfo;

            //2~91~11.39~~~1~309~~399~90~2~10~~11~1
            //1~100~12.52~~~1~9145~~9245~100
            public class MeterInfo
            {
                public int number;
                public int? rateId;
                public double? oldValue;
                public double newValue;
                public int? id;
            }

        }

    }
}
