using FinalProject.Models;
using System;
using System.Collections.Generic;


namespace FinalProject.Services
{
    public class UserServices
    {
        //TODO Switch to Singleton pattern for UserServices
        private static UserServices? instance;
        public static UserServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserServices();
                }
                return instance;
            }
        }
        public List<User> AllUsers { get; set; } = new List<User>();
        public UserServices()
        {
            AllUsers.Add(
                new User
                {
                    Id = 1,
                    FirstName = "Ahmad",
                    LastName = "Agbaria",
                    Email = "ahmad@gmail.com",
                    Password = "ahmad",
                    Birthdate = DateTime.Now.AddYears(-44),
                    Phone = "052-555000",
                    Username = "ahmad",
                    IsAdmin = true,
                });
            AllUsers.Add(new User
            {
                Id =2,
                FirstName = "Tal",
                LastName = "Simon",
                Email = "tal@gmail.com",
                Password = "tal",
                Birthdate = DateTime.Now.AddYears(-44),
                Phone = "052-6666000",
                Username = "tal",
                IsAdmin = true
            });
            AllUsers.Add(new User
            {
                Id = 3,
                FirstName = "User 1",
                LastName = "User 1",
                Email = "user1@gmail.com",
                Password = "user1",
                Birthdate = DateTime.Now.AddYears(-40),
                Phone = "052-66661111",
                Username = "user1",
                IsAdmin = false
            }); AllUsers.Add(new User
            {
                Id = 4,
                FirstName = "User 2",
                LastName = "User 2",
                Email = "user2@gmail.com",
                Password = "user2",
                Birthdate = DateTime.Now.AddYears(-40),
                Phone = "052-11111111",
                Username = "user2",
                IsAdmin = false
            });
        }
        public bool Register(User user)
        {
            if (user == null) return false;
            //Search for user with same user name in AllUsers
            User? u = AllUsers.Find(u => u.Username == user.Username);
            if (u != null)
            {
                return false;
            }
            user.Id = AllUsers.Count + 1;
            AllUsers.Add(user);
            return true;
        }
        public User? Login(string username, string password)
        {
            if (username == null || password == null)
                return null;
            User? user = AllUsers.Find(u=>u.Username == username && u.Password == password);
            return user;
        }
    }
}
