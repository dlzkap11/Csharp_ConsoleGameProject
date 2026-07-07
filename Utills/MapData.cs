using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Utills;

public static class MapData
{
    public static string[,] Map4 =
        {   //Map[y, x]
            {"..###############"},
            {"#...............#"},
            {"#..............E#"},
            {"#################" }
        };



    // 이 부분을 삭제하고 MapClass에 복사해주세요.
    public static List<string> MapInit(string[,] map)
    {
        List<string> createmap = new List<string>();

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                createmap.Add(map[i, j]);
            }
        }
        return createmap;
    }
}
