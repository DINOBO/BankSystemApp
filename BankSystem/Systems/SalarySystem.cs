using BankSystem.Models;

namespace BankSystem.Systems
{
    //Класс для работы с зарплатой
    public static class SalarySystem
    {
        /// <summary>
        /// Событие для отслеживания выдачи зарплат
        /// </summary>
        public static event Action<User>? OnPaidSalaries;

        /// <summary>
        /// Выдать зарплату пользователю
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="amount">Суммма</param>
        /// <param name="voluteType">Тип волюты</param>
        public static void PaySalary(User user, float amount, EVoluteType voluteType = EVoluteType.RUB)
        {
            if (user != null && user.Invoices != null)
            {
                Invoice? invoice = user.Invoices.Where(x => x.VoluteType == voluteType).FirstOrDefault();
                if (invoice != null)
                {
                    invoice.Amount += amount;
                    OnPaidSalaries?.Invoke(user);
                }
                else
                    throw new Exception($"У пользователя {user.Name} нет подходящих счетов для волюты {voluteType.ToString()}");
            }
            else
                throw new NullReferenceException("Пользователь и/или счета у пользователя имеет значение NULL");
        }
    }
}