﻿using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Desktop.Models;
using EMS.Desktop.Exceptions;

namespace EMS.Desktop.Services
{
    public class DBRepository :/* IRepository, */IDisposable
    {
        public static EMSEntities db;

        #region Getters
        public int? GetNextFileId()
        {
            if (db.File.ToList().Count == 0)
                return null;
            return db.File.Max(f => f.Id) + 1;
        }

        public List<Report210.ReportData> FilterParams(List<Report210.ReportData> list, FilterParams _params)
        {
            if(_params.HomesteadId != null && _params.HomesteadId.Count != 0)
            {
                list = list.Where(r => _params.HomesteadId.Any(h => h == r.Id)).ToList();
            }
            if(_params.ServiceId != null && _params.ServiceId.Count != 0)
            {
                list = list.Where(r => _params.ServiceId.Any(s => s == r.ServiceId)).ToList();
            }
            if(_params.FromDate != null && _params.ToDate != null)
            {
                if(_params.FromDate.Date <= _params.ToDate.Date)
                {
                    list = list.Where(r => r.Date.Date >= _params.FromDate.Date &&
                                           r.Date.Date <= _params.ToDate.Date).ToList();
                }
            }
            return list;
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
            catch(Exception ex)
            {

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

        public Homestead GetHomestead(int Id)
        {
            try
            {
                return db.Homestead.Where(h => h.Id == Id).First();
            }
            catch (InvalidOperationException)
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

        public List<Rate> GetLastRates()
        {
            int? lastNumber = GetLastRateNumber();
            return db.Rate.Where(r => r.Number == lastNumber).OrderBy(r => r.Id).ToList();
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
        }

        public List<Payment> GetPayment()
        {
            return db.Payment.ToList();
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
        }

        public int? GetLastRateNumber()
        {
            return db.Rate.Max(r => r.Number);
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
            try
            {
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
                    currentPayment.Entered = data.Entered;
                    currentPayment.IdService = data.ServiceId;
                    currentPayment.IdFile = report.FileId;
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
                            meterData.Value = info.newValue;
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
        }

        #endregion
    }
}
