using System;

namespace DungeonExplorer
{
    interface IFightable
    {
        int GetDamage();
        string GetAttackType();
        int GetXpGranted();

    }
}
