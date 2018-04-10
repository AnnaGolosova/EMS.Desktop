using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Desktop.Models;
using EMS.Desktop.Exceptions;

namespace EMS.Desktop.Services
{
    public class DBRepository : IDisposable
    {
        public static EMSEntities db;

        #region Getters
        public int GetNextFileId()
        {
            if (db.File.Count() == 0)
                return 1;
            return db.File.Max(f => f.Id) + 1;
        }

        public List<Report210.ReportData> FilterParams(List<Report210.ReportData> list, FilterParams _params, bool useDate = true)
        {
            if (_params.HomesteadId != null && _params.HomesteadId.Count != 0)
            {
                list = list.Where(r => _params.HomesteadId.Any(h => h == r.Id)).ToList();
            }
            if(_params.ServiceId != null && _params.ServiceId.Count != 0)
            {
                list = list.Where(r => _params.ServiceId.Any(s => s == r.ServiceId)).ToList();
            }
            if(useDate && _params.FromDate != null && _params.ToDate != null)
            {
                if(_params.FromDate.Date <= _params.ToDate.Date)
                {
                    list = list.Where(r => r.Date.Date >= _params.FromDate.Date &&
                                           r.Date.Date <= _params.ToDate.Date).ToList();
                }
            }
            return list;
        }

        public List<Payment> FilterParams(List<Payment> list, FilterParams _params)
        {

            if (_params.HomesteadId != null && _params.HomesteadId.Count != 0)
            {
                list = list.Where(r => _params.HomesteadId.Any(h => h == r.Id)).ToList();
            }
            if (_params.ServiceId != null && _params.ServiceId.Count != 0)
            {
                list = list.Where(r => _params.ServiceId.Any(s => s == r.IdService)).ToList();
            }
            if (_params.FromDate != null && _params.ToDate != null)
            {
                if (_params.FromDate.Date <= _params.ToDate.Date)
                {
                    list = list.Where(r => r.Date.Value.Date >= _params.FromDate.Date &&
                                           r.Date.Value.Date <= _params.ToDate.Date).ToList();
                }
            }
            return list;
        }

        public static Homestead AddHomestead(int t, string text)
        {
            Homestead h = new Homestead() { Number = t, OwnerName = text };
            db.Homestead.Add(h);
            db.SaveChanges();

            Meter m = new Meter() { IdHomestead = h.Id, MeterNumber = 1 };
            db.Meter.Add(m);
            db.SaveChanges();

            return h;
        }

        public static void AddStartValues(int homesteadId, List<int> serviceList, double meterDataValue, int meterId)
        {
            foreach(int i in serviceList)
            {
                Payment newPayment = new Payment()
                {
                    Arrear = 0,
                    Date = DateTime.Now,
                    Entered = 0,
                    IdFile = 1,
                    IdService = i,
                    Introduced = 0,
                    IdHomestead = homesteadId,
                    PackageNumber = 1
                };
                db.Payment.Add(newPayment);
                db.SaveChanges();
                if(i == 2)
                {
                    MeterData meterData = new MeterData()
                    {
                        Id_Payment = newPayment.Id,
                        Date = DateTime.Now,
                        IdMeter = meterId,
                        NewValue = meterDataValue,
                        OldValue = 0,
                    };
                    db.MeterData.Add(meterData);
                    db.SaveChanges();
                }
            }
        }

        public double GetAmount()
        {
            try
            {
                //var amount = db.Database.SqlQuery<int>("GetAmount", DateTime.Now.Month, DateTime.Now.Year);
                var amount = db.Database.SqlQuery<double>($"DECLARE @s float(53) = cast(EMS.dbo.GetAmount({9}, {2017}) as float(53)) select @s").First();
                return amount;
            }
            catch(InvalidOperationException)
            {
                return 0;
            }
        }

        public int? GetRatePosition(int? rateId)
        {
            Rate rate = GetRate(null, rateId);
            int rateNumber = (int)rate.Number;
            int firstRateId = db.Rate.Where(r => r.Number == rateNumber).OrderBy(r => r.Id).First().Id;
            return (int)rateId - firstRateId + 1;
        }

        public DBRepository()
        {
            try
            {
                if(db == null)
                {
                    return;
                }
                db.Dispose();
            }
            finally
            {
                db = new EMSEntities();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Copay> GetCopay()
        {
            return db.Copay.ToList();
        }

        public File FindOrAddFile(int? id, string filePath)
        {
            try
            {
                return db.File.Where(f => f.Id == id).First();
            }
            catch (InvalidOperationException)
            {
                File file = new File() { Date = DateTime.Now, Path = filePath };
                db.File.Add(file);
                db.SaveChanges();
                return file;
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }

        }

        public List<File> GetFiles()
        {
            try
            {
                return db.File.ToList();
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public List<File> GetFiles(DateTime date)
        {
            try
            {
                return db.File.Where(f => f.Date.Value != null &&
                                      f.Date.Value.ToLongDateString().CompareTo(date.ToShortDateString()) == 0)
                                      .ToList();
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static bool TryConnection()
        {
            return db.Database.Exists();
        }

        internal void ChangeMeterData(int id, int? rateId)
        {
            MeterData md = db.MeterData.Where(m => m.Id == id).First();
            md.Id_Rate = rateId;
            db.SaveChanges();
        }

        internal void SetArrear(int id, double arrear)
        {
            Payment pay = db.Payment.Where(p => p.Id == id).First();
            pay.Arrear = arrear;
            db.SaveChanges();
        }

        public static List<Homestead> GetHomestead()
        {
            return db.Homestead.ToList();
        }

        public static Homestead GetHomestead(int HomesteadNumber)
        {
            try
            {
                return db.Homestead.Where(h => h.Number == HomesteadNumber).First();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
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
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public List<Rate> GetLastRates()
        {
            try
            {
                int? lastNumber = GetLastRateNumber();
                return db.Rate.Where(r => r.Number == lastNumber).OrderBy(r => r.Id).ToList();
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message);
            }
            catch(DataBaseException e)
            {
                throw new DataBaseException(e.Message);
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
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public Payment GetPayment(int Id)
        {
            return db.Payment.Where(p => p.Id == Id).First();
        }

        public List<MeterData> GetMeterData()
        {
            return db.MeterData.ToList();
        }

        //public List<MeterData> GetMeterData(string ownerName)
        //{
        //    return db.MeterData
        //        .Where(md => md.Meter.Homestead.OwnerName.CompareTo(ownerName) == 0)
        //        .ToList();
        //}

        public List<MeterData> GetMeterData(DateTime date)
        {
            return db.MeterData
                .Where(md => md.Date.Value != null &&
                       md.Date.Value.ToLongDateString().CompareTo(date.ToLongDateString()) == 0)
                .ToList();
        }

        public void ChangeRate(List<Rate> rates)
        {
            try
            {
                if (db.Rate.Count() == 0)
                    throw new InvalidOperationException();
                foreach(Rate rate in rates)
                {
                    Rate oldRate = db.Rate.Where(r => r.Id == rate.Id).First();
                    if(oldRate.Value != rate.Value)
                    {
                        throw new InvalidOperationException();
                    }
                }

            }
            catch(InvalidOperationException)
            {
                int newNumber = (GetLastRateNumber() ?? 0) + 1;
                foreach(Rate rate in rates)
                {
                    rate.Id = 0;
                    rate.Number = newNumber;
                    db.Rate.Add(rate);
                }
                db.SaveChanges();
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
            db.SaveChanges();
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
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public List<Payment> GetPayment()
        {
            try
            {
                return db.Payment.ToList();
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
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
            return db.Rate.AsNoTracking().ToList();
        }

        public Rate GetRate(int? number, int? id)
        {
            try
            {
                if(number != null)
                    return db.Rate
                        .Where(r => r.Number == (int)number)
                        .First();
                else
                    return db.Rate
                        .Where(r => r.Id == (int)id)
                        .First();

            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public int? GetLastRateNumber()
        {
            try
            {
                return db.Rate.Max(r => r.Number);
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message);
            }
        }

        public int? GetPreviousRateNumber()
        {
            if (GetLastRateNumber() == null)
                return null;
            int x = (int)GetLastRateNumber();
            List<Rate> lastRates = db.Rate.Where(r => r.Number == x).ToList();
            List<Rate> all = db.Rate.ToList().Except(lastRates).ToList();
            return db.Rate.ToList().Except(lastRates).Max(r => r.Number);
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
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
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
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static List<Payment> GetLastPayment()
        {
            int maxPackageNumber = db.Payment.Max(p => p.PackageNumber);
            return db.Payment.Where(p => p.PackageNumber == maxPackageNumber).OrderBy(p => p.Homestead.Number).OrderBy(p => p.Service.Id).ToList();
        }

        public static void ChangeArrear(int paymentId, double Arrear)
        {
            Payment payment = db.Payment.Where(p => p.Id == paymentId).First();
            payment.Arrear = Arrear;
            db.SaveChanges();
        }

        #endregion

        #region Setters
        public static int GetNextPackageNumber()
        {
            return db.Database.SqlQuery<int>("DECLARE	@return_value Int  = [dbo].[GetNextPackageNumber]() SELECT	@return_value").First();
        }

        public void LoadReport210(Report210 report)
        {
            try
            {
                int packageNumber = report.PackageNumber;
                foreach(Report210.ReportData data in report.Datas)
                {
                    Payment currentPayment = new Payment();
                    Homestead homestead = GetHomestead(data.HomeSteadNumber);
                    if (homestead == null)
                    {
                        homestead = new Homestead() { OwnerName = data.OwnerName, Number = data.HomeSteadNumber };
                        db.Homestead.Add(homestead);
                        db.SaveChanges();
                    }
                    currentPayment.IdHomestead = (int)homestead.Id;
                    
                    currentPayment.Date = data.Date;
                    currentPayment.Introduced = data.Introduced;
                    currentPayment.Arrear = data.Arrer;
                    currentPayment.Entered = data.Entered;
                    currentPayment.IdService = data.ServiceId;
                    currentPayment.IdFile = report.FileId;
                    currentPayment.PackageNumber = packageNumber;
                    db.Payment.Add(currentPayment);
                    db.SaveChanges();
                    if (data.meterInfo != null || data.meterInfo.Count != 0)
                    {
                        foreach (Report210.ReportData.MeterInfo info in data.meterInfo)
                        {
                            MeterData meterData = new MeterData();
                            Meter meter;
                            
                            try
                            {
                                meter = GetMeter().Where(m => m.IdHomestead == homestead.Id && m.MeterNumber == info.number).First();
                            }
                            catch (InvalidOperationException)
                            {
                                meter = null;
                            }
                            if (meter == null)
                            {
                                meter = new Meter();
                                meter.IdHomestead = (int)homestead.Id;
                                meter.MeterNumber = info.number;
                                db.Meter.Add(meter);
                                db.SaveChanges();
                            }

                            meterData.IdMeter = meter.Id;
                            meterData.NewValue = info.newValue;
                            meterData.OldValue = info.oldValue;
                            meterData.Date = data.Date;
                            meterData.Id_Payment = currentPayment.Id;
                            db.MeterData.Add(meterData);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch(InvalidCastException ex)
            {
                throw new DataBaseException("Упс, что-то пошло не так! Проверьте кодключение к базе данных.", ex);
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }


        public static List<Payment> GetMonthData(DateTime date, int serviceId)
        {
            List<Payment> list = new List<Payment>();
            foreach(Homestead h in db.Homestead)
            {
                try
                {
                    list.Add(db.Payment.Where( p => p.IdService == serviceId)
                        .Where(p => p.IdHomestead == h.Id)
                        .Where(p => p.Date.Value <= date)
                        .OrderByDescending(p => p.Date.Value).First());
                }
                catch (InvalidOperationException)
                {
                }
            }
            return list;
        }

        public static List<Report210.ReportData> Convert(List<Payment> data)
        {
            List<Report210.ReportData> list = new List<Report210.ReportData>();
            foreach (Payment pay in data)
            {
                Report210.ReportData rd = new Report210.ReportData();
                rd.Date = (DateTime)pay.Date;
                rd.Entered = pay.Entered;
                rd.Id = pay.Id;
                rd.Arrer = pay.Arrear;
                rd.Introduced = pay.Introduced;
                rd.OwnerName = GetHomestead((int)pay.Homestead.Number).OwnerName;
                rd.ServiceId = pay.IdService;
                rd.HomeSteadNumber = (int)GetHomestead((int)pay.Homestead.Number).Number;
                if (pay.MeterData.Count != 0)
                {
                    rd.meterInfo = new List<Report210.ReportData.MeterInfo>();
                    foreach (MeterData md in pay.MeterData)
                    {
                        rd.meterInfo.Add(new Report210.ReportData.MeterInfo()
                        {
                            newValue = md.NewValue,
                            oldValue = md.OldValue,
                            number = md.Meter.MeterNumber,
                            rateId = md.Id_Rate,
                            id = md.Id
                        });
                    }
                }
                list.Add(rd);
            }
            return list;
        }

        public List<Payment> GetPaymentByMonth(int month)
        {
            return db.Payment.Where(p => p.Date.Value.Month == month).ToList();
        }

        public File CreateFile(string path)
        {
            File file = new File() { Date = DateTime.Now, Path = path, Id = GetNextFileId() };
            db.File.Add(file);
            return file;
        }

        public void SetFileAsDownloaded(File file)
        {
            File f = db.File.Where(fl => fl.Id == file.Id).First();
            string fileName = file.Path.Split('\\').Last();
            string filePath = file.Path.Replace(fileName, "") + "Downloaded\\" + fileName;
            f.Path = filePath;
            db.SaveChanges();
        }

        public static void ChangeOwnerName(Homestead homestead)
        {
            Homestead h = GetHomestead(homestead.Number);
            h.OwnerName = homestead.OwnerName;
        }
        #endregion
    }
}
