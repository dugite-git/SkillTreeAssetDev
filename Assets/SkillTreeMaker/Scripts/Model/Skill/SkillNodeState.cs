namespace SkillTreeMaker.Model.Skill
{
    public class SkillNode
    {
        private SkillDefinition skillDefinition;
        bool isUnlocked = false;
        public SkillDefinition SkillDefinition => skillDefinition;
        public bool IsUnlocked => isUnlocked;

        public void SetSkillDefinition(SkillDefinition definition)
        {
            skillDefinition = definition;
        }
        public void SetIsUnlocked(bool unlocked)
        {
            isUnlocked = unlocked;
        }
    }
}
