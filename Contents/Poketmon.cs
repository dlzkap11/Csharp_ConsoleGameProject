using ConsoleGameFramework.Core;
using ConsoleGameFramework.Manager;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleGameFramework.Contents;

using ConsoleGameFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;

public class Poketmon
{
    public PoketmonData Data { get; private set; }
    public int Level { get; private set; }

    public int MaxHp { get; private set; }
    public int Hp { get; set; }
    public int Atk { get; private set; }
    public int Def { get; private set; }
    public int Spd { get; private set; }
    public bool IsDead => Hp <= 0;
    public List<SkillData> Skills { get; private set; } = new List<SkillData>();

    public string Name => Data.Name;
    public string Nickname;
    public Define.Type Type1 => Data.Type1;
    public Define.Type Type2 => Data.Type2;

    public Poketmon(PoketmonData data, int level)
    {
        Data = data;
        Level = level;

        InitializeStatsByLevel();
        InitializeSkillsByLevel();
    }

    private void InitializeStatsByLevel()
    {
        MaxHp = Data.Hp;
        Atk = Data.Atk;
        Def = Data.Def;
        Spd = Data.Spd;

        for (int i = 1; i < Level; i++)
        {
            MaxHp += LevelUpGrowth.GetHpGain(i);
            Atk += LevelUpGrowth.GetAtkGain(i);
            Def += LevelUpGrowth.GetDefGain(i);
            Spd += LevelUpGrowth.GetSpdGain(i);
        }

        Hp = MaxHp;
    }

    private void InitializeSkillsByLevel()
    {
        Skills.Clear();

        var learnedSkills = Data.LearnSkills
            .Where(x => x.Level <= Level)
            .OrderBy(x => x.Level)
            .ThenBy(x => x.SkillNo)
            .ToList();

        foreach (var learn in learnedSkills)
        {
            SkillData skill = SkillDatabase.GetSkill(learn.SkillNo);

            if (!Skills.Any(x => x.No == skill.No))
            {
                if (Skills.Count < 4)
                    Skills.Add(skill);
            }
        }
    }

    public void LevelUp()
    {
        Level++;

        MaxHp += LevelUpGrowth.GetHpGain(Level);
        Atk += LevelUpGrowth.GetAtkGain(Level);
        Def += LevelUpGrowth.GetDefGain(Level);
        Spd += LevelUpGrowth.GetSpdGain(Level);

        Hp += LevelUpGrowth.GetHpGain(Level);
        if (Hp > MaxHp)
            Hp = MaxHp;

        LearnSkillsByLevel();
    }

    private void LearnSkillsByLevel()
    {
        var learnList = Data.LearnSkills
            .Where(x => x.Level == Level)
            .OrderBy(x => x.SkillNo)
            .ToList();

        foreach (var learn in learnList)
        {
            SkillData skill = SkillDatabase.GetSkill(learn.SkillNo);

            if (Skills.Any(x => x.No == skill.No))
                continue;

            if (Skills.Count < 4)
            {
                Skills.Add(skill);
                Console.WriteLine($"{Name}이(가) {skill.Name}을(를) 배웠다!");
            }
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 기술을 4개 알고 있다. {skill.Name}을(를) 배울 수 없다!");
            }
        }
    }
}