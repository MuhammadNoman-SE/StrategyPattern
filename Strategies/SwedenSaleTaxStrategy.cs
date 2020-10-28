using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy_Pattern_First_Look.Strategies
{
    public class SwedenSaleTaxStrategy : ISaleTaxStrategy
    {
        public decimal GetTax(Order order)
        {
        var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            if (destination == order.ShippingDetails.OriginCountry.ToLowerInvariant())
            {
                decimal totalTax = 0m;
                foreach (var item in order.LineItems)
                {
                    switch (item.Key.ItemType)
                    {
                        case ItemType.Food:
                            totalTax += (item.Key.Price * 0.06m) * item.Value;
                            break;

                        case ItemType.Literature:
                            totalTax += (item.Key.Price * 0.08m) * item.Value;
                            break;

                        case ItemType.Service:
                        case ItemType.Hardware:
                            totalTax += (item.Key.Price * 0.25m) * item.Value;
                            break;
                    }
                }

                return totalTax;
            }

            return 0;

        }
    }
}
