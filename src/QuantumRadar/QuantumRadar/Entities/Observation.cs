using System;
using System.Collections.Generic;
using System.Text;
using QuantumRadar.Entities.Enums;

namespace QuantumRadar.Entities
{
    public record Observation(string PlateNumber,
                              DateTime Date,
                              CarType CarType,
                              int Speed,
                              bool SeatbeltFastened);
}
