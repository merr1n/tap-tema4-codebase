namespace WebAPI.Dto;

public class SubscriptionDto
{
    public SubscriptionDto(string type, float price)
    {
        Type = type;
        Price = price;
    }

    public string Type {  get; set; }
    public float Price { get; set; }
}

