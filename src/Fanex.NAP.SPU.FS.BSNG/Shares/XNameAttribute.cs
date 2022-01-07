namespace Fanex.NAP.SPU.FS.BSNG.Shares
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class XNameAttribute : Attribute
    {
        public XNameAttribute(string name)
        {
            ElementName = name;
        }

        public string ElementName { get; }
    }
}
