using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Data;
using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.Collections;
using System.Reflection;
using static ConsoleGameFramework.Utills.Define;

namespace ConsoleGameFramework.Manager;

public class BattleManager
{
    int levelScale;
    List<int> poketmons = new List<int>();


    public Poketmon WildPoketmonAppeared(GameContext context)
    {
        int rLevel = context.Random.Next(levelScale - 1, levelScale + 2);
        int rNo = context.Random.Next(0, poketmons.Count);

        // 야생 포켓몬 생성
        PoketmonData data = PoketmonDatabase.GetPokemon(poketmons[rNo]);
        context.AddLog($"야생의 {data.Name}이 나타났다!");
        
        Poketmon wildPoketmon = new Poketmon(data, rLevel);
        return wildPoketmon;
    }

    // 포켓몬을 마주쳤을 때 해당 필드의 레벨스케일과 포켓몬배열을 가져온다
    public void GetFiled(int scale, int[] wpoketmons)
    {
        poketmons.Clear();
        levelScale = scale;
        for(int i = 0; i < wpoketmons.Length; i++)
        {
            poketmons.Add(wpoketmons[i]);
        }
    }

    // 데미지 계산
    public int CalculateDamage(Poketmon atkP, Poketmon defP, SkillData skill)
    {
        float multiper = TypeEffectiveness.GetFinalMultiplier(skill.Type, defP.Type1, defP.Type2);
        float stab = 1.0f;
        // 기술과 포켓몬 타입이 같으면 1.5배
        if (atkP.Type1 == skill.Type || atkP.Type2 == skill.Type)
            stab = 1.5f;

        int damage = (int)(((2 * atkP.Level / 5.0 + 2) * skill.Power * atkP.Atk / defP.Def) / 50 + 2);

        damage = damage = (int)(damage * stab * multiper);

        return damage;
    }

    // 내 포켓몬, 상대 포켓몬, 내가 쓴 기술(skill[index])
    public void GetBattle(Poketmon myP, Poketmon enemyP, int index)
    {
        //상대와 나의 속도 비교 후 더 빠른 쪽이 먼저 공격
        Random rand = new Random();
        int eindex = rand.Next(0, 4);
        //적 스킬개수보다 eindex가 클 경우 리롤
        while (eindex >= enemyP.Skills.Count)
            eindex = rand.Next(0, 4);

        if (myP.Spd < enemyP.Spd)
        {
            UseSkill(enemyP, myP, enemyP.Skills[eindex]);
            Thread.Sleep(1000);
            if (myP.IsDead)
                return;
            UseSkill(myP, enemyP, myP.Skills[index]);
            Thread.Sleep(1000);
        }
        else
        {
            UseSkill(myP, enemyP, myP.Skills[index]);
            Thread.Sleep(1000);
            if (enemyP.IsDead)
                return;
            UseSkill(enemyP, myP, enemyP.Skills[eindex]);
            Thread.Sleep(1000);
        }
            
    }

    //도망실패시 상대만 공격

    //아이템사용시 상대만 공격

    //포켓몬교체시 상대만 공격
    // 하나로 모아서 내가 한 행동만 받아서 잘하고 상대 공격라인만 쓰면 될 듯
    public void EnemyAttack(Poketmon myP, Poketmon enemyP, int choice)
    {
        Random rand = new Random();
        int eindex = rand.Next(0, 4);
        //적 스킬개수보다 eindex가 클 경우 리롤
        while (eindex >= enemyP.Skills.Count)
            eindex = rand.Next(0, 4);

        // choice 2, 3 ,4 각각 아이템사용 포켓몬교체 도망치기
        if (choice == 2)
        {
            
        }
        else if(choice == 3)
        {

        }
        else if(choice == 4)
        {
            UseSkill(enemyP, myP, enemyP.Skills[eindex]);
            Thread.Sleep(1000);
        }
        
    }

    private void UseSkill(Poketmon attacker, Poketmon defender, SkillData skill)
    {
        ConsoleUI.WriteLine($"{attacker.Nickname}이(가) {skill.Name}을(를) 사용했다!");
        
        if (skill.Power != 0)
        {
            float typeMul = TypeEffectiveness.GetFinalMultiplier(skill.Type, defender.Type1, defender.Type2);
            int damage = CalculateDamage(attacker, defender, skill);

            defender.Hp -= damage;
            if (defender.Hp < 0)
                defender.Hp = 0;
            ConsoleUI.ClearCurrentLine();
            ConsoleUI.WriteLine($"{defender.Nickname}에게 {damage} 데미지!");
        }
        else if (skill.Power == 0)
        {
            if(skill.Name == "울음소리")
            {
                //공떨
                ConsoleUI.ClearCurrentLine();
                ConsoleUI.WriteLine($"{defender.Nickname}의 공격이 떨어졌다!");
            }
            else if(skill.Name == "꼬리흔들기")
            {
                //방떨
                ConsoleUI.ClearCurrentLine();
                ConsoleUI.WriteLine($"{defender.Nickname}의 방어력이 떨어졌다!");
            }
        }
    }

    public enum BattleOutcome
    {
        Continuing,
        Victory,
        Defeat
    }
}

