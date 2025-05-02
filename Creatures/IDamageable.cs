using System;

namespace DungeonExplorer
{
    interface IDamageable
    {
        int GetHealth();
        void SetHealth(int healthChange);
    }
}
