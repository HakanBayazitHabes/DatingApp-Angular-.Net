using System.Text.Json;
using API.Helpers;

namespace API.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));

        // "Access-Control-Expose-Headers"(sabit bir ifadedir) başlığını HTTP yanıtına ekler ve bu başlığın değerini "Pagination" olarak ayarlar. Bu, "Pagination" başlığının CORS (Cross-Origin Resource Sharing) politikaları altında açığa çıkarılmasını sağlar.
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
    }
}
