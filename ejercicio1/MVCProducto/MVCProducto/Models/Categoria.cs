namespace MVCProducto.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        // Propiedad de navegación
        public ICollection<Producto> Producto { get; set; }
    }
}