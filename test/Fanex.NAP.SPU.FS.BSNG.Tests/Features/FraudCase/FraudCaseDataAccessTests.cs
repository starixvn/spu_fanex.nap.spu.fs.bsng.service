namespace Fanex.NAP.SPU.FS.BSNG.Tests.Features.FraudCase
{
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase;
    using Xunit;

    public class FraudCaseDataAccessTests
    {
        [Fact(Skip = "Depends on static ObjectDbFactory.CreateInstance; requires integration setup or refactor for DI.")]
        public void GetFraudCaseById_Should_Query_Entity_And_Return_Result()
        {
            var dataAccess = new FraudCaseDataAccess();

            var result = dataAccess.GetFraudCaseById(123, 1);

            Assert.NotNull(result);
        }
    }
}


