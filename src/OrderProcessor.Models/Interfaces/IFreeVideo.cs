namespace OrderProcessor.Models.Interfaces
{
    public interface IFreeVideo
    {
        bool IsEligible(string videoName);
        string GetFreeVideo();
    }
}
