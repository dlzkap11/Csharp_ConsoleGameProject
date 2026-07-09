using ConsoleGameFramework.Core;
using ConsoleGameFramework.Utills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameFramework.Data;

namespace ConsoleGameFramework.Contents;

public class Player : Character
{
    const int START_MONEY = 1000;

    /*
     * 플레이어
    - 이름, 포켓몬(최대 6마리), 맵에 나타낼 현재 위치, 돈, 인벤토리
     */
    
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Money { get; private set; }
    
    public List<Poketmon> Poketmons { get; private set; }
    public List<Item> Inventory { get; private set; } = new List<Item>();

    public Player(string name) : base(name)
    { 
        Money = START_MONEY;
        Poketmons = new List<Poketmon>(6);
    }

    // 마지막으로 있었던 장소키
    public SceneKey PrevKey = SceneKey.Hometown;
    public int CurrentMapId { get; set; }


    // 방향
    // 위 아래 왼 오
    private int[] dr = { -1, 1, 0, 0 };
    private int[] dc = { 0, 0, -1, 1 };
    private int dir = 0;

    public char TalkNPC(int pos, GameContext context)
    {
        if (PosY + dr[pos] < 0 || PosY + dr[pos] >= context.Map.GetLength(0) || PosX + dc[pos] < 0 || PosX + dc[pos] >= context.Map.GetLength(1))
            return ' ';

        return context.Map[PosY + dr[pos], PosX + dc[pos]];
    }

    public bool IsWall(int pos, GameContext context)
    {
        //미로 크기 체크

        if (PosY + dr[pos] < 0 || PosY + dr[pos] >= context.Map.GetLength(0) || PosX + dc[pos] < 0 || PosX + dc[pos] >= context.Map.GetLength(1))
            return true;

        char CantGo = context.Map[PosY + dr[pos], PosX + dc[pos]];
        //벽 체크
        if (CantGo == '#' || CantGo == 'H' || CantGo == '~')
            return true;
        else
            return false;
    }

    public void MovePos(int pos, GameContext context)
    {
        if (IsWall(pos, context))
            return;

        // 맵 타일의 원래 모습을 저장
        context.Map[PosY, PosX] = MapData.prevMap;
        PosY += dr[pos];
        PosX += dc[pos];
        MapData.prevMap = context.Map[PosY, PosX];

        if (IsExit(context))
            return;
        context.Map[PosY, PosX] = 'P';
    }

    public bool IsExit(GameContext context)
    {
        if (context.Map[PosY, PosX] == 'E')
            return true;

        return false;
    }

    public void Move(ConsoleKeyInfo keyInfo, GameContext context)
    {
        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            dir = 0;
            MovePos(dir, context);
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            dir = 1;
            MovePos(dir, context);
        }
        else if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            dir = 2;
            MovePos(dir, context);
        }
        else if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            dir = 3;
            MovePos(dir, context);
        }
        else if (keyInfo.Key == ConsoleKey.X)
        {
            // 해당 방향에 H(간호순)이 있으면 전체 회복
            if (TalkNPC(dir, context) == 'H')
            {
                foreach(Poketmon poketmon in Poketmons)
                {
                    poketmon.Hp = poketmon.MaxHp;
                }
                context.AddLog("모든 포켓몬의 체력이 회복되었습니다");
            }
                
            else
                context.AddLog($"{TalkNPC(dir, context)}");
        }
    }


}
