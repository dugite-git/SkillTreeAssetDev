using UnityEngine;
using System.Collections.Generic;
using SkillTreeMaker.Common;

namespace SkillTreeMaker.Model.Skill
{
    public class SkillDefinition : ScriptableObject
    {
        private int id;
        private string skillName;
        private string description;
        private Sprite icon;
        private List<CustomField> benefits = new();

        public int Id => id;
        public string SkillName => skillName;
        public string Description => description;
        public Sprite Icon => icon;
        public List<CustomField> Benefits => benefits;

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
        public void AddSkillBenefit(CustomField attribute)
        {
            benefits.Add(attribute);
        }
    }
}
