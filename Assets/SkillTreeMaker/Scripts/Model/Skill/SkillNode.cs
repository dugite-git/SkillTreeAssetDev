using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillNode
    {
        private int id;
        private SkillDefinition skillDefinition;
        private bool isUnlocked = false;
        private bool requiresPreNode = false;
        private List<SkillEdge> connectedEdges = new();

        public int Id => id;
        public SkillDefinition SkillDefinition => skillDefinition;
        public bool IsUnlocked => isUnlocked;
        public bool RequiresPreNode => requiresPreNode;
        public List<SkillEdge> ConnectedEdges => connectedEdges;

        public void SetId(int nodeId)
        {
            id = nodeId;
        }
        public void SetSkillDefinition(SkillDefinition definition)
        {
            skillDefinition = definition;
        }
        public void SetIsUnlocked(bool unlocked)
        {
            isUnlocked = unlocked;
        }
        public void SetRequiresPreNode(bool requires)
        {
            requiresPreNode = requires;
        }
        public void AddConnectedEdge(SkillEdge edge)
        {
            connectedEdges.Add(edge);
        }
    }
}
