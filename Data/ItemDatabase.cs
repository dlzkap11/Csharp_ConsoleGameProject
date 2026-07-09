using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameFramework.Utills;

namespace ConsoleGameFramework.Data;

public static class ItemDatabase
{
    public static Dictionary<int, ItemData> Items { get; private set; } = new Dictionary<int, ItemData>();

    public static void Init()
    {
        Items = new Dictionary<int, ItemData>
        {
            { 1, new ItemData{No = 1, Name = "상처약", Type = Define.ItemType.Heal, Amout = 20 } },
            { 2, new ItemData{No = 2, Name = "몬스터볼", Type = Define.ItemType.Ball, Amout = 60 } },
        };
    }


    public static ItemData GetItem(int no)
    {
        return Items[no];
    }
}
