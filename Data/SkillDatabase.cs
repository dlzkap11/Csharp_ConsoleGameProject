using ConsoleGameFramework.Utills;
using System.Collections.Generic;

namespace ConsoleGameFramework.Data;

public static class SkillDatabase
{
    public static Dictionary<int, SkillData> Skills { get; private set; } = new Dictionary<int, SkillData>();

    public static void Init()
    {
        Skills = new Dictionary<int, SkillData>
        {
            { 1, new SkillData { No = 1, Name = "울음소리", Type = Define.Type.Normal, Power = 0, Accuracy = 100, PP = 40 } },
            { 2, new SkillData { No = 2, Name = "몸통박치기", Type = Define.Type.Normal, Power = 40, Accuracy = 100, PP = 35 } },
            { 3, new SkillData { No = 3, Name = "꼬리흔들기", Type = Define.Type.Grass, Power = 0, Accuracy = 90, PP = 10 } },
            { 4, new SkillData { No = 4, Name = "덩굴채찍", Type = Define.Type.Grass, Power = 45, Accuracy = 100, PP = 25 } },
            { 5, new SkillData { No = 5, Name = "불꽃세례", Type = Define.Type.Fire, Power = 40, Accuracy = 100, PP = 25 } },
            { 6, new SkillData { No = 6, Name = "물대포", Type = Define.Type.Water, Power = 40, Accuracy = 100, PP = 25 } },
            { 7, new SkillData { No = 7, Name = "전기쇼크", Type = Define.Type.Electric, Power = 40, Accuracy = 100, PP = 30 } },
        };
    }

    public static SkillData GetSkill(int no)
    {
        return Skills[no];
    }
}