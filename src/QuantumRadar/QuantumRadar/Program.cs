using System.Data;
using QuantumRadar.Abstractions;
using QuantumRadar.Entities;
using QuantumRadar.Entities.Enums;
using QuantumRadar.Rules;
using QuantumRadar.Services;

namespace QuantumRadar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRule> rules = [
                                  new SeatbeltRule(),
                                  new SpeedRule()
                                ];

            QuRadar radar = new(rules);

            List<Observation> observations =
                       [
                           new("ABC123", DateTime.Now, CarType.Private, 94, false),
                           new("EFG456", DateTime.Now, CarType.Truck, 40, false),
                           new("AAA111", DateTime.Now, CarType.Bus, 60, true),
                           new("BBB222", DateTime.Now, CarType.Private, 120, true)
                       ];

            foreach (Observation observation in observations)
            {
                radar.Observe(observation);
            }

            Console.WriteLine("==========================================");
            Console.WriteLine("                 All Fines                ");
            Console.WriteLine("==========================================");

            foreach (var fine in radar.GetAllPossibleFines())
            {
                Console.WriteLine($"Plate Number: {fine.PlateNumber}");
                Console.WriteLine($"Total Amount: {fine.TotalAmount:0.00} EGP");
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("==========================================");
            Console.WriteLine("          Violated Rules Count            ");
            Console.WriteLine("==========================================");

            var violatedRules = radar.GetViolatedRulesCount();

            foreach (var rule in violatedRules)
            {
                Console.WriteLine($"{rule.Key} : {rule.Value}");
            }
        }
    }
}
