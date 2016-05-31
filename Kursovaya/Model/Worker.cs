using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    //класс рабочего
    [Serializable]
    public class Worker
    {
        // Имя
        public string FirstName;
        // Фамилия
        public string SecondName;
        // Должность
        public string Position;
        // Дата наема
        public Date DateOfStart;

        //конструктор
        public Worker(string fName, string sName, string pos, Date dateOfStart)
        {
            FirstName = fName;
            SecondName = sName;
            Position = pos;
            DateOfStart = dateOfStart;
        }
    }
}
