using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.model;

public class User : Entity<int>
{
    string username;
    string password;
    string firstName;
    string lastName;
    string? dateOfBirth;
    string? address;

    // Constructor
    public User()
    {
    }
    public User(string username, string password, string firstName, string lastName, string dateOfBirth, string adress)
    {
        this.username = username;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.address = adress;
    }

    // Getters and setters
    public virtual string Username
    {
        get { return username; }
        set { username = value; }
    }

    public virtual string Password
    {
        get { return password; }
        set { password = value; }
    }

    public virtual string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public virtual string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public virtual string? DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public virtual string? Address
    {
        get { return address; }
        set { address = value; }
    }
    public override string ToString()
    {
        return $"{username}: {firstName} {lastName}";
    }

    public override bool Equals(object? obj)
    {
        if (this == obj)
            return true;

        if (obj is not User)
            return false;

        User user = (User)obj;
        return Equals(Id, user.Id);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
