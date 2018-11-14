using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue.Tests.Classes
{
	class PersonInfoEquatable : IEquatable<PersonInfoEquatable>
	{
		public string Name { get; set; }
		public string Surname { get; set; }

		public bool Equals(PersonInfoEquatable other)
		{
			return this.Name.Equals(other.Name) && this.Surname.Equals(other.Surname);
		}
	}
}
