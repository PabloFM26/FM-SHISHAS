using BlazingPizza;

public class Pizza
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public PizzaSpecial? Special { get; set; }

    public int SpecialId { get; set; }

    public List<PizzaTopping> Toppings { get; set; } = new();

    public string ShippingMethod { get; set; } = "standard"; // Método de envío

    public decimal GetBasePrice()
    {
        if (Special == null)
            throw new NullReferenceException($"{nameof(Special)} was null when calculating Base Price.");

        return Special.BasePrice;
    }

    public decimal GetTotalPrice()
    {
        if (Toppings.Any(t => t.Topping is null))
            throw new NullReferenceException($"{nameof(Toppings)} contained null when calculating the Total Price.");

        decimal basePrice = GetBasePrice();
        decimal toppingsPrice = Toppings.Sum(t => t.Topping!.Price);
        decimal shippingCost = ShippingMethod switch
        {
            "express" => 10.00m,
            "pickup" => 0.00m,
            _ => 5.00m // Envío estándar
        };

        return basePrice + toppingsPrice + shippingCost;
    }

    public string GetFormattedTotalPrice()
    {
        return GetTotalPrice().ToString("0.00");
    }
}
