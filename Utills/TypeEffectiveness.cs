using System.Collections.Generic;
namespace ConsoleGameFramework.Utills;

public static class TypeEffectiveness
{
    public static readonly Dictionary<Define.Type, Dictionary<Define.Type, float>> Table
        = new Dictionary<Define.Type, Dictionary<Define.Type, float>>
    {
        {
            Define.Type.Normal, new Dictionary<Define.Type, float>
            {
                { Define.Type.Rock, 0.5f },
                { Define.Type.Steel, 0.5f },
                { Define.Type.Ghost, 0.0f }
            }
        },
        {
            Define.Type.Fire, new Dictionary<Define.Type, float>
            {
                { Define.Type.Grass, 2.0f },
                { Define.Type.Ice, 2.0f },
                { Define.Type.Bug, 2.0f },
                { Define.Type.Steel, 2.0f },
                { Define.Type.Fire, 0.5f },
                { Define.Type.Water, 0.5f },
                { Define.Type.Rock, 0.5f },
                { Define.Type.Dragon, 0.5f }
            }
        },
        {
            Define.Type.Water, new Dictionary<Define.Type, float>
            {
                { Define.Type.Fire, 2.0f },
                { Define.Type.Ground, 2.0f },
                { Define.Type.Rock, 2.0f },
                { Define.Type.Water, 0.5f },
                { Define.Type.Grass, 0.5f },
                { Define.Type.Dragon, 0.5f }
            }
        },
        {
            Define.Type.Grass, new Dictionary<Define.Type, float>
            {
                { Define.Type.Water, 2.0f },
                { Define.Type.Ground, 2.0f },
                { Define.Type.Rock, 2.0f },
                { Define.Type.Fire, 0.5f },
                { Define.Type.Grass, 0.5f },
                { Define.Type.Poison, 0.5f },
                { Define.Type.Flying, 0.5f },
                { Define.Type.Bug, 0.5f },
                { Define.Type.Dragon, 0.5f },
                { Define.Type.Steel, 0.5f }
            }
        },
        {
            Define.Type.Electric, new Dictionary<Define.Type, float>
            {
                { Define.Type.Water, 2.0f },
                { Define.Type.Flying, 2.0f },
                { Define.Type.Electric, 0.5f },
                { Define.Type.Grass, 0.5f },
                { Define.Type.Dragon, 0.5f },
                { Define.Type.Ground, 0.0f }
            }
        },
        {
            Define.Type.Ice, new Dictionary<Define.Type, float>
            {
                { Define.Type.Grass, 2.0f },
                { Define.Type.Ground, 2.0f },
                { Define.Type.Flying, 2.0f },
                { Define.Type.Dragon, 2.0f },
                { Define.Type.Fire, 0.5f },
                { Define.Type.Water, 0.5f },
                { Define.Type.Ice, 0.5f },
                { Define.Type.Steel, 0.5f }
            }
        },
        {
            Define.Type.Fighting, new Dictionary<Define.Type, float>
            {
                { Define.Type.Normal, 2.0f },
                { Define.Type.Ice, 2.0f },
                { Define.Type.Rock, 2.0f },
                { Define.Type.Dark, 2.0f },
                { Define.Type.Steel, 2.0f },
                { Define.Type.Poison, 0.5f },
                { Define.Type.Flying, 0.5f },
                { Define.Type.Psychic, 0.5f },
                { Define.Type.Bug, 0.5f },
                { Define.Type.Fairy, 0.5f },
                { Define.Type.Ghost, 0.0f }
            }
        },
        {
            Define.Type.Poison, new Dictionary<Define.Type, float>
            {
                { Define.Type.Grass, 2.0f },
                { Define.Type.Fairy, 2.0f },
                { Define.Type.Poison, 0.5f },
                { Define.Type.Ground, 0.5f },
                { Define.Type.Rock, 0.5f },
                { Define.Type.Ghost, 0.5f },
                { Define.Type.Steel, 0.0f }
            }
        },
        {
            Define.Type.Ground, new Dictionary<Define.Type, float>
            {
                { Define.Type.Fire, 2.0f },
                { Define.Type.Electric, 2.0f },
                { Define.Type.Poison, 2.0f },
                { Define.Type.Rock, 2.0f },
                { Define.Type.Steel, 2.0f },
                { Define.Type.Grass, 0.5f },
                { Define.Type.Bug, 0.5f },
                { Define.Type.Flying, 0.0f }
            }
        },
        {
            Define.Type.Flying, new Dictionary<Define.Type, float>
            {
                { Define.Type.Grass, 2.0f },
                { Define.Type.Fighting, 2.0f },
                { Define.Type.Bug, 2.0f },
                { Define.Type.Electric, 0.5f },
                { Define.Type.Rock, 0.5f },
                { Define.Type.Steel, 0.5f }
            }
        },
        {
            Define.Type.Psychic, new Dictionary<Define.Type, float>
            {
                { Define.Type.Fighting, 2.0f },
                { Define.Type.Poison, 2.0f },
                { Define.Type.Psychic, 0.5f },
                { Define.Type.Steel, 0.5f },
                { Define.Type.Dark, 0.0f }
            }
        },
        {
            Define.Type.Bug, new Dictionary<Define.Type, float>
            {
                { Define.Type.Grass, 2.0f },
                { Define.Type.Psychic, 2.0f },
                { Define.Type.Dark, 2.0f },
                { Define.Type.Fire, 0.5f },
                { Define.Type.Fighting, 0.5f },
                { Define.Type.Poison, 0.5f },
                { Define.Type.Flying, 0.5f },
                { Define.Type.Ghost, 0.5f },
                { Define.Type.Steel, 0.5f },
                { Define.Type.Fairy, 0.5f }
            }
        },
        {
            Define.Type.Rock, new Dictionary<Define.Type, float>
            {
                { Define.Type.Fire, 2.0f },
                { Define.Type.Ice, 2.0f },
                { Define.Type.Flying, 2.0f },
                { Define.Type.Bug, 2.0f },
                { Define.Type.Fighting, 0.5f },
                { Define.Type.Ground, 0.5f },
                { Define.Type.Steel, 0.5f }
            }
        },
        {
            Define.Type.Ghost, new Dictionary<Define.Type, float>
            {
                { Define.Type.Psychic, 2.0f },
                { Define.Type.Ghost, 2.0f },
                { Define.Type.Dark, 0.5f },
                { Define.Type.Normal, 0.0f }
            }
        },
        {
            Define.Type.Dragon, new Dictionary<Define.Type, float>
            {
                { Define.Type.Dragon, 2.0f },
                { Define.Type.Steel, 0.5f },
                { Define.Type.Fairy, 0.0f }
            }
        },
        {
            Define.Type.Dark, new Dictionary<Define.Type, float>
            {
                { Define.Type.Psychic, 2.0f },
                { Define.Type.Ghost, 2.0f },
                { Define.Type.Fighting, 0.5f },
                { Define.Type.Dark, 0.5f },
                { Define.Type.Fairy, 0.5f }
            }
        },
        {
            Define.Type.Steel, new Dictionary<Define.Type, float>
            {
                { Define.Type.Ice, 2.0f },
                { Define.Type.Rock, 2.0f },
                { Define.Type.Fairy, 2.0f },
                { Define.Type.Fire, 0.5f },
                { Define.Type.Water, 0.5f },
                { Define.Type.Electric, 0.5f },
                { Define.Type.Steel, 0.5f }
            }
        },
        {
            Define.Type.Fairy, new Dictionary<Define.Type, float>
            {
                { Define.Type.Fighting, 2.0f },
                { Define.Type.Dragon, 2.0f },
                { Define.Type.Dark, 2.0f },
                { Define.Type.Fire, 0.5f },
                { Define.Type.Poison, 0.5f },
                { Define.Type.Steel, 0.5f }
            }
        }
    };

    public static float GetMultiplier(Define.Type attackType, Define.Type defenseType)
    {
        if (Table.TryGetValue(attackType, out var targets) &&
            targets.TryGetValue(defenseType, out var multiplier))
        {
            return multiplier;
        }

        return 1.0f;
    }

    public static float GetFinalMultiplier(Define.Type attackType, Define.Type defenseType1, Define.Type defenseType2)
    {
        return GetMultiplier(attackType, defenseType1) * GetMultiplier(attackType, defenseType2);
    }
    /* 사용예시
    float damageMultiplier = TypeEffectiveness.GetFinalMultiplier(
    Define.Type.Fire,
    Define.Type.Grass,
    Define.Type.Steel
    );
     */
}