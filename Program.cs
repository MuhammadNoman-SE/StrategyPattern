﻿using Strategy_Pattern_Creating_an_invoice.Business.Strategies.Invoice;
using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Strategies;
using System;

namespace Strategy_Pattern_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails 
                { 
                    OriginCountry = "us",
                    DestinationCountry = "us",
                    DestinationState="la"
                },
				InvoiceStrategy = new PrintOnDemandInvoiceStrategy()
            };
            //order.SaleTaxStrategy = new USSaleStrategy();
			order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });
            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            Console.WriteLine(order.GetTax(new USSaleStrategy()));
			 order.FinalizeOrder();
            Console.ReadLine();

        }
    }
}
