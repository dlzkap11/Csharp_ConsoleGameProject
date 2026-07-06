
using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Contents;

public class Character
{
    /*
    NPC
    - 상점 NPC
    -파는 물건 리스트, 물건 가격
    - 간호순 - 
    - 상호작용시 가지고있는 포켓몬들의 체력 및 상태이상 PP 회복
    // 간호순이나 상점 NPC는 굳이 객체로 가지는것보다는 그냥 맵에 특정 형태로 박아둬도 괜찮을 것 같음 상점은 뭐 S, 간호순은 H 이런식으로
    
    -트레이너
    - 이름, 포켓몬 리스트
    */

    public string Name { get; private set; }
    //public List<Poketmon> poketmons { get; private set; }

    public Character(string name)
    {
        Name = name;
    }


}


