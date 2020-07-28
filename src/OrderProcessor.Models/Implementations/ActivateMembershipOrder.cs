using OrderProcessor.Domain;
using OrderProcessor.Models.Interfaces;
using OrderProcessor.Models.Models;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace OrderProcessor.Models.Implementations
{
    public class ActivateMembershipOrder : IProcessesFacade, IActivateMembership
    {
        private Order orderInfo;
        public ActivateMembershipOrder(Order _order)
        {
            orderInfo = _order;
        }

        public void Process()
        {
            Console.WriteLine($"Membership has been activated -- {ActivateMembership()}");
            Console.WriteLine(SendMail());
        }

        public bool ActivateMembership()
        {
            return true;
        }

        public string SendMail()
        {
            return $"----------Email----------\n To {orderInfo.CustomerEmail}\n Your membership has been activated";
        }
    }
}
