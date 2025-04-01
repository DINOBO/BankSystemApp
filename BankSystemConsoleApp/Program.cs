using BankSystem.Models;
using BankSystem.Systems;

namespace BankSystemConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransferSystem.OnBalanceUpdated += TransferSystem_OnBalanceUpdated;
            SalarySystem.OnPaidSalaries += SalarySystem_OnPaidSalaries;

            User dean = new User("Dean");
            User aituk = new User("Aituk");

            SalarySystem.PaySalary(dean, 500, EVoluteType.RUB);
            SalarySystem.PaySalary(aituk, 700, EVoluteType.RUB);

            TransferSystem.TransferMoney(aituk, dean, 300, EVoluteType.RUB);

            Invoice? deanInvoice = dean.Invoices.Where(x => x.VoluteType == EVoluteType.RUB).FirstOrDefault();
            Invoice? aitukInvoice = aituk.Invoices.Where(x => x.VoluteType == EVoluteType.RUB).FirstOrDefault();

            if (deanInvoice != null && aitukInvoice != null)
                Console.WriteLine($"Текущий баланс {dean.Name}: {deanInvoice.Amount}\nТекущий баланс {aituk.Name}: {aitukInvoice.Amount}");

            Console.ReadKey();
        }

        private static void SalarySystem_OnPaidSalaries(User user)
        {
            Console.WriteLine($"Пользователь {user.Name} получил зарплату");
        }

        private static void TransferSystem_OnBalanceUpdated(User userFrom, User userTo)
        {
            Console.WriteLine($"Пользователь {userFrom.Name} отправил деньги пользователю {userTo.Name}");
        }
    }
}