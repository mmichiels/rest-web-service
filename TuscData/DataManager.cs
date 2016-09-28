using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuscData
{
    public static class DataManager
    {
        private static readonly string USERS_FILE = @"C:/TuscData/Users.json";
        private static readonly string PRODUCTS_FILE = @"C:/TuscData/Products.json";
        private static readonly string TRANSACTIONS_FILE = @"C:/TuscData/Transactions.json";

        public static List<User> GetUsers()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(USERS_FILE));
        }

        public static void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(USERS_FILE, json);
        }

        public static List<Product> GetProducts()
        {
            return JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(PRODUCTS_FILE));
        }

        public static void SaveProducts(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(PRODUCTS_FILE, json);
        }

        public static List<Transaction> GetTransactions()
        {
            return JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(TRANSACTIONS_FILE));
        }

        public static void SaveTransactions(List<Transaction> transactions)
        {
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(TRANSACTIONS_FILE, json);
        }


        public static int? CreateProduct(Product product)
        {
            var products = GetProducts();

            int? nextId = products.Max(p => p.Id == null ? 0 : p.Id) + 1;
            product.Id = nextId;
            products.Add(product);

            SaveProducts(products);

            return nextId;
        }

        public static int? CreateUser(User user)
        {
            var users = GetUsers();

            int? nextId = users.Max(u => u.Id == null ? 0 : u.Id) + 1;

            user.Id = nextId;
            users.Add(user);

            SaveUsers(users);

            return nextId;
        }

        public static void UpdateProduct(Product product)
        {
            var products = GetProducts();
            var productToUpdate = products.Single(p => p.Id == product.Id);

            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            productToUpdate.Name = product.Name;

            DataManager.SaveProducts(products);
        }

        public static void UpdateUser(User user)
        {
            var users = GetUsers();
            var userToUpdate = users.Single(u => u.Id == user.Id);
            
            userToUpdate.Name = user.Name;
            userToUpdate.Balance = user.Balance;
            userToUpdate.Password = user.Password;

            DataManager.SaveUsers(users);
        }

        public static void DeleteUser(int id)
        {
            var users = GetUsers();

            users.Remove(users.Single(u => u.Id == id));

            DataManager.SaveUsers(users);
        }

        public static void DeleteProduct(int id)
        {
            var products = GetProducts();

            products.Remove(products.Single(p => p.Id == id));

            DataManager.SaveProducts(products);
        }
    }
}
