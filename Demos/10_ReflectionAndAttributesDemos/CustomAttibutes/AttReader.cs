namespace AttReader
{
	using System;
	using CustomAtt;

	public class AttReader
	{

		public static int Main(string[] args)
		{
			// Get the Type of winnebago.
			Type t = typeof(Winnebago);

            //Winnebago wb = new Winnebago();
            //Type t = wb.GetType();

            //Type t = Type.GetType("CustomAtt.Winnebago");
		
			// Get all attributes in the assembly.
			object[] customAtts = t.GetCustomAttributes(false);
		
			// List all info.
            foreach (var v in customAtts)
            {
                if (v is VehicleDescriptionAttribute)
                    Console.WriteLine(((VehicleDescriptionAttribute)v).Desc);
            }

            Console.ReadLine();
			return 0;
		}
	}
}
