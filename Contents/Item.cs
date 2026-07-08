using ConsoleGameFramework.Core;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Contents;

public class ItemData
{
    // 이름, 뭐 설명 아이디는 없어도 일단은 괜찮을듯
    public string Name { get; private set; }
    public string Explan { get; private set; }
    public Define.ItemType ItemType { get; private set; }

    public ItemData(string name, string explan, Define.ItemType type)
    {
        Name = name;
        Explan = explan;
        ItemType = type;
    }
    
}

public class Item
{
    public ItemData _Item;

    // 해당 아이템 개수표시
    public int Count;

    //기본 1개 지급
    public Item(int cnt = 1)
    {
        Count = cnt;
    } 

    // 아이템 타입에 따라서 사용여부
    public void UseItem(Item item)
    {
        switch (item._Item.ItemType)
        {
            case Define.ItemType.Heal:
                break;
            case Define.ItemType.Ball: 
                break;
            case Define.ItemType.Tool:
                break;
        }
    }

}

