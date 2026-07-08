using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameFramework.Utills;
using System.Collections.Generic;
namespace ConsoleGameFramework.Data;

public class SkillData
{
    public int No { get; set; }
    public string Name { get; set; }
    public Define.Type Type { get; set; }
    public int Power { get; set; }
    public int Accuracy { get; set; }
    public int PP { get; set; }
}

public class LearnSkillData
{
    public int Level { get; set; }
    public int SkillNo { get; set; }
}

public class PoketmonData
{
    public int No { get; set; }
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Spd { get; set; }
    public Define.Type Type1 { get; set; }
    public Define.Type Type2 { get; set; }
    public List<LearnSkillData> LearnSkills { get; set; } = new List<LearnSkillData>();
}