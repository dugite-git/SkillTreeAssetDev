namespace SkillTreeMaker.Common
{
    public class CustomField
    {
        private string name;
        private System.Type type;
        private object value = null;

        public string Name => name;
        public System.Type Type => type;
        public string TypeName => type.Name;
        public object Value => value;

        public CustomField(string name, System.Type type, object value = null)
        {
            this.name = name;
            this.type = type;
            SetValue(value);
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetType<T>()
        {
            type = typeof(T);
            value = null;
        }
        public void SetValue(object value)
        {
            if (value.GetType() != type)
                throw new System.ArgumentException(
                    $"Expected type '{type.Name}' but got '{value.GetType().Name}'.",
                    nameof(value));
            this.value = value;
        }
        public void ClearValue()
        {
            value = null;
        }
    }
}
