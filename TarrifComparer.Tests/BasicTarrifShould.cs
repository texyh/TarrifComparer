using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparer.Core.Constants;
using TarrifComparer.Core.Models;
using Xunit;

namespace TarrifComparer.Tests
{
    public class BasicTarrifShould
    {
        private readonly BasicTarrif _sut;

        public BasicTarrifShould()
        {
            _sut = new BasicTarrif();
        }

        [Fact]
        public void Be_Initializable()
        {
            Assert.Equal(Tarrif.BASIC_TARRIF, _sut.Name);
        }

        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(6000, 1380)]
        public void Calculate_AnnualCost_When_Given_Annual_Electricity_Consumption(int electricityConsumed, double expectedAnnualCost)
        {
            var annualCost = _sut.CalculateAnnualCost(electricityConsumed);

            Assert.Equal(expectedAnnualCost, annualCost);
        }
    }
}
