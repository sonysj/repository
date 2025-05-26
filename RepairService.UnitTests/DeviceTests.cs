using RepairService;

[TestFixture]
public class DeviceTests
{
    [Test]
    public void Device_CompareTo_ShouldSortByTechnicianThenByName()
    {
        var device1 = new Device("Телевизор", "Samsung", "SN1")
        {
            TechnicianFullName = "Иванов И.И."
        };

        var device2 = new Device("Холодильник", "LG", "SN2")
        {
            TechnicianFullName = "Петров П.П."
        };

        var device3 = new Device("Микроволновка", "Bosch", "SN3")
        {
            TechnicianFullName = "Иванов И.И."
        };

        var devices = new List<Device> { device1, device2, device3 };

        devices.Sort();

        Assert.That(devices[0], Is.EqualTo(device3));
        Assert.That(devices[1], Is.EqualTo(device1));
        Assert.That(devices[2], Is.EqualTo(device2));
    }
}