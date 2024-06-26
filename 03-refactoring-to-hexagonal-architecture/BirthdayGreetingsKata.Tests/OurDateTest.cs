using NUnit.Framework;

namespace BirthdayGreetingsKata.Tests;

public class OurDateTest
{
    [Test]
    public void Is_Same_Date()
    {
        var ourDate = new OurDate("1789/01/24");
        var sameDay = new OurDate("2001/01/24");
        var notSameDay = new OurDate("1789/01/25");
        var notSameMonth = new OurDate("1789/02/25");

        Assert.That(ourDate.IsSameDay(sameDay), Is.True, "same");
        Assert.That(ourDate.IsSameDay(notSameDay), Is.False, "not same day");
        Assert.That(ourDate.IsSameDay(notSameMonth), Is.False, "not same month");
    }

    [Test]
    public void Equality()
    {
        var dateBase = new OurDate("2000/01/02");
        var same = new OurDate("2000/01/02");
        var different = new OurDate("2000/01/04");

        Assert.That(dateBase, Is.EqualTo(dateBase));
        Assert.That(dateBase, Is.EqualTo(same));
        Assert.That(dateBase, Is.Not.EqualTo(different));
    }
}