namespace Fanex.NAP.SPU.FS.BSNG.Tests.Shares
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using FluentAssertions;
    using Xunit;

    public class XmlHelperTests
    {
        [XName("Person")]
        private class Person
        {
            public int Id { get; set; }

            [XName("FullName")]
            public string Name { get; set; }

            [XmlIgnore]
            public string Ignored { get; set; }

            public Address Address { get; set; }
        }

        [XName("Addr")]
        private class Address
        {
            public string Street { get; set; }
        }       

        [Fact]
        public void ToXmlObj_Composites_Are_Elements()
        {
            var person = new Person
            {
                Id = 2,
                Name = "Bob",
                Address = new Address { Street = "Main" }
            };

            var xml = person.ToXmlObj();

            // Parent element with attributes
            xml.Name.LocalName.Should().Be("Person");
            xml.Attribute("Id").Value.Should().Be("2");
            xml.Attribute("FullName").Value.Should().Be("Bob");

            // Composite property rendered as child element with attributes
            var addr = xml.Elements().Single();
            addr.Name.LocalName.Should().Be("Addr");
            addr.Attribute("Street").Value.Should().Be("Main");
        }
      
    }
}


