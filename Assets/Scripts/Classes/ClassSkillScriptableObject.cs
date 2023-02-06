using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Skill", menuName ="New/Skill")]
public class ClassSkillScriptableObject : ScriptableObject
{
    public Sprite skillIcon;
    public string skillName;
    public ClassScriptableObject currentClass;
    public float damage, cooldown;
}
