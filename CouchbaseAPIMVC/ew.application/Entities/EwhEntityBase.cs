using ew.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities
{
    public abstract class EwhEntityBase : IEwhEntityBase
    {
        public Exception EwhException { get; set; }
        public string EwhErrorMessage { get; set; }
        public GlobalStatus EwhStatus { get; set; }
        public ICollection<ValidationResult> ValidateResults = null;

        public int EwhCount { get; set; }


        protected void SyncStatus(EwhEntityBase d, EwhEntityBase s)
        {
            d.EwhStatus = s.EwhStatus;
            d.EwhErrorMessage= s.EwhErrorMessage;
            d.EwhException = s.EwhException;
            d.ValidateResults = s.ValidateResults;
            
        }
    }
}
