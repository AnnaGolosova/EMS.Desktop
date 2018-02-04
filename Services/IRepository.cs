using System;
using System.Collections.Generic;
using EMS.Desktop.Models;

namespace EMS.Desktop.Services
{
    interface IRepository
    {
        File GetFile(int Id);
        List<File> GetFiles(DateTime date);
        List<File> GetFiles();

        Homestead GetHomestead(string ownerName);
        Homestead GetHomestead(int number);
        List<Homestead> GetHomestead();

        int GetMeterNumber(int id);
        Meter GetMeter(int id);
        List<Meter> GetMeter();

        List<MeterData> GetMeterData(int meterId);
        List<MeterData> GetMeterData(DateTime date);
        List<MeterData> GetMeterData(string ownerName);
        List<MeterData> GetMeterData();

        List<Payment> GetPayment(DateTime date);
        List<Payment> GetPayment(DateTime date, int serviceId);
        List<Payment> GetPayment(int meterId);
        List<Payment> GetPaymentByFile(int fileId);
        List<Payment> GetPayment();

        List<Rate> GetRate();
        Rate GetRate(int serviceId);

        List<Service> GetService();
        Service GetService(int serviceId);

        List<Copay> GetCopay();
    }
}
