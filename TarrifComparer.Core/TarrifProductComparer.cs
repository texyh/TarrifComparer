using System;
using System.Collections.Generic;
using System.Linq;
using TarrifComparer.Core.Models;

namespace TarrifComparer.Core
{
    public class TarrifProductComparer
    {
        public readonly IList<ITarrifProduct> Products;
        public int ProductCount => Products.Count;

        public TarrifProductComparer()
        {
            Products = new List<ITarrifProduct>
            {
                new BasicTarrif(),
                new PackagedTarrif()
            };
        }

        public IList<TarrifComparismResult> Compare(int electricityConsumedInKwHrPerYear)
        {
            return Products.Select(x => new TarrifComparismResult
            {
                ProductName = x.Name,
                AnnualCost = x.CalculateAnnualCost(electricityConsumedInKwHrPerYear)
            })
            .OrderBy(x => x.AnnualCost)
            .ToList();
        }
    }
}