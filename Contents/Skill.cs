using ConsoleGameFramework.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Contents
{
    public class Skill
    {
        /*
        기술
        - 이름, 위력, 명중률, PP, 타입
        */

        public string Name { get; private set; }
        public int Power { get; private set; }
        public int Accuracy { get; private set; }
        public int PP { get; private set; }

        public Define.Type SkillType { get; private set; }


        public Skill()
        {

        }

    }


    public class SkillData
    {
        public Skill _skill;


    }
}
