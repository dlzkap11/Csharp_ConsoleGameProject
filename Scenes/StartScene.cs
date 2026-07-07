using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

/// <summary>
/// ConsoleUI가 제공하는 출력 기능(상태바, 표, 로그)을 한 화면에서 확인해볼 수 있는 샘플입니다.
/// 실습에서는 이 화면을 참고해서 여러분의 실제 게임 화면(전투, 상점 등)으로 바꿔 쓰면 됩니다.
/// </summary>
public class StartScene : SceneBase
{
    private const int CounterMax = 10;

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "캐릭터 생성", "처음 캐릭터를 생성합니다."),
        new MenuOption(2, "파트너 고르기", "처음 가지고 시작할 포켓몬을 고릅니다."),

        new MenuOption(9, "타이틀로", "첫 화면으로 돌아갑니다."),
    };

    private int _counter;
    

    public override SceneKey Key => SceneKey.Start;

    public override void Enter(GameContext context)
    {

        context.AddLog("샘플 화면에 들어왔습니다.");

    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("샘플 화면", "ConsoleUI 기능 미리보기");


        ConsoleUI.WriteMenu(Menu, "행동 선택");
        ConsoleUI.WriteLog(context.Logs);
    }

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                if (context.Player == null)
                {
                    string name;
                    name = ConsoleUI.ReadString("이름을 입력하세요");

                    GameManager.Resource.PlayerInit(name);
                    GoTo(context, SceneKey.Title);
                }
                else
                {
                    context.AddLog("이미 캐릭터를 생성하였습니다.");
                }
                break;
            case 2:
                if (context.Player == null)
                {
                    context.AddLog("아직 플레이어를 생성하지않았습니다!");
                    break;
                }

                if (context.Player.Poketmons.Count == 0)
                {
                    
                    ConsoleUI.WriteBox(new[]
                    {
                        $"1){GameManager.Resource.PoketmonsDict["이상해씨"].Name}",
                        $"2){GameManager.Resource.PoketmonsDict["파이리"].Name}",
                        $"3){GameManager.Resource.PoketmonsDict["꼬부기"].Name}"
                    }, "포켓몬 고르기", ConsoleColor.DarkCyan);

                    int input = ConsoleUI.ReadInt("가져갈 포켓몬을 고르세요.",1, 3);
                    Poketmon poketmon;
                    if (input == 1)
                    {
                        poketmon = GameManager.Resource.PoketmonInit("이상해씨");
                    }
                    else if(input == 2)
                    {
                        poketmon = GameManager.Resource.PoketmonInit("파이리");
                    }
                    else if(input == 3)
                    {
                        poketmon = GameManager.Resource.PoketmonInit("꼬부기");
                    }
                    else // 지역변수할당을 위한 else ReadInt에서 이미 1~3사이 값만을 받기 때문에 안전함
                        poketmon = GameManager.Resource.PoketmonInit("미싱노");

                    context.Player.Poketmons.Add(poketmon);
                    string name;
                    name = ConsoleUI.ReadString("별명을 지어주세요");
                    if (!string.IsNullOrEmpty(name))
                        poketmon.Nickname = name;
                }
                else
                {
                    context.AddLog("이미 포켓몬을 가지고 있습니다.");
                }

                break;
            case 9:
                GoTo(context, SceneKey.Title);
                break;
        }
    }
}
