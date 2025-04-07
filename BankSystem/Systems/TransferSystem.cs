using BankSystem.Models;

namespace BankSystem.Systems
{
    public static class TransferSystem
    {
        /// <summary>
        /// Событие для отслеживания передачи денег
        /// </summary>
        public static event Action<User, User>? OnBalanceUpdated;

        /// <summary>
        /// Перевод денег между пользователями
        /// </summary>
        /// <param name="userFrom">С какого пользователя</param>
        /// <param name="userTo">К какому пользователю</param>
        /// <param name="amount">Количество</param>
        /// <param name="voluteType">Тип валюты</param>
        public static void TransferMoney(User userFrom, User userTo, float amount, EVoluteType voluteType = EVoluteType.RUB)
        {
            if (userFrom != null && userTo != null && 
                userFrom.Invoices != null && userTo.Invoices != null)
            {
                // Счет первого пользователя
                Invoice? invoiceFrom = userFrom.Invoices.Where(x => x.VoluteType == voluteType).FirstOrDefault();
                // Счет второго пользователя
                Invoice? invoiceTo = userTo.Invoices.Where(x => x.VoluteType == voluteType).FirstOrDefault();

                if (invoiceFrom != null && invoiceTo != null)
                {
                    if (invoiceFrom.Amount >= amount)
                    {
                        invoiceFrom.Amount -= amount;
                        invoiceTo.Amount += amount;
                        OnBalanceUpdated?.Invoke(userFrom, userTo);
                    }
                    else
                        throw new Exception($"У пользователя {userFrom.Name} не хватает денег");
                }
                else
                    throw new Exception($"У одного из пользователей не найден счет с такой валютой");
            }
            else
                throw new NullReferenceException($"Пользователи или их счета имеют значение NULL");
        }
    }
}
