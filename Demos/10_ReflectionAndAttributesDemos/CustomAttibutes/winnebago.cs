using System;

[assembly:System.CLSCompliantAttribute(true)]

namespace CustomAtt
{
	[VehicleDescription("A very long, slow but feature rich auto")]
	public class Winnebago
	{
		public Winnebago()
		{
		}

		// Uncomment the following lines to generate an error.
      //[VehicleDescription("Can't use this attribute on simple types!")]
      //public ulong notCompliant;
	}
}
