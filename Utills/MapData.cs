using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Utills;

public static class MapData
{
    public static char[,] Map6 =
        {   //Map[y, x]
            {'P','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#','#','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#','E','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
        };

    public static char[,] Map7 =
        {   //Map[y, x]
            {'P','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'.','E','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
        };



    // 이 부분을 삭제하고 MapClass에 복사해주세요.
    // 필요가 없어져따
    public static List<char> MapInit(char[,] map)
    {
        List<char> createmap = new List<char>();

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
