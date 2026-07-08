using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using System.Diagnostics.Metrics;

namespace ConsoleGameFramework.Scenes;



public class BattleScene : SceneBase
{
    const int LevelScale = 3;
    public string[] WildPoketmon = { "꼬렛", "구구" };
    Poketmon Enemy;

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "싸운다", "기술을 사용한다."),
        new MenuOption(2, "가방", "가방을 뒤진다."),
        new MenuOption(3, "포켓몬", "포켓몬을 교체합니다."),
        new MenuOption(4, "도망가기", "도망갑니다."),
    };

    public override SceneKey Key => SceneKey.Battle;

    public override void Enter(GameContext context)
    {
        //야생 포켓몬을 만났을 때
        Enemy = GameManager.Battle.WildPoketmonAppeared(context);

    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("전투 화면", "ConsoleUI 기능 미리보기");

        ConsoleUI.WriteBox(new[]
        {
            "이 화면은 상태바, 표, 로그 출력 예시를 보여줍니다.",
            "WriteStatusBar, WriteTable, WriteLog를 어떻게 쓰는지 참고하세요."
        }, "안내", ConsoleColor.DarkCyan);
        ConsoleUI.WriteLine($"{Enemy.Level}");
        ConsoleUI.WriteStatusBar($"LV.{Enemy.Level} {Enemy.Nickname}", Enemy.Hp, Enemy.MaxHp, fillColor: ConsoleColor.Green);
        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();
        //TDOD context.Player.Poketmons[0] 교체때문에라도 나중에 바꿔야함
        ConsoleUI.WriteStatusBar($"LV.{context.Player.Poketmons[0].Level} {context.Player.Poketmons[0].Nickname}", context.Player.Poketmons[0].Hp, context.Player.Poketmons[0].MaxHp, fillColor: ConsoleColor.Green);
        

        ConsoleUI.WriteMenu(Menu, "행동 선택");
        ConsoleUI.WriteLog(context.Logs);
    }

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                break;

            case 2:
                break;

            case 3:
                break;
            case 4:
                if(context.Random.Next(100) < 70)
                {
                    context.AddLog("무사히 도망쳤다");
                    GoTo(context, context.Player.PrevKey);
                }
                else
                {
                    context.AddLog("도망치는데 실패했다.");
                }
                    
                
                break;
        }
    }
}

