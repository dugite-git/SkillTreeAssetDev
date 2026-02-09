using System;


namespace SkillTreeMaker.Common
{
    public class Id
    {
        private Guid guid;
        public string Value => guid.ToString();
        public Id()
        {
            guid = Guid.NewGuid();
        }
        public bool IsEqual(Id other)
        {
            return guid.Equals(other.guid);
        }
    }
}
