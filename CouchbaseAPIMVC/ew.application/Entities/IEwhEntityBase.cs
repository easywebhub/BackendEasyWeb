using System;
using ew.core.Enums;

namespace ew.application.Entities
{
    public interface IEwhEntityBase
    {
        string EwhErrorMessage { get; set; }
        Exception EwhException { get; set; }
        GlobalStatus EwhStatus { get; set; }

        int EwhCount { get; set; }
    }
}