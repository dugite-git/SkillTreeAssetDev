using System.Collections.Generic;
using System.Linq;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillEdge
    {
        private int id;
        private List<SkillNode> connectedNodes = new();
        private List<(int GroupIndex, List<SkillNode> Nodes)> alternativeNodeGroups = new();

        public int Id => id;
        public List<SkillNode> ConnectedNodes => connectedNodes;
        public List<(int GroupIndex, List<SkillNode> Nodes)> AlternativeNodeGroups => alternativeNodeGroups;

        public void AddConnectedNode(SkillNode node)
        {
            connectedNodes.Add(node);
        }
        public void AddAlternativeNodeGroup(int groupIndex, List<SkillNode> nodes)
        {
            alternativeNodeGroups.Add((groupIndex, nodes));
        }
        public List<SkillNode> GetAvailableConnectedNodes(SkillNode node)
        {
            if (!connectedNodes.Contains(node))
                throw new System.ArgumentException(
                    "The specified node is not connected to this edge.",
                    nameof(node));
            if (!node.IsUnlocked) return new List<SkillNode>();
            List<SkillNode> otherNodes = GetOtherConnectedNodes(node);
            otherNodes = RemoveDisabledAlternativeNodes(otherNodes);
            otherNodes = RemoveUnlockedNodes(otherNodes);
            return otherNodes;
        }

        private List<SkillNode> GetOtherConnectedNodes(SkillNode node)
        {
            List<SkillNode> otherNodes = new();
            foreach (var connectedNode in connectedNodes)
            {
                if (connectedNode != node)
                {
                    otherNodes.Add(connectedNode);
                }
            }
            return otherNodes;
        }
        private List<SkillNode> RemoveDisabledAlternativeNodes(List<SkillNode> nodes)
        {
            List<SkillNode> resolvedNodes = new(nodes);
            List<SkillNode> deletableNodes = new();
            if (alternativeNodeGroups.Count == 0) return nodes;
            foreach ((int groupIndex, List<SkillNode> altNodes) in alternativeNodeGroups)
            {
                foreach (SkillNode node in altNodes)
                {
                    if (node.IsUnlocked)
                    {
                        deletableNodes.AddRange(altNodes);
                    }
                }
            }
            deletableNodes = new HashSet<SkillNode>(deletableNodes).ToList();
            foreach (SkillNode delNode in deletableNodes)
            {
                resolvedNodes.Remove(delNode);
            }
            return resolvedNodes;
        }
        private List<SkillNode> RemoveUnlockedNodes(List<SkillNode> nodes)
        {
            List<SkillNode> resolvedNodes = new(nodes);
            List<SkillNode> deletableNodes = new();
            foreach (SkillNode node in nodes)
            {
                if (node.IsUnlocked)
                {
                    deletableNodes.Add(node);
                }
            }
            foreach (SkillNode delNode in deletableNodes)
            {
                resolvedNodes.Remove(delNode);
            }
            return resolvedNodes;
        }
    }
}
