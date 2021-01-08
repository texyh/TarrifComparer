using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparer.Core;
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
        }


        private TarrifProductComparer GivenTarrifComparer()
        {
            return new TarrifProductComparer();
        }
    }
}
