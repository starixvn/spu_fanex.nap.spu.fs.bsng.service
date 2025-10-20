namespace Fanex.NAP.SPU.FS.BSNG.Tests.Features.FraudCase
{
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase.Entities;
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class FraudCaseServicesTests
    {
        private readonly IFraudCaseDataAccess fraudCaseDataAccess;
        private readonly FraudCaseServices services;

        public FraudCaseServicesTests()
        {
            fraudCaseDataAccess = Substitute.For<IFraudCaseDataAccess>();
            services = new FraudCaseServices(fraudCaseDataAccess);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CheckFraudCaseIsActive_Returns_IsActive_When_Entity_Exists(bool isActive)
        {
            var entity = new FraudCaseEntity { IsActive = isActive };
            fraudCaseDataAccess.GetFraudCaseById(Arg.Any<int>(), Arg.Any<int>()).Returns(entity);

            var result = services.CheckFraudCaseIsActive(123, 1);

            result.Should().Be(isActive);
            fraudCaseDataAccess.Received(1).GetFraudCaseById(123, 1);
        }

        [Fact]
        public void CheckFraudCaseIsActive_Returns_False_When_Entity_Is_Null()
        {
            fraudCaseDataAccess.GetFraudCaseById(Arg.Any<int>(), Arg.Any<int>()).Returns((FraudCaseEntity)null);

            var result = services.CheckFraudCaseIsActive(456, 2);

            result.Should().BeFalse();
            fraudCaseDataAccess.Received(1).GetFraudCaseById(456, 2);
        }
    }
}


