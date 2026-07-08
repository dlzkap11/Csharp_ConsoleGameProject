using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;

namespace ConsoleGameFramework.Manager;

public class BattleManager
{
    int levelScale;
    List<string> poketmons = new List<string>();


    public Poketmon WildPoketmonAppeared(GameContext context)
    {
        int rLevel = context.Random.Next(levelScale - 1, levelScale + 2);
        int rName = context.Random.Next(0, poketmons.Count);

        // 야생 포켓몬 생성
        context.AddLog($"야생의 {poketmons[rName]}이 나타났다!");
        Poketmon wildPoketmon = new Poketmon(poketmons[rName], rLevel);
        return wildPoketmon;
    }

    // 포켓몬을 마주쳤을 때 해당 필드의 레벨스케일과 포켓몬배열을 가져온다
    public void GetFiled(int scale, string[] wpoketmons)
    {
        poketmons.Clear();
        levelScale = scale;
        for(int i = 0; i < wpoketmons.Length; i++)
        {
            poketmons.Add(wpoketmons[i]);
        }
    }


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

