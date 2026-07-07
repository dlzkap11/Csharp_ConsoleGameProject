using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleGameFramework.Scenes;

public class BattleScene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(2, "돌아가기", "타이틀 화면으로 돌아갑니다"),
        new MenuOption(1, "샘플 화면으로 이동", "ConsoleUI의 다른 기능들을 보여주는 화면으로 이동합니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.Battle;
    

    public override void Enter(GameContext context)
    {
        context.AddLog("샘플 화면에 들어왔습니다.");

        
        //context.Map = MapData.MapInit(MapData.Map4);
        
        
        
        
    }

    public override void Render(GameContext context)
    {
        

        ConsoleUI.Clear();
        ConsoleUI.WriteTitle($"전투 화면", "ㄷㄷ");
        

        context.Map = MapData.MapInit(MapData.Map4);
        //GoTo(context, SceneKey.Sample);
        ConsoleUI.WriteMap(context.Map); //갱신 => HandleInput에서 해주기 wasd로 받는다거나 방향키로 받거나
        ConsoleUI.WriteLine($"{context.Player.Name}"); 
        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
        ConsoleUI.WriteLine(context.Map[0]);
        Console.WriteLine(context.Map[0][1]);
        Console.WriteLine(MapData.Map4[0, 0][0]);
        ConsoleUI.WriteLog(context.Logs);
        context.Random.Next();
    }
    
    // 벽체크와 이동관련은 나중에 다른 곳으로 옮겨주세요 BibbleThump
    static bool IsWall(int pos, int player_y, int player_x)
    {
        // 위 아래 왼 오
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        //미로 크기 체크
        if (player_y + dr[pos] < 0 || player_y + dr[pos] >= MapData.Map4.GetLength(0) || player_x + dc[pos] < 0 || player_x + dc[pos] >= MapData.Map4.GetLength(1))
            return false;

        //벽 체크
        if (MapData.Map4[player_y + dr[pos], player_x + dc[pos]] == "#")
            return false;
        else
            return true;
    }

    static void MovePos(int pos, ref int player_y, ref int player_x, GameContext context)
    {
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        if (!IsWall(pos, player_y, player_x))
            return;

        player_y += dr[pos];
        player_x += dc[pos];
        MapData.Map4[player_y, player_x] = "P";
    }

    public override void HandleInput(GameContext context)
    {
        //int choice = ConsoleUI.ReadMenuChoice(Menu);

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        
        int player_y = context.Player.PosY;
        int player_x = context.Player.PosX;

        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            MovePos(0, ref player_y, ref player_x, context);
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            MovePos(1, ref player_y, ref player_x, context);
        }
        else if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            MovePos(2, ref player_y, ref player_x, context);
        }
        else if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            MovePos(3, ref player_y, ref player_x, context);
        }


        /*
        switch (choice)
        {
            case 1:
                //GameManager.Battle.PlayerAttack();

                EventBus.Instance.Subscribe<int>(GameEvent.PlayerDamaged, 
                    damage => Console.WriteLine($"{damage}!"));
                EventBus.Instance.Publish(GameEvent.PlayerDamaged, 20);
                Thread.Sleep(2000);
                break;
            case 2:
                GoTo(context, SceneKey.Title);
                break;
            case 0:
                context.Game.RequestQuit();
                break;
        }
        */
    }


}

