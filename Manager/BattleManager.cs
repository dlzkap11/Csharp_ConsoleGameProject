using ConsoleGameFramework.Contents;
using ConsoleGameFramework.Core;
using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Manager;

public class BattleManager
{
    int levelScale;
    List<string> poketmons = new List<string>();


    public Poketmon WildPoketmonAppeared(GameContext context)
    {
        int rLevel = context.Random.Next(levelScale - 1, levelScale + 2);
        int rName = context.Random.Next(0, poketmons.Count);

        // 야생 포켓몬 생성
        context.AddLog($"야생의 {poketmons[rName]}이 나타났다!");
        Poketmon wildPoketmon = new Poketmon(poketmons[rName], rLevel);
        return wildPoketmon;
    }

    // 포켓몬을 마주쳤을 때 해당 필드의 레벨스케일과 포켓몬배열을 가져온다
    public void GetFiled(int scale, string[] wpoketmons)
    {
        poketmons.Clear();
        levelScale = scale;
        for(int i = 0; i < wpoketmons.Length; i++)
        {
            poketmons.Add(wpoketmons[i]);
        }
    }

    // 데미지 계산
    public int CalculateDamage(Poketmon atkP, Poketmon defP)
    {
        float multiper = TypeEffectiveness.GetFinalMultiplier(atkP._poketmon.PoketmonType, defP._poketmon.PoketmonType, defP._poketmon.PoketmonType2);

        int damage = 0;

        /* 뿌킷몬 데미지 공식
         * int damage =
                (int)(((2 * level / 5.0 + 2) * power * attack / defense) / 50 + 2);

            damage = (int)(damage * stab * typeMultiplier * randomMultiplier);
         */

        // Math.Abs((포켓몬 방어력) - (포켓몬 공격력 + 기술위력)) * 상성데미지
        return 0;
    }

    // 내 포켓몬, 상대 포켓몬, 내가 쓴 기술(skill[index])
    public void GetBattle(Poketmon myP, Poketmon enemyP, int index)
    {
        //상대와 나의 속도 비교 후 더 빠른 쪽이 먼저 공격
        if (myP.Speed < enemyP.Speed)
        {
            myP.Hp -= enemyP.ATK;
            if (myP.IsDead)
                return;
            enemyP.Hp -= myP.ATK;
        }
        else
        {
            enemyP.Hp -= myP.ATK;
            if (enemyP.IsDead)
                return;
            myP.Hp -= myP.ATK;
        }
            
    }

    //도망실패시 상대만 공격

    //아이템사용시 상대만 공격

    //포켓몬교체시 상대만 공격
    // 하나로 모아서 내가 한 행동만 받아서 잘하고 상대 공격라인만 쓰면 될 듯
    public void EnemyAttack(Poketmon myP, Poketmon enemyP, int choice)
    {
        // choice 2, 3 ,4 각각 아이템사용 포켓몬교체 도망치기
        if(choice == 2)
        {
            
        }
        else if(choice == 3)
        {

        }
        else if(choice == 4)
        {

        }
        
    }



    public enum BattleOutcome
    {
        Continuing,
        Victory,
        Defeat
    }
}

