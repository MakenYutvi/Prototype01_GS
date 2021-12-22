
using System.Collections.Generic;

public interface ISkillController 
{
    event Action<int> IsSkillPointsChanged;
    bool TryToUnlockSkill(SkillName name);
    bool IsUnlockedSkill(SkillName name);

    List<SkillName> GetActiveSpells();
    
}
