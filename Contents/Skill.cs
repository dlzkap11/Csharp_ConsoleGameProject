using ConsoleGameFramework.Manager;
using ConsoleGameFramework.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleGameFramework.Contents
{
    public class SkillData
    {
        /*
        기술
        - 이름, 위력, 명중률, PP, 타입
        */
        public string Name { get; private set; }
        public int Power { get; private set; }
        public int Accuracy { get; private set; }
        public int MaxPP { get; private set; }
        public Define.Type SkillType { get; private set; }

        public SkillData(string name, int power, int acc, int pp, Define.Type type)
        {
            Name = name;
            Power = power;
            Accuracy = acc;
            MaxPP = pp;
            SkillType = type;
        }
    }

    public class Skill
    {
        public SkillData _skill;

        public int PP { get; private set; }

        public Skill(string name)
        {
            _skill = GameManager.Resource.SkillDict[name];
            PP = _skill.MaxPP;
        }
    }
}
