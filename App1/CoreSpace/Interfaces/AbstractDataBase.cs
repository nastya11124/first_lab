using System.Collections.Generic;

namespace App1.CoreSpace.Interfaces
{
	public interface AbstractDataBase
	{
		public Dictionary<string, List<string>> GetCatalog();
		public void SetCatalog(Dictionary<string, List<string>> catalog);
	}
}
