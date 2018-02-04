using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Desktop.Models;

namespace EMS.Desktop.Services
{
    public class DBRepository : IRepository
    {
        static EMSEntities db;

        static DBRepository()
        {
            if (db == null)
                db = new EMSEntities();
        }

        public List<Copay> GetCopay()
        {
            return db.Copay.ToList();
        }

        public File GetFile(int id)
        {
            return db.File.Where(f => f.Id == id).FirstOrDefault();
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
            return db.Homestead.Where(h => h.Number == number).FirstOrDefault();
        }

        public Homestead GetHomestead(string ownerName)
        {
            return db.Homestead
                .Where(h => h.OwnerName.CompareTo(ownerName) == 0)
                .FirstOrDefault();
        }

        public List<Meter> GetMeter()
        {
            return db.Meter.ToList();
        }

        public Meter GetMeter(int id)
        {
            return db.Meter
                .Where(m => m.Id == id)
                .FirstOrDefault();
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

        public int GetMeterNumber(int id)
        {
            return db.Meter
                .Where(m => m.Id == id)
                .Select(m => m.MeterNumber)
                .FirstOrDefault();
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
            return db.Rate
                .Where(r => r.IdService == serviceId)
                .FirstOrDefault();
        }

        public List<Service> GetService()
        {
            return db.Service.ToList();
        }

        public Service GetService(int serviceId)
        {
            return db.Service
                .Where(s => s.Id == serviceId)
                .FirstOrDefault();
        }
    }
}
