using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillDetail : ScriptableObject
    {
        private string skillName;
        private string description;
        private Sprite icon;
        private List<SkillAttribute> CustomPrerequisite = new List<SkillAttribute>();
        private List<SkillAttribute> SkillBenefit = new List<SkillAttribute>();

        public string SkillName => skillName;
        public string Description => description;
        public Sprite Icon => icon;
        public List<SkillAttribute> GetRequiredCustomConditions() => CustomPrerequisite;
        public List<SkillAttribute> GetSkillBenefits() => SkillBenefit;

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
            CustomPrerequisite.Add(attribute);
        }
        public void AddSkillBenefit(SkillAttribute attribute)
        {
            SkillBenefit.Add(attribute);
        }
    }
}
