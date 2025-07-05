namespace Velera_Skriner.Model
{
    public class CryptoPair
    {
        public string Symbol { get; set; }
        public decimal LastPrice { get; set; }
        public decimal PriceChangePercent { get; set; }
        public decimal Volume { get; set; }

        public string DisplaySymbol => Symbol.Length > 4
            ? Symbol.Insert(Symbol.Length - 4, "/")
            : Symbol;
    }
}
