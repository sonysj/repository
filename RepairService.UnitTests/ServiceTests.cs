using RepairService;

    [TestFixture]
    public class ServiceTests
    {
        private Service _service;
        private Device _device1;
        private Device _device2;

        [SetUp]
        public void Setup()
        {
            _service = new Service("Ремонт техники", "ул. Ленина, 1", "+79001234567");

            _device1 = new Device("Телевизор", "Samsung", "SN1")
            {
                TechnicianFullName = "Иванов И.И."
            };

            _device2 = new Device("Холодильник", "LG", "SN2")
            {
                TechnicianFullName = "Петров П.П."
            };
        }

        [Test]
        public void Service_Constructor_ShouldInitializeProperties()
        {
            Assert.That(_service.Name, Is.EqualTo("Ремонт техники"));
            Assert.That(_service.Address, Is.EqualTo("ул. Ленина, 1"));
            Assert.That(_service.Phone, Is.EqualTo("+79001234567"));
            Assert.That(_service.DeviceCount, Is.EqualTo(0));
        }

        [Test]
        public void AddDevice_ShouldAddUniqueDevice()
        {
            _service.AddDevice(_device1);
            _service.AddDevice(_device1);

            Assert.That(_service.DeviceCount, Is.EqualTo(1));
        }

        [Test]
        public void AddDevice_ShouldThrowWhenDeviceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _service.AddDevice(null));
        }

        [Test]
        public void RemoveDevice_ShouldRemoveDevice()
        {
            _service.AddDevice(_device1);
            _service.AddDevice(_device2);
            var result = _service.RemoveDevice(_device1);

            Assert.That(result, Is.True);
            Assert.That(_service.DeviceCount, Is.EqualTo(1));
        }

        [Test]
        public void RemoveDevice_ShouldReturnFalseWhenDeviceNotFound()
        {
            var result = _service.RemoveDevice(_device1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IEnumerable_ShouldAllowIteration()
        {
            _service.AddDevice(_device1);
            _service.AddDevice(_device2);

            int count = 0;
            foreach (var device in _service)
            {
                count++;
                Assert.That(device, Is.InstanceOf<Device>());
            }

            Assert.That(count, Is.EqualTo(2));
        }
    }