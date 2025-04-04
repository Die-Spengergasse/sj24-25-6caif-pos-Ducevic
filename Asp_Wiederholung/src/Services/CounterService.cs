
namespace Asp_Wiederholung.Services
{
    public interface ICounterService
    {
        int GetCount();
    }

    public class CounterService : ICounterService
    {
        private int _count = 0;

        public int GetCount()
        {
            return ++_count;
        }
    }
}
