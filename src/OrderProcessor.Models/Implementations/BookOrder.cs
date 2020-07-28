using OrderProcessor.Domain;
using OrderProcessor.Models.Interfaces;
using OrderProcessor.Models.Models;
using System;

namespace OrderProcessor.Models.Implementations
{
    public class BookOrder : IProcessesFacade, IRoyaltyPackageSlip, ICommissionPayment
    {
        private Order orderInfo;
        private PricePerItem priceList;
        public BookOrder(Order _order)
        {
            orderInfo = _order;
            priceList = new PricePerItem();
        }
        public string GeneratePackageSlip()
        {
            var packagingSlip = new PackagingSlip
            {
                CustomerFullName = orderInfo.CustomerFullName,
                FullAddress = $"{orderInfo.StreetLine}\n{orderInfo.City}\n{orderInfo.State}\n{orderInfo.PinCode}",
                CustomerEmail = orderInfo.CustomerEmail,
                OrderId = new Guid()
            };

            packagingSlip.TotalAmount = orderInfo.Quantity * priceList.GetPrice(orderInfo.OrderType);

            return packagingSlip.ToString();
        }

        public string GenerateRoyaltyPackageSlip()
        {
            return GeneratePackageSlip();
        }

        public string PayCommissionToAgent(float percentage)
        {
            var commission = orderInfo.OrderPrice * percentage;
            return $"Commission Paid - Amount:{commission}";
        }

        public void Process()
        {
            Console.WriteLine(GeneratePackageSlip());
            Console.WriteLine(GenerateRoyaltyPackageSlip());
            Console.WriteLine(PayCommissionToAgent(0.02f));
        }
    }
}
