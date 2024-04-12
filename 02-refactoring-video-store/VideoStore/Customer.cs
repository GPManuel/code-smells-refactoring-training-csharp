using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VideoStore;

public class Customer
{
    private readonly List<Rental> _rentals = new();
    private readonly string _name;


    public Customer(string name)
    {
        _name = name;
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public string GetName()
    {
        return _name;
    }

    public string Statement()
    {
        var result = "Rental Record for " + GetName() + "\n";

        foreach (var each in _rentals)
        {
            result += "\t" + each.GetMovie().GetTitle() + "\t"
                      + string.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.0}", each.AmountFor()) + "\n";
        }

        result += "You owed " + string.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.0}", TotalAmount()) + "\n";
        result += "You earned " + TotalFrequentRenterPoints() + " frequent renter points\n";

        return result;
    }

    private int TotalFrequentRenterPoints() => _rentals.Sum(each => each.FrequentRenterPointsFor());

    private double TotalAmount() => _rentals.Sum(each => each.AmountFor());
}