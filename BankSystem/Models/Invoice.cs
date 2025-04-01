using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    //Счет
    public class Invoice
    {
        //Количество денег
        public float Amount { get; set; }
        //Тип волюты
        public EVoluteType VoluteType { get; set; }
    }

    /// <summary>
    /// Тип волюты
    /// </summary>
    public enum EVoluteType
    {
        RUB = 0,
        USD = 1,
        EUR = 2,
    }
}
