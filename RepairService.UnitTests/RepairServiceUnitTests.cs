using RepairService;

[TestFixture]
public class DeviceUnitTests
{
    [Test]
    public void ConstructorTest()
    {
        string name = "Телевизор";
        string manufacturer = "Samsung";
        string serialNumber = "SN123456";

        var device = new Device(name, manufacturer, serialNumber);

        Assert.That(device.Name, Is.EqualTo(name));
        Assert.That(device.Manufacturer, Is.EqualTo(manufacturer));
        Assert.That(device.SerialNumber, Is.EqualTo(serialNumber));
    }

    [Test]
    public void GetInfoTest()
    {
        var device = new Device("Телевизор", "Samsung", "SN123456")
        {
            RepairType = RepairType.Warranty,
            FaultDescription = "Не включается",
            RepairPrice = 0,
            TechnicianFullName = "Иванов И.И."
        };

        var info = device.GetInfo();

        Assert.That(info.Length, Is.EqualTo(2));
        Assert.That(info[0], Is.EqualTo("Устройство: Телевизор, Производитель: Samsung, " +
                                         "Серийный номер: SN123456, Тип ремонта: гарантийный"));
        Assert.That(info[1], Is.EqualTo("Описание неисправности: Не включается, " +
                                         "Цена ремонта: 0,00 C, Мастер: Иванов И.И."));
    }

}