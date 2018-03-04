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
                db = new EMSEntities();
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
        #endregion

        #region Setters

        public void LoadReport210(Report210 report)
        {
            foreach(Report210.ReportData data in report.Datas)
            {
                if (data.meterInfo != null)
                {
                    foreach (Report210.ReportData.MeterInfo info in data.meterInfo)
                    {
                        try
                        {
                            Payment currentPayment = new Payment();
                            MeterData meterData = new MeterData();
                            Meter meter;

                            Homestead homestead = GetHomestead(data.HomeSteadNumber);
                            if (homestead == null)
                            {
                                homestead = new Homestead() { OwnerName = data.OwnerName, Number = data.HomeSteadNumber };
                                db.Homestead.Add(homestead);
                                db.SaveChanges();
                            }
                            currentPayment.IdHomestead = homestead.Number;

                            try
                            {
                                meter = GetMeter().Where(m => m.IdHomestead == homestead.Number && m.MeterNumber == info.number).First();
                            }
                            catch (InvalidOperationException)
                            {
                                meter = null;
                            }
                            if (meter == null)
                            {
                                meter = new Meter();
                                meter.IdHomestead = homestead.Number;
                                meter.MeterNumber = info.number;
                                db.Meter.Add(meter);
                                db.SaveChanges();
                            }

                            meterData.IdMeter = meter.Id;
                            meterData.Value = info.newValue;
                            meterData.Date = data.Date;

                            db.MeterData.Add(meterData);
                            db.SaveChanges();
                            currentPayment.IdMeterData = meterData.Id;

                            currentPayment.Date = data.Date;
                            currentPayment.Introduced = data.Introduced;
                            currentPayment.Entered = data.Entered;
                            currentPayment.IdService = data.ServiceId;

                            db.Payment.Add(currentPayment);
                            db.SaveChanges();
                        }
                        catch(InvalidCastException ex)
                        {
                            MessageBox.Show("Упс, что-то пошло не так! Проверьте кодключение к базе данных.");
                            //throw new DataBaseException(ex.Message, ex);
                        }
                    }
                }
                else
                {

                }
            }
        }

        #endregion
    }
}
