using CurrencyConverterApp;

namespace ConverterLib
{
    public class Converter : IConverter
    {
        IDollarToEuroExchangeRateFeed _exchangeRateFeed;
        public Converter(IDollarToEuroExchangeRateFeed exchangeRateFeed)
        {
            _exchangeRateFeed = exchangeRateFeed;
        }

        public double CelsiusToKelvin(double celsius) => celsius + 273.15;
        public double KilogramToPound(double kilogram) => kilogram * 2.205;
        public double KilometerToMile(double kilometer) => kilometer / 1.609;
        public double LiterToGallon(double liter) => liter / 3.785;

        public double USDToEuro(double dollar)
        {
            return dollar * _exchangeRateFeed.GetActualUSDollarValue();
        }
    }
}