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
            { 8, new SkillData { No = 8, Name = "할퀴기", Type = Define.Type.Normal, Power = 55, Accuracy = 80, PP = 30 } },
            { 9, new SkillData { No = 9, Name = "잎날가르기", Type = Define.Type.Grass, Power = 65, Accuracy = 80, PP = 20 } },
            { 10, new SkillData { No = 10, Name = "쪼기", Type = Define.Type.Flying, Power = 35, Accuracy = 100, PP = 20 } },
            { 11, new SkillData { No = 11, Name = "진흙뿌리기", Type = Define.Type.Ground, Power = 20, Accuracy = 100, PP = 10 } },
            { 12, new SkillData { No = 12, Name = "바람일으키기", Type = Define.Type.Flying, Power = 40, Accuracy = 100, PP = 15 } },
            { 13, new SkillData { No = 13, Name = "물기", Type = Define.Type.Dark, Power = 60, Accuracy = 100, PP = 15 } },
            { 14, new SkillData { No = 14, Name = "전광석화", Type = Define.Type.Normal, Power = 40, Accuracy = 100, PP = 15 } },
        };
    }

    public static SkillData GetSkill(int no)
    {
        return Skills[no];
    }
}