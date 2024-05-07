using Bank.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class File
    {
        /// <summary>
        /// Проверяем есть ли пользователь по фамилии и паролю
        /// </summary>
        /// <returns></returns>
        public static int CheckUser(List<UserModel> users, string email, string pass)
        {
            foreach (var user in users)
            {
                if ((user.email == email) && (user.password == pass))
                {
                    return user.Id;
                }
            }
            return 0;

        }
        /// <summary>
        /// Получаем пользователя находя по фамилии и паролю
        /// </summary>
        /// <returns></returns>
        public static UserModel GetUser(List<UserModel> users, int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;

        }
        /// <summary>
        /// Получаем список пользователей с users.txt файла
        /// </summary>
        /// <returns></returns>
        public static List<UserModel> GetUsers()
        {
            string filePath = "C:\\Users\\user\\Desktop\\Bank\\Bank\\authorization.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath, Encoding.GetEncoding(1251));

            UserModel account = new UserModel();
            List<UserModel> accounts = new List<UserModel>();
            int i = 1;


            foreach (string line in lines)
            {
                string[] temp = line.Split(',');

                account.Id = i;
                account.email = temp[0];
                account.password = temp[1];
                account.role = temp[2];

                accounts.Add(account);
                account = new UserModel();
                i++;
            }


            return accounts; 
        }

        /// <summary>
        /// Получаем список тканей с файла
        /// </summary>
        /// <returns></returns>
        public static List<Cloth> GetCloths()
        {
            string filePathCloth = "C:\\Users\\user\\Desktop\\Bank\\Bank\\fabrics.txt";
            string[] lines = System.IO.File.ReadAllLines(filePathCloth, Encoding.UTF8);

            Cloth cloth = new Cloth();
            List<Cloth> cloths = new List<Cloth>();

            foreach (string line in lines)
            {
                string[] temp = line.Split(',');

                cloth.title = temp[0];
                cloth.color = temp[1];
                cloth.compound = temp[2];
                cloth.count = Convert.ToInt32(temp[3]);
                cloth.price = Convert.ToInt32(temp[4]);

                cloths.Add(cloth);
                cloth = new Cloth();
            }


            return cloths;
        }

        public static void WriteUser(string textToTxt)
        {
            string filePath = "C:\\Users\\user\\Desktop\\Bank\\Bank\\authorization.txt";

            using (StreamWriter writer = System.IO.File.AppendText(filePath))
            {
                writer.Write(writer.NewLine);
                writer.Write(textToTxt);
            }

        }

    }
}
