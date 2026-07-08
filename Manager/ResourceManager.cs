using ConsoleGameFramework.Contents;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Manager
{
    public class ResourceManager
    {
        public Dictionary<string, PoketmonData> PoketmonsDict = new Dictionary<string, PoketmonData>();
        public Dictionary<string, ItemData> ItemsDict = new Dictionary<string, ItemData>();
        public Dictionary<string, SkillData> SkillDict = new Dictionary<string, SkillData>();
        //Dictionary<string, MapData> MapDict

        public Player Player { get; private set; }
        public Poketmon Poketmon { get; private set; }

        public void PlayerInit(string name)
        {
            Player = new Player(name);
        }

        public Poketmon PoketmonInit(string name)
        {
            Poketmon = new Poketmon(name);
            return Poketmon;
        }

        //아이템이름, 설명, 아이템타입
        public void ItemDataInput()
        {   
            ItemsDict.Add("회복약", new ItemData("회복약", "HP를 20회복한다.", Define.ItemType.Heal));
            ItemsDict.Add("몬스터볼", new ItemData("몬스터볼", "야생 포켓몬을 잡을 수 있다.", Define.ItemType.Ball));
            ItemsDict.Add("좋은 낚시대", new ItemData("좋은 낚시대", "물가에서 낚시를 할 수 있다.", Define.ItemType.Tool));
        }

        //기술이름, 위력, 명중률, PP, 기술타입
        public void SkillDataInput()
        {
            SkillDict.Add("몸통박치기", new SkillData("몸통박치기", 60, 80, 30, Define.Type.Normal));
            SkillDict.Add("발버둥", new SkillData("발버둥", 30, 80, 99, Define.Type.None));
        }

        //도감번호, 이름, 기초체력, 기초공격력, 기초방어력, 기초스피드, 타입1, 타입2
        public void PoketmonDataInput()
        {
            PoketmonsDict.Add("이상해씨", new PoketmonData(1, "이상해씨", 45, 49, 49, 45, Define.Type.Grass, Define.Type.Poison));
            PoketmonsDict.Add("파이리", new PoketmonData(4, "파이리", 39, 52, 43, 65, Define.Type.Water));
            PoketmonsDict.Add("꼬부기", new PoketmonData(7, "꼬부기", 44, 48, 65, 43, Define.Type.Fire));
            PoketmonsDict.Add("구구", new PoketmonData(16, "구구", 40, 45, 40, 56, Define.Type.Normal, Define.Type.Flying));
            PoketmonsDict.Add("꼬렛", new PoketmonData(19, "꼬렛", 30, 56, 35, 72, Define.Type.Normal));
            PoketmonsDict.Add("피카츄", new PoketmonData(25, "피카츄", 12, 8, 8, 13, Define.Type.Electric));
        }
    }
}
