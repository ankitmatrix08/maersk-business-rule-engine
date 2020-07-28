using OrderProcessor.Domain;
using OrderProcessor.Models.Interfaces;
using OrderProcessor.Models.Models;
using System;

namespace OrderProcessor.Models.Implementations
{
    public class PhysicalProductOrder : IShippingPackageSlip, ICommissionPayment, IProcessesFacade
    {
        private Order orderInfo;
        private PricePerItem priceList;
        public PhysicalProductOrder(Order order)
        {
            orderInfo = order;
            priceList = new PricePerItem();
        }
        public void Process()
        {
            Console.WriteLine(GeneratePackageSlip());
            Console.WriteLine(PayCommissionToAgent(0.02f));
        }
        public string GeneratePackageSlip()
        {
            var packagingSlip = new PackagingSlip
            {
                CustomerFullName = orderInfo.CustomerFullName,
                FullAddress = $"{orderInfo.StreetLine}\n{orderInfo.City}\n{orderInfo.State}\n{orderInfo.PinCode}",
                CustomerEmail = orderInfo.CustomerEmail,
                OrderId = Guid.NewGuid()
            };

            packagingSlip.TotalAmount = orderInfo.Quantity * priceList.GetPrice(orderInfo.OrderType);

            return packagingSlip.ToString();
        }

        public string PayCommissionToAgent(float percentage)
        {
            var commission = orderInfo.OrderPrice * percentage;
            return $"Commission Paid - Amount:{commission}";
        }

    }
}
