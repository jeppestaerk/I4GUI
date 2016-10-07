using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphingWithShapes
{
	/// <summary>Holds a name and a value</summary>
	public class NameValuePair
	{
		private string name = "";
		private double value = 0;
		private object tag = null;

		public NameValuePair()
		{
		}

		public NameValuePair(string name, double value)
		{
			this.name = name;
			this.value = value;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public double Value
		{
			get { return value; }
			set { this.value = value; }
		}

		public override string ToString()
		{
			return name + ", " + value;
		}

		public object Tag
		{
			get { return tag; }
			set { tag = value; }
		}
	}
}
