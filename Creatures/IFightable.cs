using System;

namespace DungeonExplorer
{
    interface IFightable
    {
        string attackType;
        int xpGranted;
        int damage;
        int GetDamage();
        string getAttackType();
        int GetXpGranted()

    }
}
