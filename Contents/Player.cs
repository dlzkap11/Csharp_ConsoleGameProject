using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Contents;

public class Player : Character
{
    const int START_MONEY = 1000;

    /*
     * 플레이어
    - 이름, 포켓몬(최대 6마리), 맵에 나타낼 현재 위치, 돈, 인벤토리
     */
    
    public int PosX { get; private set; }
    public int PosY { get; private set; }
    public int Money { get; private set; }
    
    public List<Poketmon> Poketmons { get; private set; }
    public List<string> Inventory { get; private set; }


    public Player(string name) : base(name)
    {
        PosX = 0;
        PosY = 0;
        Money = START_MONEY;
    }




}
