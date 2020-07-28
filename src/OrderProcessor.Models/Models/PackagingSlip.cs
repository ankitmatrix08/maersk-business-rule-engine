using System;

namespace OrderProcessor.Models.Models
{
    public class PackagingSlip : IEquatable<PackagingSlip>
    {
        public Guid OrderId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string FullAddress { get; set; }
        public double TotalAmount { get; set; }
        public override string ToString()
        {
            return $"Packaging Slip --- \n OrderId: {OrderId.ToString()} \n To - {CustomerFullName} \n {FullAddress} \n Total Amount: {TotalAmount}";
        }


        #region IEquatable Methods

        public bool Equals(PackagingSlip other)
        {
            if (other == null)
                return false;

            if (OrderId == other.OrderId)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            PackagingSlip packagingSlip = obj as PackagingSlip;
            if (packagingSlip == null)
                return false;
            else
                return Equals(packagingSlip);
        }

        public override int GetHashCode()
        {
            return this.OrderId.GetHashCode();
        }

        #endregion IEquatable Methods
    }
}
