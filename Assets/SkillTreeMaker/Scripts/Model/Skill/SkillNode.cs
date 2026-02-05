using UnityEngine;
using System.Collections.Generic;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillNode : ScriptableObject
    {
        private int id;
        private string skillName;
        private string description;
        private Sprite icon;
        private List<SkillAttribute> skillBenefits = new List<SkillAttribute>();

        public int Id => id;
        public string SkillName => skillName;
        public string Description => description;
        public Sprite Icon => icon;
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
        public void AddSkillBenefit(SkillAttribute attribute)
        {
            skillBenefits.Add(attribute);
        }
    }
}
