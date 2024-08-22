namespace Fanex.NAP.SPU.FS.BSNG.Features.FraudCase
{
    using Fanex.NAP.SPU.FS.BSNG.Core.Repository;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase.Criteria;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase.Entities;
    using System.Linq;

    public interface IFraudCaseDataAccess
    {
        FraudCaseEntity GetFraudCaseById(int fraudCaseId, int environment);
    }

    public class FraudCaseDataAccess : IFraudCaseDataAccess
    {
        private readonly IRepositoryService _repository;

        public FraudCaseDataAccess(IRepositoryService repository)
        {
            _repository = repository;
        }

        public FraudCaseEntity GetFraudCaseById(int fraudCaseId, int environment)
        {
            var criteria = new GetFraudCaseCriteria
            {
                FraudCaseId = fraudCaseId,
                Environment = environment
            };

            return _repository.FetchResult<FraudCaseEntity>(criteria)?.FirstOrDefault();
        }
    }
}
