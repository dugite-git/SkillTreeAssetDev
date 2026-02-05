using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillTree : ScriptableObject
    {
        private int id;
        private List<SkillNode> skillNodes = new List<SkillNode>();
        private List<(int GroupIndex, List<SkillNode> Skills)> alternativeSkillGroups = new List<(int, List<SkillNode>)>();

        public int Id => id;
    }
}
