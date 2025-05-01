using System;

namespace DungeonExplorer
{
    interface IDamageable
    {
        int health;
        int GetHealth();
        void SetHealth(int healthChange);
    }

}
