using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes
{
    Sword,
    Shield,
    Axe,
    Dagger,
    Bow,
    Staff,
    Chime
}

public enum PlayerClass
{
    Warrior,
    Rogue,
    Mage,
    Priest,
    Commoner
}

[CreateAssetMenu(fileName = "New Class", menuName = "New/Class")]
public class ClassScriptableObject : ScriptableObject
{
    public PlayerClass currentClass;
    public Stats currentStats;
    public List<WeaponTypes> useableWeapons;
    public List<skillPath> levelupSkillPath;
}

[System.Serializable]
public struct Stats
{
    public float vigor, strength, dexterity, intelligence, wisdom;
}

[System.Serializable]
public struct skillPath
{
    public int level;
    public ClassSkillScriptableObject skill;
}
