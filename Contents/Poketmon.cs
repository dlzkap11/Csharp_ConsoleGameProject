using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Contents;

public class PoketmonData
{
    /*
    포켓몬
    - 이름, 레벨, 공격력, 방어력, 타입, 스피드, 기술배치(4개), 야생포켓몬인가 확인
    *특공 특방 성격 지닌 물건 구현 X* 
    */
    public string Name { get; private set; }
    public int Id { get; private set; }
    public int BaseHp { get; private set; }
    public int BaseATK { get; private set; }
    public int BaseDEF { get; private set; }
    public int BaseSpeed { get; private set; }
    public Define.Type PoketmonType { get; private set; }
    public Define.Type PoketmonType2 { get; private set; }

    //도감번호, 이름, 기초체력, 기초공격력, 기초방어력, 기초스피드, 타입1, 타입2(기본 없음)
    public PoketmonData(int id, string name, int hp, int atk, int def, int speed, Define.Type type, Define.Type poketmonType2 = Define.Type.None)
    {
        Name = name;
        Id = id;
        BaseHp = hp;
        BaseATK = atk;
        BaseDEF = def;
        BaseSpeed = speed;

        PoketmonType = type;
        PoketmonType2 = poketmonType2;
    }

}

public class Poketmon
{
    // PoketmonData에서 고정되는 값들을 가져오기
    public PoketmonData _poketmon;

    public int Level { get; private set; }
    public string Nickname { get; set; }
    public int MaxHp { get; private set; }
    public int Hp {  get; private set; }
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public int Speed { get; private set; }


    public bool IsWild { get; private set; }
    public List<Skill> Skills { get; private set; }

    //처음 포켓몬 고르는 생성자
    public Poketmon(string name)
    {
        _poketmon = GameManager.Resource.PoketmonsDict[name];

        if (string.IsNullOrEmpty(name))
            Nickname = _poketmon.Name;
        else
            Nickname = name;

        Level = 5;
        // 레벨에 따라서 스텟차이 두기 ex) ATK = Level * _poketmon.ATK + 10 이런식으로
        Skills = new List<Skill>(4);
    }

    //야생 포켓몬 출현 생성자
    public Poketmon(string name, int level, bool isWild = true)
    {
        _poketmon = GameManager.Resource.PoketmonsDict[name];

        //야생포켓몬을 상속받아야하는가? 고민
        Nickname = name;
        //TODO 레벨은 구간마다 다르게 해야함 흠;
        Level = level;
        Skills = new List<Skill>(4);
    }

    //스킬 배우기
    public void LearnSkill(Poketmon poketmon, string skill, GameContext context)
    {
        //해당하는 스킬이 존재하지않으면 리턴
        if (!GameManager.Resource.SkillDict.ContainsKey(skill))
        {
            context.AddLog($"{skill}은 배울 수 없다.");
            return;
        }


        //스킬이 이미 4개이상있으면 4개 중 하나를 선택해서 지우거나 새로운 스킬을 배우지않는다.
        if (Skills.Count >= 4)
        {
            ConsoleUI.WriteBox(new[]
            {
                $"1){Skills[0],6} 2){Skills[1],6}",
                $"3){Skills[2],6} 4){Skills[3],6}",
                $"5){poketmon.Nickname}은 {skill}을 새로 배우고 싶다..."
            });

            int remove = ConsoleUI.ReadInt("삭제할 스킬을 고르세요", 1, 5);
            if (remove == 5)
            {
                context.AddLog("새로운 기술을 배우지 않았습니다.");
                return;
            }
            else
            {
                remove--;
                context.AddLog($"{poketmon.Nickname}은 {Skills[remove]}를 잊고 {skill}을 배웠다!");
                Skills.RemoveAt(remove);
                poketmon.Skills.Add(new Skill(skill));

            }
        }
        else
        {
            context.AddLog($"{poketmon.Nickname}은 {skill}을 배웠다!");
            poketmon.Skills.Add(new Skill(skill));
        }
    }
}

