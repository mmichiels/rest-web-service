using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuscData;

namespace TuscApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load users from data file
            List<User> users = DataManager.GetUsers();

            // Load products from data file
            List<Product> products = DataManager.GetProducts();

            // Load transaction from data file
            List<Transaction> transactions = DataManager.GetTransactions();

            Tusc.Start(users, products, transactions);
        }
    }
}
