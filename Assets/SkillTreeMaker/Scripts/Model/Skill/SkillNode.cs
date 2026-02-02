using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillNode : ScriptableObject
    {
        private int id;
        private SkillDetail detail;
        private bool isRoot;
        private bool isActive;
        private bool isAltSkill;
        private int altGroupIndex;
        private bool hasPrerequisiteCondition;
        private List<SkillNode> connectedSkills = new List<SkillNode>();
        private (bool isAllNeeded, List<SkillNode> Skills) prerequisiteCondition = (false, new List<SkillNode>());


        public int Id => id;
        public SkillDetail Detail => detail;
        public bool IsRoot => isRoot;
        public bool IsActive => isActive;
        public bool IsAltSkill => isAltSkill;
        public int AltGroupIndex => altGroupIndex;
        public bool HasPrerequisiteCondition => hasPrerequisiteCondition;
        public List<SkillNode> ConnectedSkills => connectedSkills;
        public (bool isAllNeeded, List<SkillNode> Skills) PrerequisiteCondition => prerequisiteCondition;

        public bool IsAvailable(List<(int GroupIndex, List<SkillNode> Skills)> alternativeSkillGroups)
        {
            if (isActive) return false;
            if (isRoot) return true;
            if (isAltSkill)
            {
                var group = alternativeSkillGroups.Find(g => g.GroupIndex == altGroupIndex);
                foreach (var skill in group.Skills)
                {
                    if (skill.isActive)
                        return false;
                }
            }
            if(hasPrerequisiteCondition)
            {
                if(prerequisiteCondition.isAllNeeded)
                {
                    foreach(var skill in prerequisiteCondition.Skills)
                    {
                        if (!skill.isActive)
                            return false;
                    }
                    return true;
                }
                else
                {
                    foreach(var skill in prerequisiteCondition.Skills)
                    {
                        if (skill.isActive)
                            return true;
                    }
                    return false;
                }
            }
            else
            {
                foreach (var skill in connectedSkills)
                {
                    if (skill.isActive)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
