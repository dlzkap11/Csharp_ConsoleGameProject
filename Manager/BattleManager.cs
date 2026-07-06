using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Contents;

namespace ConsoleGameFramework.Manager;

public class BattleManager
{
    public Player Player { get; private set; }



    public void StartBattleInit(string name)
    {

        Player = new Player(name);

        
    }


    public enum BattleOutcome
    {
        Continuing,
        Victory,
        Defeat
    }
}

