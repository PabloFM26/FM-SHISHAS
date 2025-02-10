namespace BlazingPizza;

public class Address
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no debe exceder los 50 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "La dirección (Línea 1) es obligatoria.")]
    [StringLength(100, ErrorMessage = "La dirección no debe superar los 100 caracteres.")]
    public string Line1 { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "La dirección (Línea 2) no debe superar los 100 caracteres.")]
    public string Line2 { get; set; } = string.Empty;

    [Required(ErrorMessage = "La ciudad es obligatoria.")]
    [StringLength(50, ErrorMessage = "La ciudad no debe superar los 50 caracteres.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "El país es obligatorio.")]
    [StringLength(50, ErrorMessage = "El país no debe superar los 50 caracteres.")]
    public string Region { get; set; } = string.Empty;

    [Required(ErrorMessage = "El código postal es obligatorio.")]
    [RegularExpression(@"^\d{4,10}$", ErrorMessage = "El código postal debe contener entre 4 y 10 dígitos.")]
    public string PostalCode { get; set; } = string.Empty;
}
