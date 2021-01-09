using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TarrifComparer.Core;
using TarrifComparer.Core.Constants;
using TarrifComparer.Core.Models;
using Xunit;

namespace TarrifComparer.Tests
{
    public class TarrifComparerShould
    {
        private readonly TarrifProductComparer _sut; // subject under test

        public TarrifComparerShould()
        {
            _sut =  new TarrifProductComparer();
        }

        [Fact]
        public void Have_Two_Tarrif_Products_When_Initialized()
        {
            Assert.Equal(2, _sut.ProductCount);
        }

        [Fact]
        public void Have_Tarrif_Products_To_Compare()
        {
            Assert.IsAssignableFrom<IList<ITarrifProduct>>(_sut.Products);
        }

        [Fact]
        public void Compare_Tarrif_Products_Given_The_Electricity_Consumption()
        {
            var electricityConsumedInKwHrPerYear = 3500;

            var results = _sut.Compare(electricityConsumedInKwHrPerYear);

            Assert.IsAssignableFrom<IList<TarrifComparismResult>>(results);
            Assert.Equal(2, results.Count);
            Assert.Equal(830, results.FirstOrDefault(x => x.TarrifName == Tarrif.BASIC_TARRIF).AnnualCost);
            Assert.Equal(800, results.FirstOrDefault(x => x.TarrifName == Tarrif.PACKAGED_TARRIF).AnnualCost);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(500)]
        [InlineData(1500)]
        [InlineData(3500)]
        [InlineData(4500)]
        [InlineData(6000)]
        [InlineData(12000)]
        public void Return_Comparism_Result_In_Ascending_Order(int electricityConsumed) 
        {
            var results = _sut.Compare(electricityConsumed);

            for (int i = 0; i < results.Count - 2; i++)
            {
                Assert.True(results[i].AnnualCost < results[i + 1].AnnualCost);
            }
        }
    }
}
