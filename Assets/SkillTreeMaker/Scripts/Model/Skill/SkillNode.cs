using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillNode : ScriptableObject
    {
        private int id;
        private SkillDetail detail;
        private bool isActive;
        private bool hasAltSkills;
        private bool hasPrerequisiteSkills;

        private List<SkillNode> ConnectedSkills = new List<SkillNode>();
        private List<(int AltSkillGroupNumber, List<SkillNode>)> AlternativeSkillGroups = new List<(int, List<SkillNode>)>();
        private List<SkillNode> PrerequisiteSkills = new List<SkillNode>();
    }
}
