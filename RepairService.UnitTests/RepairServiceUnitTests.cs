using NUnit.Framework;
using RepairService;

namespace RepairService.UnitTests
{
    [TestFixture]
    public class DeviceUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var device = CreateTestDevice();
            Assert.That(device.Name, Is.EqualTo("Смартфон"));
            Assert.That(device.Manufacturer, Is.EqualTo("Samsung"));
            Assert.That(device.SerialNumber, Is.EqualTo("123456789"));
            Assert.That(device.RepairType, Is.EqualTo(RepairType.Paid));
            Assert.That(device.FaultDescription, Is.EqualTo("Неизвестная неисправность"));
            Assert.That(device.RepairPrice, Is.EqualTo(0.0m));
            Assert.That(device.TechnicianFullName, Is.EqualTo("Неизвестный мастер"));
        }

        [Test]
        public void GetInfoTest()
        {
            var device = CreateTestDevice();
            var info = device.GetInfo();

            var expectedRepairPrice = device.RepairPrice.ToString("C");
            var expectedInfo = $"Устройство: Смартфон, Производитель: Samsung, " +
                               $"Серийный номер: 123456789, Тип ремонта: оплачиваемый, " +
                               $"Описание неисправности: Неизвестная неисправность, " +
                               $"Цена ремонта: {expectedRepairPrice}, Мастер: Неизвестный мастер";

            Assert.That(info, Is.EqualTo(expectedInfo));
        }

        [Test]
        public void SetRepairDetailsTest()
        {
            var device = CreateTestDevice();
            device.SetRepairDetails(RepairType.Warranty, "Сломан экран", 150.0m, "Иван Иванов");

            Assert.That(device.RepairType, Is.EqualTo(RepairType.Warranty));
            Assert.That(device.FaultDescription, Is.EqualTo("Сломан экран"));
            Assert.That(device.RepairPrice, Is.EqualTo(150.0m));
            Assert.That(device.TechnicianFullName, Is.EqualTo("Иван Иванов"));
        }

        private Device CreateTestDevice()
        {
            return new Device("Смартфон", "Samsung", "123456789");
        }
    }
}