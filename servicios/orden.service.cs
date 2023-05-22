
namespace Calculadora.Clases
{
    class OrdenService {

        public Orden agregarArticulos(Orden orden)
        {

            int cantidad = Utils.askInt("[red]Ingresa la cantidad de articulos a ingresar: [/]");

            for (int i = 0; i < cantidad; i++)
            {

                string nombre = Utils.askString("[red]Ingresa el nombre del articulo[/]");
                
                double precio = Utils.askDouble("[red]Ingresa el nombre del articulo[/]");

                Articulo articulo = new Articulo()
                {
                    nombre = nombre,
                    precio = precio
                };

                orden.articulos.Add(articulo);
                
            }

            return orden;

        }
        
    }
}