using OrderProcessor.Models.Interfaces;
using OrderProcessor.Models.Models;
using System;

namespace OrderProcessor.Models.Implementations
{
    public class UpgradeMembershipOrder : IUpgradeMembership, IProcessesFacade
    {
        private Order orderInfo;
        public UpgradeMembershipOrder(Order _order)
        {
            orderInfo = _order;
        }

        public void Process()
        {
            Console.WriteLine($"Membership has been upgraded -- {UpgradeMembership()}");
            Console.WriteLine(SendMail());
        }

        public string SendMail()
        {
            return $"----------Email----------\n To {orderInfo.CustomerEmail}\n Your membership has been upgraded";
        }

        public bool UpgradeMembership()
        {
            return true;
        }
    }
}
