using System;
using RepairService;

namespace RepairService
{
    public class Device
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public readonly string SerialNumber;
        public RepairType RepairType = RepairType.Warranty;
        public string FaultDescription =  string.Empty;
        public decimal RepairPrice = 0.00m;
        public string TechnicianFullName = string.Empty;

        public Device(string name, string manufacturer, string serialNumber)
        {
            Name = name;
            Manufacturer = manufacturer;
            SerialNumber = serialNumber;
        }

        public virtual string[] GetInfo()
        {
            string repairTypeString = RepairType == RepairType.Warranty ? "гарантийный" : "оплачиваемый";
            var info = new string[2];

            info[0] = $"Устройство: {Name}, Производитель: {Manufacturer}, " +
                       $"Серийный номер: {SerialNumber}, Тип ремонта: {repairTypeString}";

            info[1] = $"Описание неисправности: {FaultDescription}, " +
                       $"Цена ремонта: {RepairPrice:0.00} C, Мастер: {TechnicianFullName}";

            return info;
        }
    }
}

public class Television : Device
{
    public int ScreenSize { get; set; }
    public string MatrixType { get; set; }
    public string BacklightType { get; set; }

    public Television(string name, string manufacturer, string serialNumber, int screenSize, string matrixType, string backlightType)
    : base(name, manufacturer, serialNumber)
    {
        ScreenSize = screenSize;
        MatrixType = matrixType;
        BacklightType = backlightType;
    }
    public override string[] GetInfo()
    {
        var info = new string[4];
        var deviceInfo = base.GetInfo();

        info[0] = deviceInfo[0];
        info[1] = deviceInfo[1];
        info[2] = $"Диагональ экрана: {ScreenSize} дюймов";
        info[3] = $"Тип матрицы: {MatrixType}. Тип подсветки: {BacklightType}.";

        return info;
    }
}

public class Refrigerator : Device
{
    public int NumberOfCompartments { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int Depth { get; set; }

    public Refrigerator(string name, string manufacturer, string serialNumber, int numberOfCompartments, int height, int width, int depth)
    : base(name, manufacturer, serialNumber)
    {
        NumberOfCompartments = numberOfCompartments;
        Height = height;
        Width = width;
        Depth = depth;
    }
    public override string[] GetInfo()
    {
        var info = new string[4];
        var deviceInfo = base.GetInfo();

        info[0] = deviceInfo[0];
        info[1] = deviceInfo[1];
        info[2] = $"Количество камер: {NumberOfCompartments}";
        info[3] = $"Высота: {Height} см, ширина: {Width} см, глубина: {Depth} см";

        return info;
    }
}