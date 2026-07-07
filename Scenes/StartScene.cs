using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using System.Xml.Linq;

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
                break;

            case 9:
                GoTo(context, SceneKey.Title);
                break;
        }
    }
}
