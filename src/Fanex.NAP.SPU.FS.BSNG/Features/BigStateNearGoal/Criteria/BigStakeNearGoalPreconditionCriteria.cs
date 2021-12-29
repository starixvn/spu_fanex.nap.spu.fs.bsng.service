namespace Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal.Criteria
{
    using Fanex.Data.Repository;

    public class BigStakeNearGoalPreconditionCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FS_FraudCase_BSNG_PreCondition";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
