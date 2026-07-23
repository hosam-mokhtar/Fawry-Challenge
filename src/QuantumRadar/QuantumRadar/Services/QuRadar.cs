using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;
using System.Timers;
using System.Xml.Linq;
using QuantumRadar.Abstractions;
using QuantumRadar.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuantumRadar.Services
{
    /*
     * Quantum Radar System
     *
     * This system simulates a traffic radar that receives observations from a
     * physical radar. Each observation contains the vehicle's plate number,
     * observation date, car type, speed, and seatbelt status.
     *
     * Every observation is evaluated against a collection of independent traffic rules. 
     * A rule may generate a violation if its condition is not satisfied.
     * Multiple violations can be generated for the same observation.
     *
     * If one or more violations are detected, the system issues a traffic fine
     * containing all violations along with the fee for each violation.
     *
     * The system also provides:
     * - A list of all issued fines with each vehicle's plate number and total amount.
     * - A summary showing how many times each traffic rule has been violated.
     *
     * The design follows the SOLID principles and is easily extensible.
     * New traffic rules can be added by implementing the IRule interface
     * without modifying the QuRadar class.
     */

    public class QuRadar
    {
        private readonly IEnumerable<IRule> _rules;
        private readonly List<Fine> _fines = [];

        public QuRadar(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }

        public void Observe(Observation observation)
        {
            List<Violation> violations = [];

            foreach (var rule in _rules)
            {
                Violation? violation = rule.Check(observation);

                if (violation is not null)
                {
                    violations.Add(violation);
                }
            }

            if (!violations.Any())
                return;

            _fines.Add(new Fine
            {
                PlateNumber = observation.PlateNumber,
                Violations = violations
            });
        }

        public IEnumerable<(string PlateNumber, decimal TotalAmount)> GetAllPossibleFines()
        {
            foreach (var fine in _fines)
            {
                yield return (fine.PlateNumber, fine.TotalAmount);
            }
        }

        public Dictionary<Enum, int> GetViolatedRulesCount()
        {
            Dictionary<Enum, int> result = new();

            foreach (Fine fine in _fines)
            {
                foreach (Violation violation in fine.Violations)
                {
                    if (result.ContainsKey(violation.Type))
                        result[violation.Type]++;
                    else
                        result.Add(violation.Type, 1);
                }
            }

            return result;
        }
    }
}
