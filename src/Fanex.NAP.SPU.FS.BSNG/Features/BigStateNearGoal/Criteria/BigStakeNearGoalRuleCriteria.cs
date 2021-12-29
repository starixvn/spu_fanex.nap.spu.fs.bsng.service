namespace Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal.Criteria
{
    using Fanex.Data.Repository;

    public class BigStakeNearGoalRuleCriteria : NonQueryCommand
    {
        public string MatchIds { get; set; }

        public override string GetSettingKey()
        {
            return "FS_FraudCase_BSNG_Rule";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
