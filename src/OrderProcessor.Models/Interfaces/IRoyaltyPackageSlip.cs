namespace OrderProcessor.Models.Interfaces
{
    public interface IRoyaltyPackageSlip : IShippingPackageSlip
    {
        string GenerateRoyaltyPackageSlip();
    }
}
