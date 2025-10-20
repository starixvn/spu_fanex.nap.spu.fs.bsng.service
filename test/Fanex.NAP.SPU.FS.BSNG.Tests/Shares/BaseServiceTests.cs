namespace Fanex.NAP.SPU.FS.BSNG.Tests.Shares
{
    using System.Linq;
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using FluentAssertions;
    using Xunit;

    public class BaseServiceTests
    {
        [Fact]
        public void Precondition_Should_Return_Same_Instance()
        {
            var service = new BaseService();

            var result = service.Precondition();

            result.Should().BeSameAs(service);
        }

        [Fact]
        public void Rule_Without_Args_Should_Return_Default_DataResult()
        {
            var service = new BaseService();

            var result = service.Rule();

            result.Should().NotBeNull();
            result.ErrorCode.Should().Be(0);
            result.ErrorMessage.Should().BeNull();
        }

        [Fact]
        public void Rule_With_ChunkSize_Should_Return_Default_DataResult()
        {
            var service = new BaseService();

            var result = service.Rule(100);

            result.Should().NotBeNull();
            result.ErrorCode.Should().Be(0);
            result.ErrorMessage.Should().BeNull();
        }

        [Fact]
        public void Rules_Without_Args_Should_Return_Empty()
        {
            var service = new BaseService();

            var results = service.Rules();

            results.Should().NotBeNull();
            results.Should().BeEmpty();
            results.Count().Should().Be(0);
        }

        [Fact]
        public void Rules_With_ChunkSize_Should_Return_Empty()
        {
            var service = new BaseService();

            var results = service.Rules(50);

            results.Should().NotBeNull();
            results.Should().BeEmpty();
            results.Count().Should().Be(0);
        }

        [Fact]
        public void CleanResult_Should_Return_Same_Instance()
        {
            var service = new BaseService();

            var result = service.CleanResult();

            result.Should().BeSameAs(service);
        }

        [Fact]
        public void GetFlaggedCustomer_Should_Return_Same_Instance()
        {
            var service = new BaseService();

            var result = service.GetFlaggedCustomer("http://api");

            result.Should().BeSameAs(service);
        }
    }
}


