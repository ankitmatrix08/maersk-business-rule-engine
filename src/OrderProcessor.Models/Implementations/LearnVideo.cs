using OrderProcessor.Domain;
using OrderProcessor.Models.Interfaces;
using OrderProcessor.Models.Models;
using System;

namespace OrderProcessor.Models.Implementations
{
    public class LearnVideo: IFreeVideo, IShippingPackageSlip, IProcessesFacade
    {
        private Order orderInfo;
        private PricePerItem priceList;
        public LearnVideo(Order _order)
        {
            orderInfo = _order;
            priceList = new PricePerItem();
        }

        public void Process()
        {
            Console.WriteLine(GeneratePackageSlip());
           
            if (IsEligible(orderInfo.VideoName))
                Console.WriteLine($"Free Goodies {GetFreeVideo()}");
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

        public string GetFreeVideo()
        {
            return "First Aid";
        }

        public bool IsEligible(string videoName)
        {
            return "Learning to Ski".Equals(videoName);
        }

    }
}
