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
        [Fact]
        public void Have_Two_Tarrif_Products_When_Initialized()
        {
            var comparer = GivenTarrifComparer();

            Assert.Equal(2, comparer.ProductCount);
        }

        [Fact]
        public void Have_Tarrif_Products_To_Compare()
        {
            var comparer = GivenTarrifComparer();

            Assert.IsAssignableFrom<IList<ITarrifProduct>>(comparer.Products);
        }

        [Fact]
        public void Compare_Tarrif_Products_Given_The_Electricity_Consumption()
        {
            var comparer = GivenTarrifComparer();
            var electricityConsumedInKwHrPerYear = 3500;

            var results = comparer.Compare(electricityConsumedInKwHrPerYear);

            Assert.IsAssignableFrom<IList<TarrifComparismResult>>(results);
            Assert.Equal(2, results.Count);
            Assert.Equal(830, results.FirstOrDefault(x => x.TarrifName == Tarrif.BASIC_TARRIF).AnnualCost);
            Assert.Equal(800, results.FirstOrDefault(x => x.TarrifName == Tarrif.PACKAGED_TARRIF).AnnualCost);
        }


        private TarrifProductComparer GivenTarrifComparer()
        {
            return new TarrifProductComparer();
        }
    }
}
