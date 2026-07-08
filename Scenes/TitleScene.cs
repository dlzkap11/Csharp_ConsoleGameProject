using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

/// <summary>
/// 프로그램의 첫 화면입니다.
/// 이 프레임워크는 게임 내용이 빠져 있으므로, 여기서는 화면 전환 구조만 보여줍니다.
/// 실습에서는 이 화면을 여러분의 게임에 맞는 타이틀 화면으로 바꿔서 사용하면 됩니다.
/// </summary>
public class TitleScene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {

        new MenuOption(1, "캐릭터 생성", "캐릭터 생성 창으로 이동합니다."),
        new MenuOption(2, "배틀", "배틀 화면으로 이동합니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.Title;

    public override void Enter(GameContext context)
    {
        // 초기 포켓몬 데이터 인풋
        if(GameManager.Resource.PoketmonsDict.Count == 0)
        {
            GameManager.Resource.ItemDataInput();
            GameManager.Resource.PoketmonDataInput();
            GameManager.Resource.SkillDataInput();
        }
            
    }


    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("CONSOLE GAME FRAMEWORK", "C# 콘솔앱 프로젝트 프레임워크");

        if(context.Player != null)
        {
            ConsoleUI.WriteBox(new[]
            {
                $"{context.Player.Name} 반갑순.. 리시빙",
            }, "프로젝트 안내", ConsoleColor.DarkCyan);
        }
        else
        {
            ConsoleUI.WriteBox(new[]
            {
                "캐릭터를 생성해주세요",
            }, "프로젝트 안내", ConsoleColor.DarkCyan);
        }

        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
        ConsoleUI.WriteLog(context.Logs);
    }

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            
            case 1:
                GoTo(context, SceneKey.Start);
                break;

            case 2:
                if (context.Player == null)
                {
                    context.AddLog("아직 플레이어를 생성하지않았습니다!");
                    break;
                }
                
                GoTo(context, context.Player.PrevKey);
                
                
                break;

            case 0:
                context.Game.RequestQuit();
                break;
        }
    }
}
