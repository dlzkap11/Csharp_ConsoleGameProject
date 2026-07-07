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

        public void SkillDataInput()
        {
            SkillDict.Add("몸통박치기", new SkillData());
        }

        //이름, 도감번호, 기초공격력, 기초방어력, 기초스피드, 타입
        public void PoketmonDataInput()
        {
            PoketmonsDict.Add("피카츄", new PoketmonData("피카츄", 11, 6, 7, 12, Define.Type.Normal));
            PoketmonsDict.Add("이상해씨", new PoketmonData("이상해씨", 11, 6, 7, 12, Define.Type.Normal));
            PoketmonsDict.Add("파이리", new PoketmonData("파이리", 11, 6, 7, 12, Define.Type.Normal));
            PoketmonsDict.Add("꼬부기", new PoketmonData("꼬부기", 11, 6, 7, 12, Define.Type.Normal));
        }
    }
}
