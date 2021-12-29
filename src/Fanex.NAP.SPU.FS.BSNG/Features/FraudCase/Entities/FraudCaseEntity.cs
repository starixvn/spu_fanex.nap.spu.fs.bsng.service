namespace Fanex.NAP.SPU.FS.BSNG.Features.FraudCase.Entities
{
    public class FraudCaseEntity
    {
        public int FraudCaseId { get; set; }

        public string FraudCaseName { get; set; }

        public string FraudCaseDesc { get; set; }
       
        public int FraudCaseInterval { get; set; }

        public bool IsActive { get; set; }

        public bool IsTest { get; set; }
    }
}
