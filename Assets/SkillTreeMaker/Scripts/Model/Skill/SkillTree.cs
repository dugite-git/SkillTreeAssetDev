using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillTree : ScriptableObject
    {
        private int id;
        private List<SkillNode> skillNodes = new();

        public int Id => id;
    }
}
