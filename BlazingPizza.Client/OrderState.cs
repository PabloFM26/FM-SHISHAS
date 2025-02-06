namespace BlazingPizza.Client;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }

    public Pizza? ConfiguringPizza { get; private set; }

    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Toppings = new List<PizzaTopping>(),
            ShippingMethod = "Estandar", // Se añade el envío
        };

        ShowingConfigureDialog = true;
    }


    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza is not null)
        {
            // Establecer el método de envío a nivel de la orden
            Order.ShippingMethod = ConfiguringPizza.ShippingMethod;
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;
        }

        ShowingConfigureDialog = false;
    }



    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ResetOrder()
    {
        Order = new Order();
    }

    public void ReplaceOrder(Order order)
    {
        Order = order;
    }
}
