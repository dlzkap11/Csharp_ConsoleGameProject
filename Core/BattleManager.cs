using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Contents;

namespace ConsoleGameFramework.Core;

public class BattleManager
{
    public Player Player { get; private set; }

    public Enemy Enemy { get; private set; }


    public void StartBattleInit(string name)
    {

        Player = new Player(name, 100, 20);
        Enemy = new Enemy("고블린", 40, 4);

        
    }


    public enum BattleOutcome
    {
        Continuing,
        Victory,
        Defeat
    }


    public BattleOutcome PlayerAttack()
    {
        Enemy.TakeDamage(Player.Attack);
        if (!Enemy.IsAlive)
        {
            return BattleOutcome.Victory;
        }
        Player.TakeDamage(Enemy.Attack);

        if (Player.IsAlive)
            return BattleOutcome.Continuing;
        else
            return BattleOutcome.Defeat;

    }
}

