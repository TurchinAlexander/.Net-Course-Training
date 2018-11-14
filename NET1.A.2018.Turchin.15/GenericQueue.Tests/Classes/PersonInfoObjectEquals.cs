using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue.Tests.Classes
{
	class PersonInfoObjectEquals
	{
		public string Name { get; set; }
		public string Surname { get; set; }

		public bool Equals(PersonInfoObjectEquals other)
		{
			return this.Name.Equals(other.Name) && this.Surname.Equals(other.Surname);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode() + Surname.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as PersonInfoObjectEquals);
		}
	}
}
