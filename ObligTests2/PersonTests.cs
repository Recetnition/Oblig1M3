using NUnit.Framework;
using Oblig1;

namespace ObligTests2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var p = new Person();
            //Assert.Pass();
        }
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 1,
                FirstName = "Daniel",
                LastName = "Antonsen",
                BirthYear = 1993,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Daniel Antonsen (Id=1) Født: 1993";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

    }
}