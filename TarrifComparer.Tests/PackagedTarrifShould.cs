using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparer.Core.Constants;
using TarrifComparer.Core.Models;
using Xunit;

namespace TarrifComparer.Tests
{
    public class PackagedTarrifShould
    {
        [Fact]
        public void Be_Initializable()
        {
            var packagedTarrif = new PackagedTarrif();

            Assert.NotNull(packagedTarrif);
            Assert.Equal(Tarrif.PACKAGED_TARRIF, packagedTarrif.Name);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4000, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void Calculate_AnnualCost_When_Given_Annual_Electricity_Consumption(int electricityConsumed, double expectedAnnualCost)
        {
            var packagedTarrif = new PackagedTarrif();

            var annualCost = packagedTarrif.CalculateAnnualCost(electricityConsumed);

            Assert.Equal(annualCost, expectedAnnualCost);
        }
    }
}
