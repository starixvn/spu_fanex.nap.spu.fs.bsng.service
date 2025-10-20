namespace Fanex.NAP.SPU.FS.BSNG.Tests.Shares
{
    using System.Linq;
    using System.Reflection;
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using FluentAssertions;
    using Xunit;

    public class XNameAttributeTests
    {
        [XName("CustomClass")] 
        private class AnnotatedClass
        {
            [XName("CustomProp")] 
            public int Id { get; set; }

            public string Name { get; set; }
        }

        [Fact]
        public void Attribute_On_Class_Should_Expose_ElementName()
        {
            var attr = typeof(AnnotatedClass)
                .GetCustomAttributes(typeof(XNameAttribute), inherit: false)
                .Cast<XNameAttribute>()
                .SingleOrDefault();

            attr.Should().NotBeNull();
            attr.ElementName.Should().Be("CustomClass");
        }

        [Fact]
        public void Attribute_On_Property_Should_Expose_ElementName()
        {
            var prop = typeof(AnnotatedClass).GetProperty(nameof(AnnotatedClass.Id), BindingFlags.Public | BindingFlags.Instance);
            var attr = prop
                .GetCustomAttributes(typeof(XNameAttribute), inherit: false)
                .Cast<XNameAttribute>()
                .SingleOrDefault();

            attr.Should().NotBeNull();
            attr.ElementName.Should().Be("CustomProp");
        }

        [Fact]
        public void Attribute_Not_Present_Should_Return_Null()
        {
            var prop = typeof(AnnotatedClass).GetProperty(nameof(AnnotatedClass.Name), BindingFlags.Public | BindingFlags.Instance);
            var attr = prop
                .GetCustomAttributes(typeof(XNameAttribute), inherit: false)
                .Cast<XNameAttribute>()
                .SingleOrDefault();

            attr.Should().BeNull();
        }
    }
}


