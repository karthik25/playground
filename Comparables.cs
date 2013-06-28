/*
 *
 * */
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsoleApp
{
    public class Comparables
    {
        public static void Main(string[] args)
        {
            var users = GetUsers();
            users.ForEach(u => Console.WriteLine(u.UserId + " : " + u.UserName));

            Console.WriteLine("--------------");

            users.Sort(new UserComparer());
            users.ForEach(u => Console.WriteLine(u.UserId + " : " + u.UserName));

            Console.WriteLine("--------------");

            var sortedSet = new SortedSet<User>();
            users.ForEach(u => sortedSet.Add(u));
            sortedSet.ToList().ForEach(s => Console.WriteLine(s.UserId + " : " + s.UserName));
        }

        static List<User> GetUsers()
        {
            return new List<User>
                       {
                           new User{ UserId = 11, UserName = "testuser1", EmailAddress = "testuser1@mail.com"},
                           new User{ UserId = 62, UserName = "testuser2", EmailAddress = "testuser2@mail.com"},
                           new User{ UserId = 13, UserName = "testuser3", EmailAddress = "testuser3@mail.com"},
                           new User{ UserId = 42, UserName = "testuser4", EmailAddress = "testuser4@mail.com"},
                           new User{ UserId = 55, UserName = "testuser5", EmailAddress = "testuser5@mail.com"}
                       };
        }
    }

    public class User : IComparable<User>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        
        public int CompareTo(User other)
        {
            if (other == null)
                throw new Exception("Cannot compare with a null object");

            return UserId.CompareTo(other.UserId);
        }
    }

    public class UserComparer : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            if (x == null || y == null)
                throw new Exception("Cannot compare null instances");

            return x.UserId.CompareTo(y.UserId);
        }
    }
}
