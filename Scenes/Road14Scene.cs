using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleGameFramework.Scenes;

public class Road14Scene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(2, "돌아가기", "타이틀 화면으로 돌아갑니다"),
        new MenuOption(1, "메뉴 닫기", "메뉴를 닫고 다시 캐릭터를 움직입니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.Road14;
    const int LevelScale = 5;
    public int[] WildPoketmon = { 19, 16 };

    public override void Enter(GameContext context)
    {
        context.AddLog("Map 화면에 들어왔습니다.");

        // 해당하는 Map 받아오기 + 처음 플레이어 위치 갱신
        if (context.Map != MapData.Map7)
        {
            context.Map = MapData.Map7;
            MapData.FindStartPoint(context.Map);
            context.Player.PosY = MapData.startPointY;
            context.Player.PosX = MapData.startPointX;
            MapData.prevMap = 'S';
            context.Map[context.Player.PosY, context.Player.PosX] = 'P';
        }
    }

    public override void Render(GameContext context)
    {

        ConsoleUI.Clear();
        ConsoleUI.WriteTitle($"14번 도로", "T를 누르면 메뉴를 열 수 있습니다");

        ConsoleUI.WriteMap(context.Map);
        //context.Map = MapData.MapInit(MapData.Map4);
        //GoTo(context, SceneKey.Sample);
        //ConsoleUI.WriteMap(context.Map); //갱신 => HandleInput에서 해주기 wasd로 받는다거나 방향키로 받거나
        ConsoleUI.WriteLine($"{context.Player.Name}");
        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
        ConsoleUI.WriteLog(context.Logs);
        context.Random.Next();
    }

    public override void HandleInput(GameContext context)
    {


        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        //context.Player.controller.Move(keyInfo, context.Player.PosY, context.Player.PosX, context);
        context.Player.Move(keyInfo, context);

         
        //현재 위치가 *(풀숲)이면 일정확률로 몬스터를 만난다.
        if (MapData.prevMap == '*' && context.Random.Next(100) < 10)
        {
            context.Player.PrevKey = Key;
            GameManager.Battle.GetFiled(LevelScale, WildPoketmon);
            GoTo(context, SceneKey.Battle);

        }

        if (MapData.prevMap == 'E')
        {
            GoTo(context, SceneKey.Hometown);
        }
            

        if (keyInfo.Key == ConsoleKey.T)
        {
            int choice = ConsoleUI.ReadMenuChoice(Menu);
            switch (choice)
            {
                case 1:
                    //GameManager.Battle.PlayerAttack();
                    /*
                    EventBus.Instance.Subscribe<int>(GameEvent.PlayerDamaged,
                        damage => Console.WriteLine($"{damage}!"));
                    EventBus.Instance.Publish(GameEvent.PlayerDamaged, 20);
                    Thread.Sleep(2000);
                    */
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

