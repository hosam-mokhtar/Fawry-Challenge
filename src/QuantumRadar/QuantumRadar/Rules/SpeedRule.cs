using System;
using System.Collections.Generic;
using System.Text;
using QuantumRadar.Abstractions;
using QuantumRadar.Entities;
using QuantumRadar.Entities.Enums;

namespace QuantumRadar.Rules
{
    public class SpeedRule : IRule
    {
        public Violation? Check(Observation observation)
        {
            int maxSpeed = observation.CarType switch
            {
                CarType.Private => 80,
                CarType.Truck => 60,
                CarType.Bus => 80,
                _ => throw new ArgumentOutOfRangeException(nameof(observation.CarType))
            };

            if (observation.Speed <= maxSpeed)
                return null;

            return new Violation(ViolationType.Speed,
                                 $"speed of {observation.Speed} exceeded max allowed {maxSpeed}",
                                 300);
        }
    }
}
