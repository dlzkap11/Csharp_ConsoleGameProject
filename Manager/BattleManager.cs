using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;

namespace ConsoleGameFramework.Manager;

public class BattleManager
{
    



    public void Battle(GameContext context)
    {
        context.AddLog("몬스터와 마주침!");
    }


    public enum BattleOutcome
    {
        Continuing,
        Victory,
        Defeat
    }
}

