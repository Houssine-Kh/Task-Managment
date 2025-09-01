using System;
using Domain.Abstractions;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public User(string name, string email)
        {
            SetName(name);
            SetEmail(email);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("User name is required.");
            Name = name.Trim();
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");
            Email = email.Trim();
        }
    }
}
