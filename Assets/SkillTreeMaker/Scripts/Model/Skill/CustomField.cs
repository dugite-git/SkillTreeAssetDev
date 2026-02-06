namespace SkillTreeMaker.Model.Skill
{
    public class CustomField
    {
        private string name;
        private System.Type type;
        private object value = null;
        private bool isUsed = false;

        public CustomField(string name, System.Type type)
        {
            this.name = name;
            this.type = type;
        }

        public void SetValue(object value)
        {
            if (!isUsed) throw new System.Exception("Cannot set value of an unused attribute.");
            if (value.GetType() != type)
                throw new System.ArgumentException(
                    $"Expected type '{type.Name}' but got '{value.GetType().Name}'.",
                    nameof(value));
            this.value = value;
        }

        public void SetIsUsed(bool isUsed)
        {
            this.isUsed = isUsed;
        }
    }
}