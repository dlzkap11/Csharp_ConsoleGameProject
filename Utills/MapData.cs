using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Utills;

public static class MapData
{
    // Player 위치 이동전 원래 타일을 저장함
    public static char prevMap;
    public static int startPointX;
    public static int startPointY;

    public static char[,] Map6 =
        {   //Map[y, x]
            {'.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'.','.','.','.','S','.','#','.','.','#','#','#','#','#','#','#','#'},
            {'#','#','.','#','#','.','.','.','.','*','*','*','*','*','*','*','.'},
            {'#','E','.','H','#','#','#','.','.','*','*','*','*','*','*','*','.'}
        };

    public static char[,] Map7 =
        {   //Map[y, x]
            {'.','.','#','#','#','#','S','#','#','#','#','#','#','#','#','#','#'},
            {'.','.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#'},
            {'.','.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#'},
            {'.','.','.','.','E','.','.','.','#','#','#','#','#','#','#','#','#'},
            {'.','.','.','.','.','.','.','#','#','#','#','#','#','#','#','#','#'},
            {'*','*','*','*','*','.','.','#','#','#','#','#','#','#','#','#','#'},
            {'*','*','*','*','*','.','.','#','#','#','#','#','#','#','#','#','#'}

        };

    public static void MapInit(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 'S')
                {
                    startPointY = i;
                    startPointX = j;
                    return;
                } 
            }
        }
    }
}
