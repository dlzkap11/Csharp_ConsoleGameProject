using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
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

    string name;
    public override SceneKey Key => SceneKey.Battle;
    UISystem ui = new UISystem();
    

    public override void Enter(GameContext context)
    {
        context.AddLog("샘플 화면에 들어왔습니다.");

        
        //test

        // (미리 준비가 된 맵 string[,])
        context.Map = MapInit(context.Map4);

        
        
        
        
    }
    // 이 부분을 삭제하고 MapClass에 복사해주세요.
    public List<string> MapInit(string[,] map)
    {
        List<string> createmap = new List<string>();

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                createmap.Add(map[i, j]);
            }
        }
        return createmap;
    }
    public override void Render(GameContext context)
    {
        

        ConsoleUI.Clear();
        ConsoleUI.WriteTitle($"전투 화면", "ㄷㄷ");
        // 정말 대단하십니다... 저희라면 진작에 포기했을 게임을...
        // 수많은 억까를 이겨내고 이기시는 침착맨님 존경스럽습니다.
        // (이 부분을 삭제하고 나중에 플레이어 생성 씬을 만들면 복사해주세요)
        if (context.Player == null)
        {
            name = ConsoleUI.ReadString("이름을 입력하세요");
            
            GameManager.Battle.StartBattleInit(name);
            ui.Subscribe(context.Player);
        }
        
        ConsoleUI.WriteStatusBar(context.Player.Name, context.Player.Hp, context.Player.MaxHp);
        ConsoleUI.WriteStatusBar(GameManager.Battle.Enemy.Name, GameManager.Battle.Enemy.Hp, GameManager.Battle.Enemy.MaxHp, fillColor:ConsoleColor.Red);

        //GoTo(context, SceneKey.Sample);
        ConsoleUI.WriteMap(context.Map); //갱신 => HandleInput에서 해주기 wasd로 받는다거나 방향키로 받거나
        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
        ConsoleUI.WriteLog(context.Logs);
        context.Random.Next();
    }

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                GameManager.Battle.PlayerAttack();
                context.AddLog($"카운터 증가: {context.Player.Hp}");

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
    }
}

