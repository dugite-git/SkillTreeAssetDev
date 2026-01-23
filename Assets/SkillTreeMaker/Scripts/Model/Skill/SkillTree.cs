using UnityEngine;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillTreeContainer : ScriptableObject
    {
        private List<(int skillTreeId, List<SkillNode> skillNodes)> skillTrees = new List<(int, List<SkillNode>)>();
        public List<(int skillTreeId, List<SkillNode> skillNodes)> SkillTrees => skillTrees;

    }
}
