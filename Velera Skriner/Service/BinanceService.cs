using System.Net.Http;
using System.Text.Json;

public class BinanceService
{
    private readonly HttpClient _httpClient = new();

    public async Task<List<CryptoPair>> GetCryptoPairsAsync()
    {
        var url = "https://api.binance.com/api/v3/ticker/24hr";
        var json = await _httpClient.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var result = new List<CryptoPair>();

        foreach (var element in doc.RootElement.EnumerateArray())
        {
            var symbol = element.GetProperty("symbol").GetString();
            if (!symbol.EndsWith("USDT")) continue; // Фільтруємо тільки до USDT-пар

            result.Add(new CryptoPair
            {
                Symbol = symbol,
                LastPrice = decimal.Parse(element.GetProperty("lastPrice").GetString() ?? "0"),
                PriceChangePercent = decimal.Parse(element.GetProperty("priceChangePercent").GetString() ?? "0"),
                Volume = decimal.Parse(element.GetProperty("volume").GetString() ?? "0")
            });
        }

        return result;
    }
}

