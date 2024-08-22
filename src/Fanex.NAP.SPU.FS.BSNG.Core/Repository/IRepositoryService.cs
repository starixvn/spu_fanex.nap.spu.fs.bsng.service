using Fanex.Data.Repository;
using System.Collections.Generic;

namespace Fanex.NAP.SPU.FS.BSNG.Core.Repository
{
    public interface IRepositoryService
    {
        public int Execute(NonQueryCommand criteria, string serverIp = "");

        public IEnumerable<T> FetchResult<T>(CriteriaBase criteria, string serverIp = "");

        public (IEnumerable<T1>, IEnumerable<T2>) FetchResult<T1, T2>(CriteriaBase criteria, string serverIp = "");

        public (IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>) FetchResult<T1, T2, T3>(CriteriaBase criteria, string serverIp = "");

        public (IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>) FetchResult<T1, T2, T3, T4>(CriteriaBase criteria, string serverIp = "");

        public (IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>) FetchResult<T1, T2, T3, T4, T5>(CriteriaBase criteria, string serverIp = "");

        public (IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>) FetchResult<T1, T2, T3, T4, T5, T6>(CriteriaBase criteria, string serverIp = "");
    }
}
