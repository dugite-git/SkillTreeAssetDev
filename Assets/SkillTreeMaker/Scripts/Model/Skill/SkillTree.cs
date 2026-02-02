using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillTree : ScriptableObject
    {
        private List<SkillNode> skillNodes = new List<SkillNode>();
        private List<(int GroupIndex, List<SkillNode> Skills)> alternativeSkillGroups = new List<(int, List<SkillNode>)>();
        
        public List<SkillNode> GetAvailableSkills()
        {
            List<SkillNode> availableSkills = new List<SkillNode>();
            foreach (var node in skillNodes)
            {
                if (node.IsAvailable(alternativeSkillGroups))
                {
                    availableSkills.Add(node);
                }
            }
            return availableSkills;
        }
    }
}
