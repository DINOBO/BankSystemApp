using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    //Пользователь
    public class User
    {
        //Имя пользователя
        public string Name { get; set; }
        //Счета пользователя
        public List<Invoice> Invoices { get; set; }

        /// <summary>
        /// Создать пользователя, при создании автоматически создается рублевый счет
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        public User(string name)
        {
            Name = name;
            // Открытие рублевого счета
            Invoices = new List<Invoice>()
            {
                new Invoice() {Amount = 0, VoluteType = EVoluteType.RUB } 
            };
        }
    }
}
