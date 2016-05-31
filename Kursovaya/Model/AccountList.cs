using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    //класс списка аккаунтов
    [Serializable]
    public class AccountList : List<Account>
    {
        //метод чтения из файла
        public void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("accounts.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs,this);
            fs.Close();
        }

        //метод чтения из файла
        public static AccountList ReadFromFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("accounts.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            AccountList result = (AccountList) formatter.Deserialize(fs);
            fs.Close();
            return result;
        }

        //метод который возвращает наличие аккаунта в списке и проверка на права администратора
        public bool ContainsByText(string login, string password, bool adminCheck = false)
        {
            foreach (Account account in this)
            {
                if (account.Login == login && account.Password == password)
                {
                    if (adminCheck) return account.IsAdmin;
                    return true;
                }
            }
            return false;
        }

    }
}
