using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillEdge
    {
        private List<SkillNode> connectedNodes = new List<SkillNode>();
        public List<SkillNode> ConnectedNodes => connectedNodes;

        public void AddConnectedNode(SkillNode node)
        {
            connectedNodes.Add(node);
        }
    }
}
