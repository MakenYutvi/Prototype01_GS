using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillPointManager 
{
    event Action<int> OnSkillPointsChanged;
    public int GetSkillPoints();
    public int AddSkillPoints(int amount);
}
