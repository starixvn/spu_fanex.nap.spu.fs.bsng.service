namespace Fanex.NAP.SPU.FS.BSNG.Tests.Shares
{
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using FluentAssertions;
    using Xunit;

    public class DataResultTests
    {
        [Fact]
        public void Defaults_Should_Be_Zero_And_Null()
        {
            var result = new DataResult();

            result.ErrorCode.Should().Be(0);
            result.ErrorMessage.Should().BeNull();
        }

        [Fact]
        public void Setters_Should_Assign_Values()
        {
            var result = new DataResult
            {
                ErrorCode = -100,
                ErrorMessage = "Failure"
            };

            result.ErrorCode.Should().Be(-100);
            result.ErrorMessage.Should().Be("Failure");
        }
    }
}


