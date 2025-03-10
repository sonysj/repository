using System;

namespace RepairService
{
    public class Device
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public readonly string SerialNumber;
        public RepairType RepairType;
        public string FaultDescription;
        public decimal RepairPrice;
        public string TechnicianFullName;

        public Device(string name, string manufacturer, string serialNumber)
        {
            Name = name;
            Manufacturer = manufacturer;
            SerialNumber = serialNumber;
            RepairType = RepairType.Paid;
            FaultDescription = "Неизвестная неисправность";
            RepairPrice = 0.0m;
            TechnicianFullName = "Неизвестный мастер";
        }

        public string GetInfo()
        {
            string repairTypeString;
            if (RepairType == RepairType.Warranty)
            {
                repairTypeString = "гарантийный";
            }
            else
            {
                repairTypeString = "оплачиваемый";
            }

            return $"Устройство: {Name}, Производитель: {Manufacturer}, " +
                   $"Серийный номер: {SerialNumber}, Тип ремонта: {repairTypeString}, " +
                   $"Описание неисправности: {FaultDescription}, " +
                   $"Цена ремонта: {RepairPrice:C}, Мастер: {TechnicianFullName}";
        }
        public void SetRepairDetails(RepairType repairType, string faultDescription, decimal repairPrice, string technicianFullName)
        {
            RepairType = repairType;
            FaultDescription = faultDescription;
            RepairPrice = repairPrice;
            TechnicianFullName = technicianFullName;
        }
    }
}