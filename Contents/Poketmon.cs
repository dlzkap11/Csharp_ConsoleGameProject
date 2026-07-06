using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Contents;

public class Poketmon
{
    /*
    포켓몬
    - 이름, 레벨, 공격력, 방어력, 타입, 스피드, 기술배치(4개), 야생포켓몬인가 확인
    *특공 특방 성격 지닌 물건 구현 X* 
    */
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public int Speed { get; private set; }

    public bool IsWild { get; private set; }

    public Define.Type PoketmonType { get; private set; }
    public List<Skill> Skills { get; private set; }
    




}

