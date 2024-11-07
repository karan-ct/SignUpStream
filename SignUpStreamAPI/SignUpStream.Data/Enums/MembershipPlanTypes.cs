using System;
using System.Runtime.Serialization;

namespace SignUpStream.Infra.Enums
{
	public enum MembershipPlanTypes
	{
        [EnumMember(Value = "Monthly")]
        Monthly = 1,

        [EnumMember(Value = "Annually")]
        Annually = 2,

    }
}

