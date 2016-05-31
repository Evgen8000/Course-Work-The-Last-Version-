using Kursovaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kursovaya
{
    //класс списка заключенных, в котором есть список рабочих
    [Serializable]
   public class Prison : List<Prisoner>
    {
        public WorkerCollection Workers = new WorkerCollection();
    }
}
