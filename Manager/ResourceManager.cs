using ConsoleGameFramework.Contents;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Manager
{
    public class ResourceManager
    {

        public Player Player { get; private set; }
        public Poketmon Poketmon { get; private set; }

        public void PlayerInit(string name)
        {
            Player = new Player(name);
        }
        /*
        //아이템이름, 설명, 아이템타입
        public void ItemDataInput()
        {   
            ItemsDict.Add("회복약", new ItemData("회복약", "HP를 20회복한다.", Define.ItemType.Heal));
            ItemsDict.Add("몬스터볼", new ItemData("몬스터볼", "야생 포켓몬을 잡을 수 있다.", Define.ItemType.Ball));
            //물가에서 사용하면 일정확률로 포켓몬과 배틀... 일단 보류
            ItemsDict.Add("좋은 낚시대", new ItemData("좋은 낚시대", "물가에서 낚시를 할 수 있다.", Define.ItemType.Tool));
        }
        */
    }
}
