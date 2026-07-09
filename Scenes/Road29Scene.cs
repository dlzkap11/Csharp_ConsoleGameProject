using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleGameFramework.Scenes;

public class Road29Scene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(2, "돌아가기", "타이틀 화면으로 돌아갑니다"),
        new MenuOption(1, "메뉴 닫기", "메뉴를 닫고 다시 캐릭터를 움직입니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.Road29;
    private event Action<GameContext> WildPoketmonAppearHandler;


    const int LevelScale = 3;
    public int[] WildPoketmon = { 19, 16}; //꼬렛 구구

    //억지 이벤트 모지요
    public void Test(GameContext context)
    {
        context.Player.PrevKey = Key;
        GameManager.Battle.GetFiled(LevelScale, WildPoketmon);
        GoTo(context, SceneKey.Battle);
    }

    

    public override void Enter(GameContext context)
    {
        WildPoketmonAppearHandler = Test;
        EventBus.Instance.Subscribe(GameEvent.WildPoketmonAppeared, WildPoketmonAppearHandler);
        
        //OnWildPoketmonAppeared += WildPoketmonAppearHandler;

        context.AddLog("29번 도로");

        // 해당하는 Map 받아오기 + 처음 플레이어 위치 갱신
        if(context.Map != MapData.Map6)
        {
            context.Map = MapData.Map6;
            MapData.FindStartPoint(context.Map);
            context.Player.PosY = MapData.startPointY;
            context.Player.PosX = MapData.startPointX;
            MapData.prevMap = 'S';
            context.Map[context.Player.PosY, context.Player.PosX] = 'P';
        }

    }
    
    public override void Exit(GameContext context)
    {
        EventBus.Instance.UnSubscribe(GameEvent.WildPoketmonAppeared, WildPoketmonAppearHandler);
    }
    
    public override void Render(GameContext context)
    {

        ConsoleUI.Clear();
        ConsoleUI.WriteTitle($"29번 도로");

        ConsoleUI.WriteMap(context.Map);
        //context.Map = MapData.MapInit(MapData.Map4);
        //GoTo(context, SceneKey.Sample);
        //ConsoleUI.WriteMap(context.Map); //갱신 => HandleInput에서 해주기 wasd로 받는다거나 방향키로 받거나
        ConsoleUI.WriteLine($"{context.Player.Name}"); 
        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
        ConsoleUI.WriteLog(context.Logs);
        
    }
    

    public override void HandleInput(GameContext context)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        //context.Player.controller.Move(keyInfo, context.Player.PosY, context.Player.PosX, context);
        context.Player.Move(keyInfo, context);

        //현재 위치가 *(풀숲)이면 일정확률로 몬스터를 만난다.
        if (MapData.prevMap == '*' && context.Random.Next(100) < 10)
        {
            EventBus.Instance.Publish(GameEvent.WildPoketmonAppeared, context);
        }
        if (MapData.prevMap == '*' && context.Random.Next(100) < 10)
        {
            //Thread.Sleep(1000);
            //GoTo(context, SceneKey.Battle);
        }

        //현재 위치가 E이면 다음 장소로 이동
        if (MapData.prevMap == 'E')
        {
            GoTo(context, SceneKey.Hometown);
        }

        if(keyInfo.Key == ConsoleKey.T)
        {
            int choice = ConsoleUI.ReadMenuChoice(Menu);
            switch (choice)
            {
                case 1:
                    GoTo(context, Key);
                    break;
                case 2:
                    context.Player.PrevKey = Key;
                    GoTo(context, SceneKey.Title);
                    break;
                case 0:
                    context.Game.RequestQuit();
                    break;
            }
        }
        
        
    }


}

