using System.Collections.Generic;
using System.Linq;
using SkillTreeMaker.Common;

namespace SkillTreeMaker.SkillTree.Model
{
    public class SkillEdge
    {
        private Id id = new Id();
        private List<SkillNode> connectedNodes = new();
        private List<(int GroupIndex, List<SkillNode> Nodes)> alternativeNodeGroups = new();

        public Id Id => id;
        public List<SkillNode> ConnectedNodes => connectedNodes;
        public List<(int GroupIndex, List<SkillNode> Nodes)> AlternativeNodeGroups => alternativeNodeGroups;

        public void AddConnectedNode(SkillNode node)
        {
            connectedNodes.Add(node);
        }
        public void AddAlternativeNodeToGroup(int groupIndex, SkillNode node)
        {
            if (connectedNodes.Contains(node) == false)
            {
                throw new System.ArgumentException(
                    "The specified node is not connected to this edge.",
                    nameof(node));
            }
            var group = alternativeNodeGroups.FirstOrDefault(g => g.GroupIndex == groupIndex);
            if (group.Nodes != null)
            {
                group.Nodes.Add(node);
            }
            else
            {
                alternativeNodeGroups.Add((groupIndex, new List<SkillNode> { node }));
            }
        }
        public List<SkillNode> GetAvailableConnectedNodesFrom(SkillNode node)
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
