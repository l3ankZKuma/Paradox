using System;
using Microsoft.Xna.Framework;

namespace Paradox
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(string enemyType, Vector2 patrolFrom, Vector2 patrolTo)
        {
            switch (enemyType)
            {
                case "Enemy_1":
                    return new Enemy_1(patrolFrom, patrolTo);
                case "Enemy_2":
                    return new Enemy_2(patrolFrom, patrolTo);
                case "Enemy_3":
                    return new Enemy_3(patrolFrom, patrolTo);
                case "Enemy_4":
                    return new Enemy_4(patrolFrom, patrolTo);
                case "Boss":
                    return new Boss(patrolFrom, patrolTo);
                default:
                    throw new ArgumentException("Invalid enemy type");
            }
        }
    }
}