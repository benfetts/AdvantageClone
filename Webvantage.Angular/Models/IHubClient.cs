using System.Threading.Tasks;

namespace Webvantage.Angular.Models
{
    public interface IHubClient
    {
        Task BroadcastMessage();
        Task Send(string Message);
    }
}
