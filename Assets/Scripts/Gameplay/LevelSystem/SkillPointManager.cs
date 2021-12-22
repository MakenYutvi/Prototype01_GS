using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointManager : MonoBehaviour, ISkillPointManager
{
    public event Action<int> OnSkillPointsChanged;

    [SerializeField]//for test
    private int _skillPoints;
    private void Awake()
    {
        _skillPoints = 0;
    }
    public int AddSkillPoints(int amount)
    {
        _skillPoints += amount;
        OnSkillPointsChanged?.Invoke(_skillPoints);
        return _skillPoints;
    }

    public int GetSkillPoints()
    {
        return _skillPoints;
    }
}
