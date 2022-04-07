using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Stuffy.API.Entities
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
