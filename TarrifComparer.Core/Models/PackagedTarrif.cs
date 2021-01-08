using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparer.Core.Constants;

namespace TarrifComparer.Core.Models
{
    public class PackagedTarrif : ITarrifProduct
    {
        public string Name => Tarrif.PACKAGED_TARRIF;

        private const int BASE_CONSUMPTION_COST_IN_EUROS = 800;

        private const int BASE_CONSUMPTION_RATE = 4000;

        public double CalculateAnnualCost(int electricityConsumed)
        {
            if(electricityConsumed <= BASE_CONSUMPTION_RATE)
            {
                return BASE_CONSUMPTION_COST_IN_EUROS;
            }

            var additionConsumptionCostInEuros = CalculateAdditionalConsumptionCost(electricityConsumed);

            return BASE_CONSUMPTION_COST_IN_EUROS + additionConsumptionCostInEuros;
        }

        private double CalculateAdditionalConsumptionCost(int electricityConsumed)
        {
            var consumptionCostInCentsPerKwHr = 30d;
            var consumptionCostInEuroPerKwHr = consumptionCostInCentsPerKwHr / 100;
            var billableAdditionalElectricityConsumed = electricityConsumed - BASE_CONSUMPTION_RATE;

            return billableAdditionalElectricityConsumed * consumptionCostInEuroPerKwHr;
        }
    }
}
