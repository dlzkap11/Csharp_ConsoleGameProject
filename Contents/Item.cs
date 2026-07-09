using ConsoleGameFramework.Core;
using ConsoleGameFramework.Utills;
using ConsoleGameFramework.Data;

namespace ConsoleGameFramework.Contents;

public class Item
{
    public ItemData Data;

    // 해당 아이템 개수표시
    public string Name { get; private set; }
    public int Amount { get; private set; }
    public int Count;

    public Define.ItemType Type { get; private set; }
    public Item(ItemData data, int cnt)
    {
        Data = data;
        Name = data.Name;
        Amount = data.Amout;
        Type = data.Type;
        Count = cnt;
    } 

    // 아이템 타입에 따라서 사용여부
    public void UseItem(Item item)
    {
        switch (Data.Type)
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

