using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparer.Core.Constants;

namespace TarrifComparer.Core.Models
{
    public class BasicTarrif : ITarrifProduct
    {
        public string Name => Tarrif.BASIC_TARRIF;

        public double CalculateAnnualCost(int electricityConsumed)
        {
            var baseCostInEuros = GetYearlyBaseCost();
            var consumptionCostInEuros = GetConsumptionCostInEuros(electricityConsumed);

            return baseCostInEuros + consumptionCostInEuros;
        }

        private double GetConsumptionCostInEuros(int electricityConsumed)
        {
            var consumptionCostInCentPerKwHr = 22d;
            var consumptionCostInEuroPerKwHr = consumptionCostInCentPerKwHr / 100;

            return consumptionCostInEuroPerKwHr * electricityConsumed;
        }

        private int GetYearlyBaseCost()
        {
            var baseCostPerMonth = 5;

            return baseCostPerMonth * 12; // 12months
        }
    }
}
