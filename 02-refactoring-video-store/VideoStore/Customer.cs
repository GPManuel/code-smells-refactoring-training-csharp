using System;
using System.Collections;
using System.Collections.Generic;

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
                      + string.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.0}", AmountFor(each)) + "\n";
        }

        result += "You owed " + string.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.0}", TotalAmount()) + "\n";
        result += "You earned " + TotalFrequentRenterPoints() + " frequent renter points\n";

        return result;
    }

    private int TotalFrequentRenterPoints()
    {
        var frequentRenterPoints = 0;
        foreach (var each in _rentals)
        {
            frequentRenterPoints += FrequentRenterPointsFor(each);
        }

        return frequentRenterPoints;
    }

    private double TotalAmount()
    {
        double totalAmount = 0;
        foreach (var each in _rentals)
        {
            totalAmount += AmountFor(each);
        }

        return totalAmount;
    }

    private static int FrequentRenterPointsFor(Rental each)
    {
        var frequentRenterPoints = 1;
        if (each.GetMovie().GetPriceCode() == Movie.NewRelease
            && each.GetDaysRented() > 1)
        {
            frequentRenterPoints++;
        }
        return frequentRenterPoints;
    }

    private static double AmountFor(Rental each)
    {
        double result = 0;
        switch (each.GetMovie().GetPriceCode())
        {
            case Movie.Regular:
                result += 2;
                if (each.GetDaysRented() > 2)
                    result += (each.GetDaysRented() - 2) * 1.5;
                break;
            case Movie.NewRelease:
                result += each.GetDaysRented() * 3;
                break;
            case Movie.Children:
                result += 1.5;
                if (each.GetDaysRented() > 3)
                    result += (each.GetDaysRented() - 3) * 1.5;
                break;
        }
        return result;
    }
}