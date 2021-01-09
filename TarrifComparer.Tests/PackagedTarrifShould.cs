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
        private readonly PackagedTarrif _sut;

        public PackagedTarrifShould()
        {
            _sut = new PackagedTarrif();
        }

        [Fact]
        public void Be_Initializable()
        {
            Assert.Equal(Tarrif.PACKAGED_TARRIF, _sut.Name);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4000, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void Calculate_AnnualCost_When_Given_Annual_Electricity_Consumption(int electricityConsumed, double expectedAnnualCost)
        {
            var annualCost = _sut.CalculateAnnualCost(electricityConsumed);

            Assert.Equal(annualCost, expectedAnnualCost);
        }
    }
}
