using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Scenes;



public class BattleScene : SceneBase
{
    const int LevelScale = 3;
    public string[] WildPoketmon = { "꼬렛", "구구" };
    Poketmon CurrentPoketmon;
    Poketmon Enemy;
    bool IsGet;
    bool IsRun;
    bool IsDefeat;
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
        if (Enemy == null)
        {
            int i = 0;
            while (CurrentPoketmon == null || !CurrentPoketmon.IsDead)
            {
                if (!context.Player.Poketmons[i].IsDead)
                {
                    CurrentPoketmon = context.Player.Poketmons[i];
                    break;
                }
                i++;
            }
            Enemy = GameManager.Battle.WildPoketmonAppeared(context);
            IsGet = false;
            IsRun = false;
            IsDefeat = false;
        }


    }

    public override void Exit(GameContext context)
    {
        // 객체 초기화
        if (Enemy.IsDead || IsRun || IsGet || IsDefeat)
        {
            Enemy = null;
        }

    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();

        ConsoleUI.WriteTitle("전투 화면");

        ConsoleUI.WriteStatusBar($"LV.{Enemy.Level} {Enemy.Name}", Enemy.Hp, Enemy.MaxHp, fillColor: ConsoleColor.Green);
        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();
        //TDOD context.Player.Poketmons[0] 교체때문에라도 나중에 바꿔야함
        ConsoleUI.WriteStatusBar($"LV.{CurrentPoketmon.Level} {CurrentPoketmon.Nickname}", CurrentPoketmon.Hp, CurrentPoketmon.MaxHp, fillColor: ConsoleColor.Green);


        ConsoleUI.WriteMenu(Menu, "행동 선택");
        ConsoleUI.WriteLog(context.Logs);
    }

    public override void HandleInput(GameContext context)
    {

        int choice = ConsoleUI.ReadMenuChoice(Menu);
        int input;
        int eindex = context.Random.Next(0, 4);
        //적 스킬개수보다 eindex가 클 경우 리롤
        while (eindex >= Enemy.Skills.Count)
            eindex = context.Random.Next(0, 4);
        switch (choice)
        {

            case 1:
                string[] skillName = new string[4];

                for (int i = 0; i < CurrentPoketmon.Skills.Count; i++)
                {
                    skillName[i] = CurrentPoketmon.Skills[i].Name;
                }

                ConsoleUI.WriteBox(new[]
                {
                    $"{Format.FormatCell(skillName[0], 12)}{Format.FormatCell(skillName[1], 12)}",
                    $"{Format.FormatCell(skillName[2], 12)}{Format.FormatCell(skillName[3], 12)}",
                }); // 흠 없는 기술에 번호를 누르면 버그가 난다 일단 확인
                input = ConsoleUI.ReadInt("사용할 기술을 선택하세요(행동취소를 원한다면 5 입력)", 1, 5);
                if (input == 5)
                {
                    GoTo(context, Key);
                    break;
                }
                if (string.IsNullOrEmpty(skillName[input - 1]))
                {
                    ConsoleUI.WriteLine("아직 잠재성이 남아있다.");
                    break;
                }


                GameManager.Battle.GetBattle(CurrentPoketmon, Enemy, input - 1);
                if (Enemy.IsDead)
                {
                    //임시경험치계산기 나중에 다른데로 옮기기
                    CurrentPoketmon.Exp += (int)(Enemy.Level * 1.5f);
                    if (CurrentPoketmon.Exp >= CurrentPoketmon.MaxExp)
                    {
                        CurrentPoketmon.LevelUp();
                        ConsoleUI.WriteLine($"{CurrentPoketmon.Nickname}이 레벨업 했다");
                    }


                    context.AddLog($"배틀에서 승리해서 {(int)(Enemy.Level * 1.5f)}의 경험치를 획득했다.");
                    context.AddLog($"현재 경험치 :{CurrentPoketmon.Exp}/{CurrentPoketmon.MaxExp}");
                    Thread.Sleep(1000);
                    GoTo(context, context.Player.PrevKey);
                }

                break;

            case 2:
                //인벤토리 보기
                string[] itemName = new string[context.Player.Inventory.Count];

                for (int i = 0; i < itemName.Length; i++)
                {
                    itemName[i] = context.Player.Inventory[i].Name;
                }

                ConsoleUI.WriteBox(new[]
                {

                    $"{Format.FormatCell(itemName[0], 6)} {Format.FormatCell($"{context.Player.Inventory[0].Count}개", 6)}", // 몇개인지확인
                    $"{Format.FormatCell(itemName[1], 6)} {Format.FormatCell($"{context.Player.Inventory[1].Count}개",6)}",
                });

                input = ConsoleUI.ReadInt("사용할 아이템을 선택하세요 (마지막 번호는 돌아가기)", 1, itemName.Length + 1);
                if (input == itemName.Length + 1)
                {
                    break;
                }
                else
                {
                    if (input == 1)
                    {
                        string[] poketmonName2 = new string[6];
                        for (int i = 0; i < context.Player.Poketmons.Count; i++)
                        {
                            poketmonName2[i] = context.Player.Poketmons[i].Name;
                        }
                        ConsoleUI.WriteBox(new[]
                        {
                            $"{Format.FormatCell(poketmonName2[0], 6)}{Format.FormatCell(poketmonName2[1], 6)}",
                            $"{Format.FormatCell(poketmonName2[2], 6)}{Format.FormatCell(poketmonName2[3], 6)}",
                            $"{Format.FormatCell(poketmonName2[4], 6)}{Format.FormatCell(poketmonName2[5], 6)}",
                        });
                        input = ConsoleUI.ReadInt("아이템을 사용할 포켓몬을 고르세요 (마지막 번호는 돌아가기)", 1, 7);
                        if (input == 7)
                            break;
                        if (string.IsNullOrEmpty(poketmonName2[input - 1]))
                        {
                            ConsoleUI.WriteLine("하지만 아무도 없었다...");
                            Thread.Sleep(1000);
                            break;
                        }
                        //상처약
                        context.Player.Poketmons[input - 1].Hp += context.Player.Inventory[0].Amount;
                        context.Player.Inventory[0].Count--;
                        ConsoleUI.WriteLine($"{context.Player.Poketmons[input - 1].Nickname}에게 상처약을 사용하였다.");
                        Thread.Sleep(1000);


                        GameManager.Battle.UseSkill(Enemy, CurrentPoketmon, Enemy.Skills[eindex]);


                        Thread.Sleep(1000);

                    }
                    else if (input == 2)
                    {
                        //몬스터볼
                        //던지면 확률로 야생포켓몬이 잡힘
                        //안잡히면 끝
                        if (context.Player.Inventory[1].Count < 0)
                        {
                            context.AddLog("몬스터볼이 없습니다.");
                            break;
                        }
                        context.Player.Inventory[1].Count--;

                        if (context.Random.Next(100) < context.Player.Inventory[1].Amount)
                        {
                            context.Player.Poketmons.Add(Enemy);
                            IsGet = true;
                            ConsoleUI.Write(".");
                            Thread.Sleep(1000);
                            ConsoleUI.Write(".");
                            Thread.Sleep(1000);
                            ConsoleUI.Write(".");
                            Thread.Sleep(1200);
                            ConsoleUI.WriteLine($"{Enemy.Name}을 잡았다.");
                            Thread.Sleep(1000);
                            string inputName = ConsoleUI.ReadString($"{Enemy.Name}에게 별명을 지어주시겠습니까?");
                            if (!string.IsNullOrEmpty(inputName))
                                Enemy.Nickname = inputName;
                            GoTo(context, context.Player.PrevKey);
                            break;
                        }
                        else
                        {
                            ConsoleUI.WriteLine($"{Enemy.Name}이 몬스터볼에서 튀어나왔다.");
                            Thread.Sleep(1000);
                            GameManager.Battle.UseSkill(Enemy, CurrentPoketmon, Enemy.Skills[eindex]);
                            Thread.Sleep(1000);
                        }
                    }

                }
                break;

            case 3:
                //내 포켓몬 리스트보기
                string[] poketmonName = new string[6];
                for (int i = 0; i < context.Player.Poketmons.Count; i++)
                {
                    poketmonName[i] = context.Player.Poketmons[i].Name;
                }
                ConsoleUI.WriteBox(new[]
                {
                    $"{Format.FormatCell(poketmonName[0], 6)}{Format.FormatCell(poketmonName[1], 6)}",
                    $"{Format.FormatCell(poketmonName[2], 6)}{Format.FormatCell(poketmonName[3], 6)}",
                    $"{Format.FormatCell(poketmonName[4], 6)}{Format.FormatCell(poketmonName[5], 6)}",
                });
                input = ConsoleUI.ReadInt("교체할 포켓몬을 고르세요 (마지막 번호는 돌아가기)", 1, 7);
                if (input == 7)
                {
                    break;
                }
                else
                {
                    if (string.IsNullOrEmpty(poketmonName[input - 1]))
                    {
                        ConsoleUI.WriteLine("하지만 아무도 없었다...");
                        Thread.Sleep(1000);
                        break;
                    }


                    if (CurrentPoketmon == context.Player.Poketmons[input - 1])
                    {
                        ConsoleUI.WriteLine("이미 나와있는 포켓몬입니다!");
                        Thread.Sleep(1000);
                        break;
                    }

                    if (context.Player.Poketmons[input - 1].IsDead)
                    {
                        ConsoleUI.WriteLine("이미 쓰러진 포켓몬입니다.");
                        Thread.Sleep(1000);
                        break;
                    }

                    ConsoleUI.WriteLine("포켓몬을 교체했다.");
                    CurrentPoketmon = context.Player.Poketmons[input - 1];
                    Thread.Sleep(1000);
                    GameManager.Battle.UseSkill(Enemy, CurrentPoketmon, Enemy.Skills[eindex]);
                }
                break;

            case 4:
                if (context.Random.Next(100) < 70)
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
                    GameManager.Battle.UseSkill(Enemy, CurrentPoketmon, Enemy.Skills[eindex]);
                    Thread.Sleep(1000);
                }
                break;
        }


        if (CurrentPoketmon.IsDead)
        {
            // 포켓몬이 다 쓰러졌는지 확인 만약 다 쓰러졌다면 원래있는곳으로 돌아가기
            for (int i = 0; i < context.Player.Poketmons.Count; i++)
            {
                //포켓몬이 살아있는가? 살았으면 멈춤
                if (!context.Player.Poketmons[i].IsDead)
                {
                    break;
                }
                if (i == context.Player.Poketmons.Count - 1)
                {

                    // 모든 포켓몬이 쓰러지면
                    context.AddLog($"배틀에서 패배했다. {context.Player.Name}는 눈앞이 캄캄해졌다.");
                    Thread.Sleep(1000);
                    // 쓰러진친구들살리기 나중에 함수로 하나 만들어도 괜찮을듯
                    foreach (Poketmon poketmon in context.Player.Poketmons)
                    {
                        poketmon.Hp = poketmon.MaxHp;
                    }
                    IsDefeat = true;
                    context.Map[context.Player.PosY, context.Player.PosX] = '*';
                    GoTo(context, SceneKey.Hometown);
                    break;
                }

            }



            string[] poketmonName = new string[6];
            for (int i = 0; i < context.Player.Poketmons.Count; i++)
            {
                poketmonName[i] = context.Player.Poketmons[i].Name;
            }
            ConsoleUI.WriteBox(new[]
            {
                    $"{Format.FormatCell(poketmonName[0], 6)}{Format.FormatCell(poketmonName[1], 6)}",
                    $"{Format.FormatCell(poketmonName[2], 6)}{Format.FormatCell(poketmonName[3], 6)}",
                    $"{Format.FormatCell(poketmonName[4], 6)}{Format.FormatCell(poketmonName[5], 6)}",
                });
            while (CurrentPoketmon.IsDead)
            {
                input = ConsoleUI.ReadInt("교체할 포켓몬을 고르세요", 1, 6);
                if (context.Player.Poketmons[input - 1].IsDead)
                {
                    ConsoleUI.WriteLine("이미 쓰러진 포켓몬입니다.");
                }
                else
                {
                    CurrentPoketmon = context.Player.Poketmons[input - 1];
                }
            }


        }

    }


}

