using Application.Interfaces;

namespace Infrastructure
{
    public sealed class PlayerEconomy : IPlayerEconomy
    {
        public int Gold { get;  private set; }

        public PlayerEconomy(int initialGold)
        {
            Gold = initialGold;
        }

        public bool TrySpend(int amount)
        {
            if (Gold< amount)
            {
                return false;
            }
            
            Gold -= amount;
            
            return true;
        }

        public void Add(int amount)
        {
            Gold += amount;
        }
    }
}