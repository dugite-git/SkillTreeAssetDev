using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillDetail : ScriptableObject
    {
        private string skillName;
        private string description;
        private Sprite icon;
        private List<SkillAttribute> customPrerequisites = new List<SkillAttribute>();
        private List<SkillAttribute> skillBenefits = new List<SkillAttribute>();

        public string SkillName => skillName;
        public string Description => description;
        public Sprite Icon => icon;
        public List<SkillAttribute> CustomConditions => customPrerequisites;
        public List<SkillAttribute> SkillBenefits => skillBenefits;

        public void SetSkillName(string name)
        {
            skillName = name;
        }
        public void SetDescription(string desc)
        {
            description = desc;
        }
        public void SetIcon(Sprite iconSprite)
        {
            icon = iconSprite;
        }
        public void AddCustomPrerequisite(SkillAttribute attribute)
        {
            customPrerequisites.Add(attribute);
        }
        public void AddSkillBenefit(SkillAttribute attribute)
        {
            skillBenefits.Add(attribute);
        }
    }
}
