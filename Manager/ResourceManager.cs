using ConsoleGameFramework.Contents;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Manager
{
    public class ResourceManager
    {
        public Dictionary<string, PoketmonData> PoketmonsDict = new Dictionary<string, PoketmonData>();
        //Dictionary<string, ToolsData> ToolsDict
        //Dictionary<string, SkillData> SkillDict
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
        //기술이름, 위력, 명중률, PP, 기술타입
        public void SkillDataInput()
        {
            SkillDict.Add("몸통박치기", new SkillData("몸통박치기", 60, 80, 30, Define.Type.Normal));
            SkillDict.Add("발버둥", new SkillData("발버둥", 30, 80, 99, Define.Type.None));
        }

        //도감번호, 이름, 기초체력, 기초공격력, 기초방어력, 기초스피드, 타입1, 타입2
        public void PoketmonDataInput()
        {
            PoketmonsDict.Add("이상해씨", new PoketmonData(1, "이상해씨", 20, 8, 10, 8, Define.Type.Grass));
            PoketmonsDict.Add("파이리", new PoketmonData(4, "파이리", 13, 9, 7, 10, Define.Type.Water));
            PoketmonsDict.Add("꼬부기", new PoketmonData(7, "꼬부기", 18, 7, 12, 9, Define.Type.Fire));
            PoketmonsDict.Add("피카츄", new PoketmonData(25, "피카츄", 12, 8, 8, 13, Define.Type.Electric));
        }
    }
}
