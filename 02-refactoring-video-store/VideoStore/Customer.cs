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
        double totalAmount = 0;
        var frequentRenterPoints = 0;
        var result = "Rental Record for " + GetName() + "\n";

        foreach (var each in _rentals)
        {
            var thisAmount = AmountFor(each);

            frequentRenterPoints += FrequentRenterPointsFor(each);

            result += "\t" + each.GetMovie().GetTitle() + "\t"
                      + string.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.0}", thisAmount) + "\n";
            totalAmount += thisAmount;
        }

        result += "You owed " + string.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.0}", totalAmount) + "\n";
        result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points\n";

        return result;
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
        double thisAmount = 0;

        // determines the amount for each line
        switch (each.GetMovie().GetPriceCode())
        {
            case Movie.Regular:
                thisAmount += 2;
                if (each.GetDaysRented() > 2)
                    thisAmount += (each.GetDaysRented() - 2) * 1.5;
                break;
            case Movie.NewRelease:
                thisAmount += each.GetDaysRented() * 3;
                break;
            case Movie.Children:
                thisAmount += 1.5;
                if (each.GetDaysRented() > 3)
                    thisAmount += (each.GetDaysRented() - 3) * 1.5;
                break;
        }

        return thisAmount;
    }
}