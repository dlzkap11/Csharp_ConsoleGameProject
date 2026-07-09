using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.Diagnostics.Metrics;

namespace ConsoleGameFramework.Scenes;



public class BattleScene : SceneBase
{
    const int LevelScale = 3;
    public string[] WildPoketmon = { "꼬렛", "구구" };
    Poketmon Enemy;
    bool IsRun = false;
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
        if(Enemy == null)
            Enemy = GameManager.Battle.WildPoketmonAppeared(context);

    }

    public override void Exit(GameContext context)
    {
        // 객체 초기화
        if(Enemy.IsDead || IsRun)
            Enemy = null;
    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        
        ConsoleUI.WriteTitle("전투 화면", "가방이나 포켓몬 교체 중 취소를 원한다면 T를 입력하세요");

        ConsoleUI.WriteBox(new[]
        {
            "이 화면은 상태바, 표, 로그 출력 예시를 보여줍니다.",
            "WriteStatusBar, WriteTable, WriteLog를 어떻게 쓰는지 참고하세요."
        }, "안내", ConsoleColor.DarkCyan);
        ConsoleUI.WriteStatusBar($"LV.{Enemy.Level} {Enemy.Name}", Enemy.Hp, Enemy.MaxHp, fillColor: ConsoleColor.Green);
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
                string[] skillName = new string[4];

                for(int i = 0; i < context.Player.Poketmons[0].Skills.Count; i++)
                {
                    skillName[i] = context.Player.Poketmons[0].Skills[i].Name;
                }

                ConsoleUI.WriteBox(new[]
                {
                    $"{Format.FormatCell(skillName[0], 12)}{Format.FormatCell(skillName[1], 12)}",
                    $"{Format.FormatCell(skillName[2], 12)}{Format.FormatCell(skillName[3], 12)}",
                });
                int input = ConsoleUI.ReadInt("사용할 기술을 선택하세요(행동취소를 원한다면 5 입력)", 1, 5);
                if(input == 5)
                {
                    GoTo(context, Key);
                    break;
                }

                GameManager.Battle.GetBattle(context.Player.Poketmons[0], Enemy, input - 1);
                if (Enemy.IsDead)
                {
                    context.AddLog("배틀에서 승리했다.");
                    Thread.Sleep(1000);
                    GoTo(context, context.Player.PrevKey);
                }
                else if (context.Player.Poketmons[0].IsDead)
                {
                    context.AddLog($"배틀에서 패배했다. {context.Player.Name}는 눈앞이 캄캄해졌다.");
                    Thread.Sleep(1000);
                    GoTo(context, SceneKey.Hometown);
                }
                break;

            case 2:
                //인벤토리 보기
                context.AddLog("인벤토리");
                ConsoleKeyInfo keyInfo3 = Console.ReadKey(true);
                //취소시 돌아가기
                if (keyInfo3.Key == ConsoleKey.T)
                    GoTo(context, Key);
                else
                    GameManager.Battle.EnemyAttack(context.Player.Poketmons[0], Enemy, choice);

                break;

            case 3:
                //내 포켓몬 리스트보기
                context.AddLog("포켓몬 창");
                ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                if (keyInfo2.Key == ConsoleKey.T)
                    GoTo(context, Key);
                break;
            case 4:
                if(context.Random.Next(100) < 70)
                {
                    ConsoleUI.WriteLine("무사히 도망쳤다");
                    Thread.Sleep(1500);
                    IsRun = true;
                    GoTo(context, context.Player.PrevKey);
                }
                else
                {

                    ConsoleUI.WriteLine("도망치는데 실패했다");
                    Thread.Sleep(1000);
                    GameManager.Battle.EnemyAttack(context.Player.Poketmons[0], Enemy, choice);
                    
                }
                    
                
                break;
        }
    }

    
}

