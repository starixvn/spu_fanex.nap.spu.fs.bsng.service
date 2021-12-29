namespace Fanex.NAP.SPU.FS.BSNG.Features.FraudCase
{
    using Fanex.Data;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase.Criteria;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase.Entities;

    public interface IFraudCaseDataAccess
    {
        FraudCaseEntity GetFraudCaseById(int fraudCaseId, int environment);
    }

    public class FraudCaseDataAccess : IFraudCaseDataAccess
    {
        public FraudCaseEntity GetFraudCaseById(int fraudCaseId, int environment)
        {
            var criteria = new GetFraudCaseCriteria
            {
                FraudCaseId = fraudCaseId,
                Environment = environment
            };

            using (var db = ObjectDbFactory.CreateInstance(criteria.GetSettingKey()))
            {
                return db.QueryEntity<FraudCaseEntity>(criteria);
            }
        }
    }
}
