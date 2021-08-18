using EMS.Desktop.Exceptions;
using EMS.Desktop.Helpers;
using EMS.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Desktop.Services
{
    public class DBRepository
    {

        #region Getters
        public static int GetNextFileId()
        {
            using (EMSEntities db = new EMSEntities())
            {
                if (db.File.Count() == 0)
                    return 1;
                return db.File.Max(f => f.Id) + 1;
            }
        }

        public static List<Report210.ReportData> FilterParams(List<Report210.ReportData> list, FilterParams _params, bool useDate = true)
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

        public static List<Payment> FilterParams(List<Payment> list, FilterParams _params)
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
                    list = list.Where(r => r.Date.Date >= _params.FromDate.Date &&
                                           r.Date.Date <= _params.ToDate.Date).ToList();
                }
            }
            return list;
        }

        public static Homestead AddHomestead(int number, string text)
        {
            using (EMSEntities db = new EMSEntities())
            {
                Homestead homestead = new Homestead() { Number = number, OwnerName = text };
                db.Homestead.Add(homestead);
                db.SaveChanges();

                Meter m = new Meter() { IdHomestead = homestead.Id, MeterNumber = 1 };
                db.Meter.Add(m);
                db.SaveChanges();

                return db.Homestead.IncludeRelaions().FirstOrDefault(h => h.Id == homestead.Id);
            }
        }

        public static void AddStartValues(int homesteadId, List<int> serviceList, double meterDataValue, int meterId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                foreach (int i in serviceList)
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
                    if (i == 2)
                    {
                        int rateId = GetRate(1).Id;
                        MeterData meterData = new MeterData()
                        {
                            IdPayment = newPayment.Id,
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
        }

        public static double GetAmount()
        {
            try
            {

                using (EMSEntities db = new EMSEntities())
                {
                    //var amount = db.Database.SqlQuery<int>("GetAmount", DateTime.Now.Month, DateTime.Now.Year);
                    var amount = db.Database.SqlQuery<double>($"DECLARE @s float(53) = cast(dbo.GetAmount({DateTime.Now.Month}, {DateTime.Now.Year}) as float(53)) select @s").First();
                    return amount;
                }
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public static int? GetRatePosition(int? rateId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                Rate rate = GetRate(null, rateId);
                int rateNumber = (int)rate.Number;
                int firstRateId = db.Rate.Where(r => r.Number == rateNumber).OrderBy(r => r.Id).First().Id;
                return (int)rateId - firstRateId + 1;
            }
        }

        public List<Copay> GetCopay()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Copay.ToList();
            }
        }

        public static File FindOrAddFile(int? id, string filePath)
        {
            using (EMSEntities db = new EMSEntities())
            {
                try
                {
                    return db.File.IncludeRelaions().Where(f => f.Id == id).First();
                }
                catch (InvalidOperationException)
                {
                    File file = new File() { Date = DateTime.Now, Path = filePath };
                    db.File.Add(file);
                    db.SaveChanges();
                    return db.File.IncludeRelaions().FirstOrDefault(f => f.Id == file.Id);
                }
                catch (System.Data.Entity.Core.EntityException e)
                {
                    throw new DataBaseException(e.Message, e);
                }
            }
        }

        public static List<File> GetFiles()
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.File.IncludeRelaions()
                        .ToList();
                }
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static List<File> GetFiles(DateTime date)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.File.IncludeRelaions().Where(f => f.Date.Value != null &&
                                      f.Date.Value.ToLongDateString().CompareTo(date.ToShortDateString()) == 0)
                                      .ToList();
                }
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static bool TryConnection()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Database.Exists();
            }
        }

        internal static void ChangeMeterRate(int idMeter, int rateId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                Meter m = db.Meter.Where(mm => mm.Id == idMeter).First();
                m.IdRate = rateId;
                db.SaveChanges();
            }
        }

        internal static void SetArrear(int id, double arrear)
        {
            using (EMSEntities db = new EMSEntities())
            {
                Payment pay = db.Payment.Where(p => p.Id == id).First();
                pay.Arrear = arrear;
                db.SaveChanges();
            }
        }

        public static List<Homestead> GetHomestead()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Homestead.IncludeRelaions().ToList();
            }
        }

        public static Homestead GetHomestead(int HomesteadNumber)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Homestead.IncludeRelaions().Where(h => h.Number == HomesteadNumber).FirstOrDefault();
                }
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static Homestead GetHomestead(string ownerName)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Homestead.IncludeRelaions()
                    .Where(h => h.OwnerName.CompareTo(ownerName) == 0)
                    .First();
                }
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

        public static List<Rate> GetLastRates()
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    int? lastNumber = GetLastRateNumber();
                    return db.Rate
                        .IncludeRelaions()
                        .Where(r => r.Number == lastNumber)
                        .OrderBy(r => r.Id)
                        .ToList();
                }
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
            catch(DataBaseException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static List<Meter> GetMeter()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Meter.IncludeRelaions().ToList();
            }
        }

        public static Meter GetMeter(int id)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Meter
                        .IncludeRelaions()
                        .Where(m => m.Id == id)
                        .First();
                }
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

        public static Payment GetPayment(int Id)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Payment.IncludeRelaions().Where(p => p.Id == Id).First();
            }
        }

        public static List<MeterData> GetMeterData()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.MeterData.IncludeRelaions().ToList();
            }
        }

        //public List<MeterData> GetMeterData(string ownerName)
        //{
        //    return db.MeterData
        //        .Where(md => md.Meter.Homestead.OwnerName.CompareTo(ownerName) == 0)
        //        .ToList();
        //}

        public static List<MeterData> GetMeterData(DateTime date)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.MeterData.IncludeRelaions()
                .Where(md => md.Date.Value != null &&
                       md.Date.Value.ToLongDateString().CompareTo(date.ToLongDateString()) == 0)
                .ToList();
            }
        }

        public static void ChangeRate(List<Rate> rates)
        {
            using (EMSEntities db = new EMSEntities())
            {
                try
                {
                    if (db.Rate.Count() == 0)
                        throw new InvalidOperationException();
                    foreach (Rate rate in rates)
                    {
                        Rate oldRate = db.Rate.Where(r => r.Id == rate.Id).First();
                        if (oldRate.Value != rate.Value)
                        {
                            throw new InvalidOperationException();
                        }
                    }

                }
                catch (InvalidOperationException)
                {
                    int newNumber = (GetLastRateNumber() ?? 0) + 1;
                    foreach (Rate rate in rates)
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
        }

        public static List<MeterData> GetMeterData(int meterId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.MeterData.IncludeRelaions().Where(md => md.IdMeter == meterId)
                .ToList();
            }
        }

        public static int? GetMeterNumber(int id)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Meter
                    .Where(m => m.Id == id)
                    .Select(m => m.MeterNumber)
                    .First();
                }
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

        public static List<Payment> GetPayment()
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Payment.IncludeRelaions().ToList();
                }
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }

        public static List<Payment> GetPayment(DateTime date)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Payment.IncludeRelaions()
                .Where(p => p.Date != null &&
                    p.Date.ToLongDateString().CompareTo(date.ToLongDateString()) == 0)
                .ToList();
            }
        }

        public static List<Payment> GetPayment(DateTime date, int serviceId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Payment.IncludeRelaions()
                .Where(p => p.Date != null &&
                    p.Date.ToShortDateString().CompareTo(date.ToShortDateString()) == 0 &&
                    p.IdService == serviceId)
                .ToList();
            }
        }

        public static List<Payment> GetPaymentByFile(int fileId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Payment.IncludeRelaions()
                .Where(p => p.IdFile == fileId)
                .ToList();
            }
        }

        public static List<Rate> GetRate()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Rate.IncludeRelaions().AsNoTracking().ToList();
            }
        }

        public static Rate GetRate(int position)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Rate.IncludeRelaions().OrderByDescending(r => r.Id).Take(3)
                .OrderBy(r => r.Id).ToList()[position - 1];
            }
        }

        public static Rate GetRate(int? number, int? id)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    if (number != null)
                    {
                        return db.Rate.IncludeRelaions()
                            .Where(r => r.Number == (int)number)
                            .First();
                    }
                    else
                    {
                        return db.Rate.IncludeRelaions()
                            .Where(r => r.Id == id)
                            .First();
                    }
                }
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

        public static int? GetLastRateNumber()
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Rate.Max(r => r.Number);
                }
            }
            catch(System.Data.Entity.Core.EntityException e)
            {
                throw new DataBaseException(e.Message);
            }
        }

        public static int? GetPreviousRateNumber()
        {
            using (EMSEntities db = new EMSEntities())
            {
                if (GetLastRateNumber() == null)
                    return null;
                int x = (int)GetLastRateNumber();
                List<Rate> lastRates = db.Rate.Where(r => r.Number == x).ToList();
                List<Rate> all = db.Rate.ToList().Except(lastRates).ToList();
                return db.Rate.ToList().Except(lastRates).Max(r => r.Number);
            }
        }

        public static List<Service> GetService()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Service.IncludeRelaions().ToList();
            }
        }

        public static Service GetService(int serviceId)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Service.IncludeRelaions()
                    .Where(s => s.Id == serviceId)
                    .First();
                }
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

        public static Service GetService(string name)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    return db.Service.IncludeRelaions()
                    .Where(s => s.Name.CompareTo(name) == 0)
                    .First();
                }
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
            using (EMSEntities db = new EMSEntities())
            {
                int maxPackageNumber = db.Payment.Max(p => p.PackageNumber);

                return db.Payment
                    .IncludeRelaions()
                    .Where(p => p.PackageNumber == maxPackageNumber)
                    .OrderBy(p => p.Homestead.Number)
                    .OrderBy(p => p.IdService).ToList();
            }
        }

        public static void ChangeArrear(int paymentId, double Arrear)
        {
            using (EMSEntities db = new EMSEntities())
            {
                Payment payment = db.Payment.Where(p => p.Id == paymentId).First();
                payment.Arrear = Arrear;
                db.SaveChanges();
            }
        }

        public static double PreviousArrear(Payment pay)
        {
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    List<Payment> pp = db.Payment.Where(p => p.IdHomestead == pay.IdHomestead && p.Date < pay.Date).OrderByDescending(p => p.Date).ToList();
                    return db.Payment.Where(p => p.IdHomestead == pay.IdHomestead && p.Date < pay.Date).OrderByDescending(p => p.Date).First().Arrear;
                }
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }
        #endregion

        #region Setters
        public static int GetNextPackageNumber()
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Database.SqlQuery<int>("DECLARE	@return_value Int  = [dbo].[GetNextPackageNumber]() SELECT	@return_value").First();
            }
        }

        public static void LoadReport210(Report210 report)
        {
            try
            {

                using (EMSEntities db = new EMSEntities())
                {
                    int packageNumber = report.PackageNumber;
                    foreach (Report210.ReportData data in report.Datas)
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
                        double tariff = ConfigAppManager.GetTariff();
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
                                    meter.IdRate = GetRate(1).Id;
                                    db.Meter.Add(meter);
                                    db.SaveChanges();
                                }
                                if (homestead.Number == 45)
                                {

                                }
                                meterData.IdMeter = meter.Id;
                                meterData.NewValue = info.newValue;
                                meterData.OldValue = info.oldValue;
                                meterData.Date = data.Date;
                                meterData.IdPayment = currentPayment.Id;
                                db.MeterData.Add(meterData);
                                db.SaveChanges();
                                currentPayment.Arrear = Math.Round((currentPayment.Introduced -
                                    Math.Round(data.meterInfo.Sum(m => m.newValue - m.oldValue) * ConfigAppManager.GetTariff(), 2) -
                                    Math.Round(data.meterInfo.Sum(m => m.newValue - m.oldValue) * ConfigAppManager.GetTariff() * (DBRepository.GetRate(null, meter.IdRate).Value), 2)) - PreviousArrear(currentPayment), 2);
                            }
                        }
                    }
                }
            }
            catch(InvalidCastException ex)
            {
                //MessageBox.Show("In DbRepository, LoadReport210 1");
                throw new DataBaseException("Упс, что-то пошло не так! Проверьте кодключение к базе данных.", ex);
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                //MessageBox.Show("In DbRepository, LoadReport210 2");
                throw new DataBaseException(e.Message, e);
            }
        }

        public static List<Payment> GetMonthData(DateTime date, int serviceId)
        {
            using (EMSEntities db = new EMSEntities())
            {
                List<Payment> list = new List<Payment>();

                IEnumerable<int> homesteadIds = db.Homestead.Select(h => h.Id).ToList();

                list.AddRange(db.Payment
                    .IncludeRelaions()
                    .Where(p => p.IdService == serviceId)
                    .Where(p => homesteadIds.Contains(p.IdHomestead))
                    .Where(p => p.Date <= date)
                    .OrderByDescending(p => p.Date));
                 
                return list;
            }
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
                            idMeter = md.IdMeter,
                            RateId = md.Meter.IdRate
                        });
                    }
                }
                list.Add(rd);
            }
            return list;
        }

        public static List<Payment> GetPaymentByMonth(int month, int year)
        {
            using (EMSEntities db = new EMSEntities())
            {
                return db.Payment
                    .IncludeRelaions()
                    .Where(p => p.Date.Month == month && p.Date.Year == year)
                    .ToList();
            }
        }

        public static File CreateFile(string path)
        {
            using (EMSEntities db = new EMSEntities())
            {
                File file = new File() { Date = DateTime.Now, Path = path, Id = GetNextFileId() };
                db.File.Add(file);
                db.SaveChanges();

                return db.File.IncludeRelaions()
                    .FirstOrDefault(f => f.Id == file.Id);
            }
        }

        public static void SetFileAsDownloaded(File file)
        {
            using (EMSEntities db = new EMSEntities())
            {
                File f = db.File.Where(fl => fl.Id == file.Id).First();
                string fileName = file.Path.Split('\\').Last();
                string filePath = file.Path.Replace(fileName, "") + "Downloaded\\" + fileName;
                f.Path = filePath;
                db.SaveChanges();
            }
        }

        public static void ChangeOwnerName(Homestead homestead)
        {
            using (EMSEntities db = new EMSEntities())
            {
                Homestead h = GetHomestead(homestead.Number);
                h.OwnerName = homestead.OwnerName;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
