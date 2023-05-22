using Calculadora.Clases;
namespace Calculadora.Clases
{
    internal class Cliente
    {
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }

        public static Cliente promptCliente()
        {
            
            string name = Utils.askString("[red]Ingresa el nombre del cliente[/]");
            
            string telefono = Utils.askString("[red]Ingresa el telefono del cliente[/]");
            
            string correo = Utils.askString("[red]Ingresa el correo del cliente[/]");

            Cliente cliente = new Cliente(){
                nombre = name,
                telefono = telefono,
                correo = correo
            };

            return cliente;

        }
    }
}
