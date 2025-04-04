
namespace Asp_Wiederholung.Services
{
    public interface IGuidService
    {
        string GetGuid();
    }

    public class GuidService : IGuidService
    {
        public string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
