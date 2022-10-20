using System.Runtime.Serialization;

namespace Stuffy.Website.Shared.Enums
{
    public enum NodeTypeEnum
    {
        [EnumMember(Value = "None")]
        None = 0,
        [EnumMember(Value = "Stuffy")]
        Stuffy = 1,
        [EnumMember(Value = "People")]
        People = 2,
        [EnumMember(Value = "Pet")]
        Pets = 3,
    }
}
