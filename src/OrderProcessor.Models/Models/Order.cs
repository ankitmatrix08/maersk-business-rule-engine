using System;

namespace OrderProcessor.Models.Models
{
    public class Order : IEquatable<Order>
    {
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string StreetLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public OrderItem OrderType { get; set; }
        public int Quantity { get; set; }
        public string VideoName { get; set; }
        public double OrderPrice { get; set; }

        #region IEquatable Methods

        public bool Equals(Order other)
        {
            if (other == null)
                return false;

            if (CustomerEmail == other.CustomerEmail)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Order order = obj as Order;
            if (order == null)
                return false;
            else
                return Equals(order);
        }

        public override int GetHashCode()
        {
            return this.CustomerEmail.GetHashCode();
        }

        #endregion IEquatable Methods
    }
}
