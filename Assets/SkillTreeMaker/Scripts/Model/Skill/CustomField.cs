namespace SkillTreeMaker.Model.Skill
{
    public class CustomField
    {
        private string name;
        private System.Type type;
        private object value = null;

        public CustomField(string name, System.Type type, object value = null)
        {
            this.name = name;
            this.type = type;
            SetValue(value);
        }

        public void SetValue(object value)
        {
            if (value.GetType() != type)
                throw new System.ArgumentException(
                    $"Expected type '{type.Name}' but got '{value.GetType().Name}'.",
                    nameof(value));
            this.value = value;
        }
    }
}
