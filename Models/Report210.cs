using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Models
{
    public class Report210
    {
        public int Id;
        public int RateId;
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
            public int oldValue;
            public int newValue;
        }
    }
}
