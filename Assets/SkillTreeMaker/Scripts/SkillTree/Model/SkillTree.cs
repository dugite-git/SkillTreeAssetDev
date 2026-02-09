using System.Collections.Generic;
using SkillTreeMaker.Common;

namespace SkillTreeMaker.SkillTree.Model
{
    public class SkillTree
    {
        private Id id = new Id();
        private List<SkillNode> skillNodes = new();

        public Id Id => id;
    }
}
