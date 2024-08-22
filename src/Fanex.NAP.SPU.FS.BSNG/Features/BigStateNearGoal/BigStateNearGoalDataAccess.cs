namespace Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal
{
    using Fanex.NAP.SPU.FS.BSNG.Core.Repository;
    using Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal.Criteria;
    using Fanex.NAP.SPU.FS.BSNG.Shares;
    using System.Collections.Generic;

    public interface IBigStateNearGoalDataAccess
    {
        IEnumerable<T> PreCondition<T>();

        DataResult Rule(string matchIds);

    }

    public class BigStateNearGoalDataAccess : IBigStateNearGoalDataAccess
    {
        private readonly IRepositoryService _repository;

        public BigStateNearGoalDataAccess(IRepositoryService repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> PreCondition<T>()
        {
            var criteria = new BigStakeNearGoalPreconditionCriteria();

            return _repository.FetchResult<T>(criteria);
        }

        public DataResult Rule(string matchIds)
        {
            var criteria = new BigStakeNearGoalRuleCriteria
            {
                MatchIds = matchIds
            };

            var errorCode = _repository.Execute(criteria);

            return new DataResult
            {
                ErrorCode = errorCode
            };
        }
    }
}
