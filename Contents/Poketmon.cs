using ConsoleGameFramework.Data;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Utills;


namespace ConsoleGameFramework.Contents;



public class Poketmon
{
    public PoketmonData Data { get; private set; }
    public int Level { get; private set; }
    public int MaxExp { get; private set; }
    public int Exp { get; set; }
    public int MaxHp { get; private set; }
    private int hp;
    public int Hp
    {
        get => hp;
        set
        {
            hp = Math.Clamp(value, 0, MaxHp);
        }
    }
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
        Nickname = Name;
        MaxExp = 2 + Level * 2;
        Exp = 0;
        PoketmonStatsByLevelInit();
        PoketmonSkillsByLevelInit();
    }

    private void PoketmonStatsByLevelInit()
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

    private void PoketmonSkillsByLevelInit()
    {
        Skills.Clear();

        List<LearnSkillData> learnedSkills = new List<LearnSkillData>();

        for (int i = 0; i < Data.LearnSkills.Count; i++)
        {
            if (Data.LearnSkills[i].Level <= Level)
            {
                learnedSkills.Add(Data.LearnSkills[i]);
            }
        }

        learnedSkills.Sort((a, b) =>
        {
            int levelCompare = a.Level.CompareTo(b.Level);
            if (levelCompare != 0)
                return levelCompare;

            return a.SkillNo.CompareTo(b.SkillNo);
        });

        for (int i = 0; i < learnedSkills.Count; i++)
        {
            SkillData skill = SkillDatabase.GetSkill(learnedSkills[i].SkillNo);

            bool alreadyHasSkill = false;
            for (int j = 0; j < Skills.Count; j++)
            {
                if (Skills[j].No == skill.No)
                {
                    alreadyHasSkill = true;
                    break;
                }
            }

            if (!alreadyHasSkill)
            {
                if (Skills.Count < 4)
                    Skills.Add(skill);
            }
        }
    }

    public void LevelUp()
    {
        Level++;
        Exp = 0;
        MaxHp += LevelUpGrowth.GetHpGain(Level);
        Atk += LevelUpGrowth.GetAtkGain(Level);
        Def += LevelUpGrowth.GetDefGain(Level);
        Spd += LevelUpGrowth.GetSpdGain(Level);
        MaxExp = LevelUpGrowth.GetExpGain(Level);
        Hp += LevelUpGrowth.GetHpGain(Level);
        if (Hp > MaxHp)
            Hp = MaxHp;

        LearnSkillsByLevel();
    }

    private void LearnSkillsByLevel()
    {
        List<LearnSkillData> learnList = new List<LearnSkillData>();

        for (int i = 0; i < Data.LearnSkills.Count; i++)
        {
            if (Data.LearnSkills[i].Level == Level)
            {
                learnList.Add(Data.LearnSkills[i]);
            }
        }

        learnList.Sort((a, b) => a.SkillNo.CompareTo(b.SkillNo));

        for (int i = 0; i < learnList.Count; i++)
        {
            SkillData skill = SkillDatabase.GetSkill(learnList[i].SkillNo);

            bool alreadyHasSkill = false;
            for (int j = 0; j < Skills.Count; j++)
            {
                if (Skills[j].No == skill.No)
                {
                    alreadyHasSkill = true;
                    break;
                }
            }

            if (alreadyHasSkill)
                continue;

            if (Skills.Count < 4)
            {
                Skills.Add(skill);
                ConsoleUI.WriteLine($"{Name}이(가) {skill.Name}을(를) 배웠다!");
                Thread.Sleep(1000);
            }
            else
            {
                ConsoleUI.WriteLine($"{Name}은(는) 이미 기술을 4개 알고 있다. {skill.Name}을(를) 배울 수 없다!");
                Thread.Sleep(1000);
            }
        }
    }
}