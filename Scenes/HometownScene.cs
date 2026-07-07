using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleGameFramework.Scenes;

public class HometownScene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(2, "돌아가기", "타이틀 화면으로 돌아갑니다"),
        new MenuOption(1, "메뉴 닫기", "메뉴를 닫고 다시 캐릭터를 움직입니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.Hometown;


    public override void Enter(GameContext context)
    {
        context.AddLog("Map 화면에 들어왔습니다.");

        // 해당하는 Map 받아오기 + 처음 플레이어 위치 갱신
        if (context.Map != MapData.Map8)
        {
            context.Player.CurrentMapId = 0;

            context.Map = MapData.Map8;
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

        ConsoleUI.WriteTitle($"연두마을", "T를 누르면 메뉴를 열 수 있습니다");

        ConsoleUI.WriteMap(context.Map);
        ConsoleUI.WriteLine($"{context.Player.Name}");
        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
        ConsoleUI.WriteLog(context.Logs);
    }


    public override void HandleInput(GameContext context)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        //context.Player.controller.Move(keyInfo, context.Player.PosY, context.Player.PosX, context);
        context.Player.Move(keyInfo, context);

        // 이 부분은 이벤트로 만들면 좀 더 깔끔할 것 같다 -> 지금은 모든 맵씬마다 해줘야함
        // 만약 이동하는 부분에서 풀숲에 있을 때 확률로 invoke를 해주면 뭔가 가능하지않을까?
        //현재 위치가 *(풀숲)이면 일정확률로 몬스터를 만난다.
        if (MapData.prevMap == '*' && context.Random.Next(100) < 10)
        {
            GameManager.Battle.Battle(context);

        }

        //현재 위치가 E이면 다음 장소로 이동
        if (MapData.prevMap == 'E')
        {
            int PY = context.Player.PosY;
            int PX = context.Player.PosX;

            //if(PY == 0 || PX == 0 || PY == context.Map.GetLength(0) - 1 || PX == context.Map.GetLength(1) - 1)

            // 몬가몬가 더 좋은 방법이 있을 것 같음
            if(PX == 0)
                GoTo(context, SceneKey.Road29);
            else if(PY == context.Map.GetLength(0) - 1)
                GoTo(context, SceneKey.Road14);
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

