using System;

namespace BirthdayGreetingsKata2.Core;

public class Employee
{
    private readonly OurDate _birthDate;
    private readonly String _lastName;
    public string FirstName { get; }
    public string Email { get; }

    public Employee(String firstName, String lastName, OurDate birthDate,
        String email)
    {
        FirstName = firstName;
        _lastName = lastName;
        _birthDate = birthDate;
        Email = email;
    }

    public Boolean IsBirthday(OurDate today)
    {
        return today.IsSameDay(_birthDate);
    }

    private bool Equals(Employee other)
    {
        return Equals(_birthDate, other._birthDate) && _lastName == other._lastName && FirstName == other.FirstName && Email == other.Email;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_birthDate, _lastName, FirstName, Email);
    }
}