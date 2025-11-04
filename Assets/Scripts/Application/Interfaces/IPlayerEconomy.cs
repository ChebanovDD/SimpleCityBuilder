namespace Application.Interfaces
{
    public interface IPlayerEconomy
    {
        int Gold { get; }
        
        void Add(int amount);
        bool TrySpend(int amount);
    }
}