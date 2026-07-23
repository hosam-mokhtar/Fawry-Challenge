using System;
using System.Collections.Generic;
using System.Text;
using QuantumRadar.Entities;

namespace QuantumRadar.Abstractions
{
    public interface IRule
    {
        Violation? Check(Observation observation);
    }
}
