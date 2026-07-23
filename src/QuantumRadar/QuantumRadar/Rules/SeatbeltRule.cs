using System;
using System.Collections.Generic;
using System.Text;
using QuantumRadar.Abstractions;
using QuantumRadar.Entities;
using QuantumRadar.Entities.Enums;

namespace QuantumRadar
{
    public class SeatbeltRule : IRule
    {
        public Violation? Check(Observation observation)
        {
            if (observation.SeatbeltFastened)
                return null;

            return new Violation(ViolationType.Seatbelt,
                                 "Seatbelt not fastened",
                                 100);
        }
    }
}
