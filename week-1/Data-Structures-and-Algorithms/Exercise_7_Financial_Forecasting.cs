using System;

namespace DataStructuresAssignment
{
    public class ForecastingProgram
    {
        /// <summary>
        /// Recursive function to calculate the future value of an asset.
        /// Formula: Future Value = Present Value * (1 + Growth Rate)^Periods
        /// </summary>
        public static double CalculateFutureValue(double currentValue, double growthRate, int periods)
        {
            // Base Case: If no periods are left, the value remains unchanged
            if (periods <= 0)
                return currentValue;

            // Recursive Step: Apply growth for 1 period and recurse for the remaining periods
            return CalculateFutureValue(currentValue * (1 + growthRate), growthRate, periods - 1);
        }

        public static void Main(string[] args)
        {
            double initialInvestment = 10000.00; // 10,000 INR baseline
            double annualGrowthRate = 0.05;      // 5% constant annual growth
            int dynamicForecastYears = 5;         // 5-year forecast window

            Console.WriteLine("--- Executing Financial Forecasting Simulation Engine ---");
            Console.WriteLine($"Initial Capital: {initialInvestment:C}");
            Console.WriteLine($"Assumed Annual Growth: {annualGrowthRate * 100}%");
            Console.WriteLine($"Forecast Window: {dynamicForecastYears} Years");

            // Compute forecast natively via call stack recursion
            double projectedValue = CalculateFutureValue(initialInvestment, annualGrowthRate, dynamicForecastYears);

            Console.WriteLine("\n[SUCCESS] Computation complete.");
            Console.WriteLine($"Projected Asset Valuation: {projectedValue:C}");
        }
    }
}