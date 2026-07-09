using ConsoleGameFramework.Utills;
using System.Collections.Generic;

namespace ConsoleGameFramework.Data;

public static class PoketmonDatabase
{
    public static Dictionary<int, PoketmonData> Poketmons { get; private set; } = new Dictionary<int, PoketmonData>();

    public static void Init()
    {
        Poketmons = new Dictionary<int, PoketmonData>
        {
            [1] = new PoketmonData
            {
                No = 1,
                Name = "이상해씨",
                Hp = 10, //45
                Atk = 65,
                Def = 65,
                Spd = 45,
                Type1 = Define.Type.Grass,
                Type2 = Define.Type.Poison,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 1 },
                    new LearnSkillData { Level = 1, SkillNo = 2 },
                    new LearnSkillData { Level = 7, SkillNo = 4 },
                    new LearnSkillData { Level = 13, SkillNo = 9 }
                }
            },

            [4] = new PoketmonData
            {
                No = 4,
                Name = "파이리",
                Hp = 39,
                Atk = 60,
                Def = 50,
                Spd = 65,
                Type1 = Define.Type.Fire,
                Type2 = Define.Type.None,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 1 },
                    new LearnSkillData { Level = 1, SkillNo = 8 },
                    new LearnSkillData { Level = 7, SkillNo = 5 }
                }
            },

            [7] = new PoketmonData
            {
                No = 7,
                Name = "꼬부기",
                Hp = 44,
                Atk = 50,
                Def = 65,
                Spd = 43,
                Type1 = Define.Type.Water,
                Type2 = Define.Type.None,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 3 },
                    new LearnSkillData { Level = 1, SkillNo = 2 },
                    new LearnSkillData { Level = 7, SkillNo = 6 }
                }
            },

            [16] = new PoketmonData
            {
                No = 16,
                Name = "구구",
                Hp = 40,
                Atk = 45,
                Def = 40,
                Spd = 56,
                Type1 = Define.Type.Normal,
                Type2 = Define.Type.Flying,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 1 },
                    new LearnSkillData { Level = 1, SkillNo = 10 },
                    new LearnSkillData { Level = 7, SkillNo = 12 }
                }
            },

            [17] = new PoketmonData
            {
                No = 17,
                Name = "피죤",
                Hp = 63,
                Atk = 60,
                Def = 55,
                Spd = 71,
                Type1 = Define.Type.Normal,
                Type2 = Define.Type.Flying,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 1 },
                    new LearnSkillData { Level = 1, SkillNo = 10 },
                    new LearnSkillData { Level = 7, SkillNo = 11 },
                    new LearnSkillData { Level = 8, SkillNo = 12 }

                }
            },

            [18] = new PoketmonData
            {
                No = 18,
                Name = "피죤투",
                Hp = 83,
                Atk = 80,
                Def = 75,
                Spd = 101,
                Type1 = Define.Type.Normal,
                Type2 = Define.Type.Flying,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 1 },
                    new LearnSkillData { Level = 1, SkillNo = 10 },
                    new LearnSkillData { Level = 7, SkillNo = 11 },
                    new LearnSkillData { Level = 8, SkillNo = 12 }

                }
            },

            [19] = new PoketmonData
            {
                No = 19,
                Name = "꼬렛",
                Hp = 30,
                Atk = 56,
                Def = 35,
                Spd = 72,
                Type1 = Define.Type.Normal,
                Type2 = Define.Type.None,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 3 },
                    new LearnSkillData { Level = 1, SkillNo = 2 },
                    new LearnSkillData { Level = 4, SkillNo = 14 },
                    new LearnSkillData { Level = 6, SkillNo = 13 }

                }
            },

            [20] = new PoketmonData
            {
                No = 20,
                Name = "레트라",
                Hp = 55,
                Atk = 81,
                Def = 70,
                Spd = 97,
                Type1 = Define.Type.Normal,
                Type2 = Define.Type.None,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 3 },
                    new LearnSkillData { Level = 1, SkillNo = 2 },
                    new LearnSkillData { Level = 4, SkillNo = 14 },
                    new LearnSkillData { Level = 6, SkillNo = 13 }

                }
            },

            [25] = new PoketmonData
            {
                No = 25,
                Name = "피카츄",
                Hp = 35,
                Atk = 55,
                Def = 50,
                Spd = 90,
                Type1 = Define.Type.Electric,
                Type2 = Define.Type.None,
                LearnSkills = new List<LearnSkillData>
                {
                    new LearnSkillData { Level = 1, SkillNo = 3 },
                    new LearnSkillData { Level = 1, SkillNo = 2 },
                    new LearnSkillData { Level = 4, SkillNo = 7 },
                    new LearnSkillData { Level = 6, SkillNo = 14 }

                }
            }
        };
    }

    public static PoketmonData GetPokemon(int no)
    {
        return Poketmons[no];
    }
}