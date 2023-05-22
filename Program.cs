
using Calculadora.Clases;

class Program 
{
    public static void Main()
    {
        OrdenService ordenService = new OrdenService();

        while(true)
        {
            try
            {
                
                Cliente cliente = Cliente.promptCliente();

                Orden orden_venta = new Orden();

                orden_venta = ordenService.agregarArticulos(orden_venta);

            }
            catch(Exception error)
            {
                
            }
        }

    }
}