namespace RealTimeApp.Helpers;

public static class PriceHelper
{
    public static decimal GetPrice(string symbol)
    {
        // Placeholder for getting the initial price of a symbol
        Random rand = new Random();
        int randomNumber = rand.Next(1, 101); // Generates a random number between 0 and 100, inclusive.

        return new decimal(randomNumber); // Simulate an initial price
    }
}