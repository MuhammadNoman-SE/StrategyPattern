using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy_Pattern_First_Look.Strategies
{
    public interface ISaleTaxStrategy
    {
        decimal GetTax(Order order);
    }
}
