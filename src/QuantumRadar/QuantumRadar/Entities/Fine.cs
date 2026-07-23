using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumRadar.Entities
{
    public class Fine
    {
        public string PlateNumber { get; init; } = string.Empty;
        public IReadOnlyList<Violation> Violations { get; init; } = [];
        public decimal TotalAmount
        {
            get
            {
                decimal total = 0;

                foreach (var violation in Violations)
                {
                    total += violation.Fee;
                }

                return total;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.AppendLine($"Traffic for car {PlateNumber}");
            builder.AppendLine($"Total amount: {TotalAmount} EGP");
            builder.AppendLine("Violations:");

            foreach (var violation in Violations)
            {
                builder.AppendLine($"- {violation.Description} : {violation.Fee} EGP");
            }

            return builder.ToString();
        }
    }
}
