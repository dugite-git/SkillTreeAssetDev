using NUnit.Framework;
using SkillTreeMaker.Model.Skill;

public class SkillEdgeTests
{
    [Test]
    public void GetAvailableConnectedNodes_RemovesUnlockedNodes()
    {
        var edge = new SkillEdge();
        var root = new SkillNode(); // 解除済み想定
        var a = new SkillNode(); // 未解除想定
        var b = new SkillNode(); // 解除済み想定
        var c = new SkillNode(); // 未解除想定
        var d = new SkillNode(); // 未解除想定

        root.SetId(0);
        a.SetId(1);
        b.SetId(2);
        c.SetId(3);
        d.SetId(4);

        edge.AddConnectedNode(root);
        edge.AddConnectedNode(a);
        edge.AddConnectedNode(b);
        edge.AddConnectedNode(c);
        edge.AddConnectedNode(d);

        root.SetIsUnlocked(true);
        b.SetIsUnlocked(true);

        edge.AddAlternativeNodeToGroup(0, a);
        edge.AddAlternativeNodeToGroup(0, b);
        edge.AddAlternativeNodeToGroup(1, c);
        edge.AddAlternativeNodeToGroup(1, d);

        var result = edge.GetAvailableConnectedNodesFrom(root);

        Assert.IsFalse(result.Contains(root));
        Assert.IsFalse(result.Contains(a));
        Assert.IsFalse(result.Contains(b));
        Assert.IsTrue(result.Contains(c));
        Assert.IsTrue(result.Contains(d));
    }
}
