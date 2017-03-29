namespace Wonga.Airlines.Data
{
    public interface IRoute
    {
        string Orgin { get; set; }
        string Destination { get; set; }
        int CostPerPassenger { get; set; }
        int TicketPrice { get; set; }
        byte MinimumTakeOffLoadPercentage { get; set; }
        Aircraft Aircraft { get; set; }
    }
}