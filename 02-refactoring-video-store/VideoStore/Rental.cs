namespace VideoStore;

public class Rental
{
    public Rental(Movie movie, int daysRented)
    {
        _movie = movie;
        _daysRented = daysRented;
    }

    public int GetDaysRented()
    {
        return _daysRented;
    }

    public Movie GetMovie()
    {
        return _movie;
    }

    private readonly Movie _movie;
    private readonly int _daysRented;

    public int FrequentRenterPointsFor()
    {
        var frequentRenterPoints = 1;
        if (GetMovie().GetPriceCode() == Movie.NewRelease
            && GetDaysRented() > 1)
        {
            frequentRenterPoints++;
        }
        return frequentRenterPoints;
    }

    public double AmountFor()
    {
        double result = 0;
        switch (GetMovie().GetPriceCode())
        {
            case Movie.Regular:
                result += 2;
                if (GetDaysRented() > 2)
                    result += (GetDaysRented() - 2) * 1.5;
                break;
            case Movie.NewRelease:
                result += GetDaysRented() * 3;
                break;
            case Movie.Children:
                result += 1.5;
                if (GetDaysRented() > 3)
                    result += (GetDaysRented() - 3) * 1.5;
                break;
        }
        return result;
    }
}