using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Desktop.Models;
using System.Windows.Forms;
using EMS.Desktop.Exceptions;

namespace EMS.Desktop.Services
{
    public class DBRepository : IRepository, IDisposable
    {
        static EMSEntities db;

        #region Getters
        static DBRepository()
        {
            if (db == null)
            {
                db = new EMSEntities();
            }
        }

        public void Dispose()
        {
            db = null;
        }

        public List<Copay> GetCopay()
        {
            return db.Copay.ToList();
        }

        public File GetFile(int id)
        {
            try
            {
                return db.File.Where(f => f.Id == id).First();
            } catch(InvalidOperationException)
            {
                return null;
            }
            
        }

        public List<File> GetFiles()
        {
            return db.File.ToList();
        }

        public List<File> GetFiles(DateTime date)
        {
            return db.File.Where(f => f.Date.Value != null &&
                                      f.Date.Value.ToLongDateString().CompareTo(date.ToShortDateString()) == 0)
                                      .ToList();
        }

        public List<Homestead> GetHomestead()
        {
            return db.Homestead.ToList();
        }

        public Homestead GetHomestead(int number)
        {
            try
            {
                return db.Homestead.Where(h => h.Number == number).First();
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }

        public Homestead GetHomestead(string ownerName)
        {
            try
            {
                return db.Homestead
                    .Where(h => h.OwnerName.CompareTo(ownerName) == 0)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<Meter> GetMeter()
        {
            return db.Meter.ToList();
        }

        public Meter GetMeter(int id)
        {
            try
            {
                return db.Meter
                    .Where(m => m.Id == id)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<MeterData> GetMeterData()
        {
            return db.MeterData.ToList();
        }

        public List<MeterData> GetMeterData(string ownerName)
        {
            return db.MeterData
                .Where(md => md.Meter.Homestead.OwnerName.CompareTo(ownerName) == 0)
                .ToList();
        }

        public List<MeterData> GetMeterData(DateTime date)
        {
            return db.MeterData
                .Where(md => md.Date.Value != null &&
                       md.Date.Value.ToLongDateString().CompareTo(date.ToLongDateString()) == 0)
                .ToList();
        }

        public List<Report210.ReportData> GetDataForView()
        {
            List<Report210.ReportData> result = new List<Report210.ReportData>();
            result.Add(new Report210.ReportData()
            {
                HomeSteadNumber = 32,
                Introduced = 110,
                Arrer = 0,
                OwnerName = "sdfsdsf",
                ServiceId = 1,
                Date = DateTime.Now,
                Entered = 120,
                meterInfo = new List<Report210.ReportData.MeterInfo>()
                {
                    new Report210.ReportData.MeterInfo() { newValue = 15, number = 1, oldValue = 10},
                    new Report210.ReportData.MeterInfo() { newValue = 14, number = 2, oldValue = 9},
                }
            });
            result.Add(new Report210.ReportData()
            {
                HomeSteadNumber = 78,
                Introduced = 158,
                Arrer = 0,
                OwnerName = "sgsgg",
                ServiceId = 2,
                Date = DateTime.Now,
                Entered = 54,
                meterInfo = new List<Report210.ReportData.MeterInfo>()
                {
                    new Report210.ReportData.MeterInfo() { newValue = 15, number = 1, oldValue = 10},
                }
            });
            result.Add(new Report210.ReportData()
            {
                HomeSteadNumber = 12,
                Introduced = 110,
                Arrer = 0,
                OwnerName = "sfsefw",
                ServiceId = 2,
                Date = DateTime.Now,
                Entered = 90,
                meterInfo = new List<Report210.ReportData.MeterInfo>()
                {
                    new Report210.ReportData.MeterInfo() { newValue = 15, number = 1, oldValue = 10},
                    new Report210.ReportData.MeterInfo() { newValue = 15, number = 2, oldValue = 10},
                }
            });

            return result;
        }

        public List<MeterData> GetMeterData(int meterId)
        {
            return db.MeterData.Where(md => md.IdMeter == meterId)
                .ToList();
        }

        public int? GetMeterNumber(int id)
        {
            try
            {
                return db.Meter
                    .Where(m => m.Id == id)
                    .Select(m => m.MeterNumber)
                    .First();

            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<Payment> GetPayment()
        {
            return db.Payment.ToList();
        }

        public List<Payment> GetPayment(int meterId)
        {
            return db.Payment
                .Where(p => p.MeterData.IdMeter == meterId)
                .ToList();
        }

        public List<Payment> GetPayment(DateTime date)
        {
            return db.Payment
                .Where(p => p.Date.Value != null &&
                    p.Date.Value.ToLongDateString().CompareTo(date.ToLongDateString()) == 0)
                .ToList();
        }

        public List<Payment> GetPayment(DateTime date, int serviceId)
        {
            return db.Payment
                .Where(p => p.Date.Value != null &&
                    p.Date.Value.ToShortDateString().CompareTo(date.ToShortDateString()) == 0 &&
                    p.IdService == serviceId)
                .ToList();
        }

        public List<Payment> GetPaymentByFile(int fileId)
        {
            return db.Payment
                .Where(p => p.IdFile == fileId)
                .ToList();
        }

        public List<Rate> GetRate()
        {
            return db.Rate.ToList();
        }

        public Rate GetRate(int serviceId)
        {
            try
            {
                return db.Rate
                    .Where(r => r.IdService == serviceId)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<Service> GetService()
        {
            return db.Service.ToList();
        }

        public Service GetService(int serviceId)
        {
            try
            {
                return db.Service
                    .Where(s => s.Id == serviceId)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public Service GetService(string name)
        {
            try
            {
                return db.Service
                    .Where(s => s.Name.CompareTo(name) == 0)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public Homestead FindOrAddHomestead(int Number, string OwnerName = "")
        {
            using (db = new EMSEntities())
            {
                Homestead result;
                try
                {
                    result = db.Homestead.Where(h => h.Number == Number).First();
                }
                catch(InvalidOperationException)
                {
                    result = new Homestead() { Number = Number, OwnerName = OwnerName };
                    db.Homestead.Add(result);
                    db.Entry(result).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }
                return result;
            }
        }

        public Meter FindOrAddMeter(int homesteadId, int meterNumber = 1)
        {
            Meter meter = null;
            Homestead homestead = GetHomestead(homesteadId);
            if(homestead != null)
            {
                try
                {
                    meter = GetMeter().Where(m => m.IdHomestead == homestead.Number && m.MeterNumber == meterNumber).First();
                }
                catch (InvalidOperationException)
                {
                    meter = new Meter() { IdHomestead = homestead.Number, MeterNumber = meterNumber };
                    db.Meter.Add(meter);
                    db.SaveChanges();
                }
            }
            return meter;
        }

        #endregion

        #region Setters

        public static void LoadReport210(Report210 report)
        {
            //foreach(Report210.ReportData data in report.Datas)
            //{
            //    if (data.meterInfo != null)
            //    {
            //        foreach (Report210.ReportData.MeterInfo info in data.meterInfo)
            //        {
            //            try
            //            {
            //                Payment currentPayment = new Payment();
            //                MeterData meterData = new MeterData();

            //                Homestead homestead = FindOrAddHomestead(data.HomeSteadNumber, data.OwnerName);
            //                Meter meter = FindOrAddMeter(homestead.Number, info.number);

            //                meterData.IdMeter = meter.Id;
            //                meterData.Value = info.newValue;
            //                meterData.Date = data.Date;

            //                db.MeterData.Add(meterData);
            //                db.SaveChanges();

            //                currentPayment.IdMeterData = meterData.Id;

            //                currentPayment.Date = data.Date;
            //                currentPayment.Introduced = data.Introduced;
            //                currentPayment.Entered = data.Entered;
            //                currentPayment.IdService = data.ServiceId;

            //                db.Payment.Add(currentPayment);
            //                db.SaveChanges();
            //            }
            //            catch(InvalidCastException ex)
            //            {
            //                MessageBox.Show("Упс, что-то пошло не так! Проверьте кодключение к базе данных.");
            //                //throw new DataBaseException(ex.Message, ex);
            //            }
            //        }
            //    }
            //    else
            //    {

            //    }
            //}
        }

        #endregion
    }
}
