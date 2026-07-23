using System;
using System.Collections.Generic;
using System.Text;
using QuantumRadar.Entities.Enums;

namespace QuantumRadar.Entities
{
    public class Violation
    {
        public ViolationType Type { get; }
        public string Description { get; }
        public decimal Fee { get; }

        public Violation(ViolationType type, string description, decimal fee)
        {
            Type = type;
            Description = description;
            Fee = fee;
        }
    }
}
