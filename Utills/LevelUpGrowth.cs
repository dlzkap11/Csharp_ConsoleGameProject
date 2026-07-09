using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Utills;

public static class LevelUpGrowth
{
    public static int GetHpGain(int level) => 2 + level / 10;
    public static int GetAtkGain(int level) => 1 + level / 20;
    public static int GetDefGain(int level) => 1 + level / 20;
    public static int GetSpdGain(int level) => 1 + level / 25;
    public static int GetExpGain(int level) => 2 + level * 2;
}
