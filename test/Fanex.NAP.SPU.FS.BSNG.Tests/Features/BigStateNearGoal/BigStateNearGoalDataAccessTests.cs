namespace Fanex.NAP.SPU.FS.BSNG.Tests.Features.BigStateNearGoal
{
    using System.Reflection;
    using Fanex.Data.Repository;
    using Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal;
    using Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal.Criteria;
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class BigStateNearGoalDataAccessTests
    {
        private static void InjectRepository(BigStateNearGoalDataAccess target, IDynamicRepository substitute)
        {
            var field = typeof(BigStateNearGoalDataAccess).GetField("repository", BindingFlags.Instance | BindingFlags.NonPublic);
            field.Should().NotBeNull("private field 'repository' must exist");
            field.SetValue(target, substitute);
        }

        [Theory]
        [InlineData("1,2,3", 0)]
        [InlineData("10", -100)]
        public void Rule_Should_Return_DataResult_With_Repository_ErrorCode(string matchIds, int errorCode)
        {
            var dataAccess = new BigStateNearGoalDataAccess();

            var repo = Substitute.For<IDynamicRepository>();
            repo.Execute(Arg.Is<BigStakeNearGoalRuleCriteria>(c => c.MatchIds == matchIds))
                .Returns(errorCode);

            InjectRepository(dataAccess, repo);

            DataResult result = dataAccess.Rule(matchIds);

            result.Should().NotBeNull();
            result.ErrorCode.Should().Be(errorCode);

            repo.Received(1).Execute(Arg.Is<BigStakeNearGoalRuleCriteria>(c => c.MatchIds == matchIds));
        }

        [Fact(Skip = "PreCondition depends on static ObjectDbFactory; would require integration test.")]
        public void PreCondition_Should_Return_Query_Results()
        {
            // Placeholder for potential integration test when database abstraction is injectable
        }
    }
}


