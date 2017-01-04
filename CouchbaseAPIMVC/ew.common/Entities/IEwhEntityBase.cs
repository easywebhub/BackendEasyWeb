using ew.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.common.Entities
{
    public interface IEwhEntityBase
    {
        string EwhErrorMessage { get; set; }
        Exception EwhException { get; set; }
        GlobalStatus EwhStatus { get; set; }

        int EwhCount { get; set; }
    }
}
