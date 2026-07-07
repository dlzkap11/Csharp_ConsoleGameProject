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
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public int Speed { get; private set; }
    public Define.Type PoketmonType { get; private set; }
    

    //이름, 도감번호, 기초공격력, 기초방어력, 기초스피드, 타입
    public PoketmonData(string name, int id, int atk, int def, int speed, Define.Type type)
    {
        Name = name;
        Id = id;
        ATK = atk;
        DEF = def;
        Speed = speed;

        PoketmonType = Define.Type.Grass;

    }

}

public class Poketmon
{
    // PoketmonData에서 고정되는 값들을 가져오기
    public PoketmonData _poketmon;

    public int Level { get; private set; }
    public string Nickname { get; set; }

    public bool IsWild { get; private set; }
    public List<Skill>? Skills { get; private set; }

    public Poketmon(string name)
    {
        _poketmon = GameManager.Resource.PoketmonsDict[name];

        //그거있는데 비었거나 널이거나
        if (string.IsNullOrEmpty(name))
            Nickname = _poketmon.Name;
        else
            Nickname = name;

        //TODO 레벨은 구간마다 다르게 해야함 흠;
        Level = 5;
        Skills?.Add(new Skill());
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
                poketmon.Skills.Add(GameManager.Resource.SkillDict[skill]._skill);

            }
        }
        else
        {
            context.AddLog($"{poketmon.Nickname}은 {skill}을 배웠다!");
            poketmon.Skills.Add(GameManager.Resource.SkillDict[skill]._skill);
        }
    }
}

