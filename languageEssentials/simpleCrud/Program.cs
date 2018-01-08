using System;
using DbConnection;

namespace simpleCrud
{
    class Program
    {

        public static void read()
        {
            var allUsers = DbConnector.Query("SELECT * FROM users");

            foreach(var user in allUsers)
            {
                System.Console.WriteLine($"{user["first_name"]} {user["last_name"]}, {user["favorite_number"]}");
            }
        }

        public static void create()
        {
            System.Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            string fString = '"' + firstName + '"';
            System.Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            string lString = '"' + lastName + '"';
            System.Console.WriteLine("Enter lucky number");
            string luckyNum = Console.ReadLine();
            string nString = '"' + luckyNum + '"';
           string insertQuery = $"INSERT into users (first_name, last_name, favorite_number) VALUES({fString}, {lString}, {nString})";
           DbConnector.Execute(insertQuery);
           read();
        }

        public static void update()
        {
            System.Console.WriteLine("Enter id");
            string id = Console.ReadLine();
            System.Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            string fString = '"' + firstName + '"';
            System.Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            string lString = '"' + lastName + '"';
            System.Console.WriteLine("Enter lucky number");
            string luckyNum = Console.ReadLine();
            
            
            string updateQuery = $"UPDATE users SET first_name = {fString}, last_name = {lString}, favorite_number = {luckyNum} WHERE id = {id}";
            DbConnector.Execute(updateQuery);
            read();


        }

        public static void remove()
        {
            System.Console.WriteLine("Enter id of person to delete");
            string id = Console.ReadLine();
            string removeQuery = $"DELETE FROM users WHERE id = {id}";
            DbConnector.Execute(removeQuery);
            read();
        }
        static void Main(string[] args)
        {
           remove();
        }
    }
}
