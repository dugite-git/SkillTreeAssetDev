using System.Collections.Generic;
using SkillTreeMaker.Common;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillNode
    {
        private int id;
        private SkillDefinition skillDefinition;
        private bool isUnlocked = false;
        private bool requiresPreNode = false;
        private bool hasPrerequisiteAttributes = false;
        private List<SkillEdge> connectedEdges = new();
        private List<int> prerequisiteNodeIds = new();
        private List<CustomField> prerequisiteAttributes = new();

        public int Id => id;
        public SkillDefinition SkillDefinition => skillDefinition;
        public bool IsUnlocked => isUnlocked;
        public bool RequiresPreNode => requiresPreNode;
        public bool HasPrerequisiteAttributes => hasPrerequisiteAttributes;
        public List<SkillEdge> ConnectedEdges => connectedEdges;
        public List<CustomField> PrerequisiteAttributes => prerequisiteAttributes;
        public List<int> PrerequisiteNodeIds => prerequisiteNodeIds;

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
        public void RemoveConnectedEdge(SkillEdge edge)
        {
            connectedEdges.Remove(edge);
        }
        public void AddPrerequisiteAttribute(CustomField attribute)
        {
            prerequisiteAttributes.Add(attribute);
            hasPrerequisiteAttributes = true;
        }
        public void RemovePrerequisiteAttribute(CustomField attribute)
        {
            prerequisiteAttributes.Remove(attribute);
            if (prerequisiteAttributes.Count == 0)
            {
                hasPrerequisiteAttributes = false;
            }
        }
        public void AddPrerequisiteNodeId(int nodeId)
        {
            prerequisiteNodeIds.Add(nodeId);
        }
    }
}
