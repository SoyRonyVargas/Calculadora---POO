using Spectre.Console;

namespace Calculadora.Clases
{
    public class Utils
    {
        public static void showLogo( bool clear = true )
        {
            if( clear )
            {
                Console.Clear();
            }

            AnsiConsole.Write(
                new FigletText("Shein")
               .LeftJustified()
               .Color(Color.Red));
       }
        
        public static void printRule( string msg )
        {
            var rule = new Rule(msg).LeftJustified();
            AnsiConsole.Write(rule);
        }

        private static string concatStringInstruccion(string str)
        {

            string concat = str + " [yellow bold](Presiona ESC para salir)[/]";

            return concat;

        }

        public static string askString( string? msg = null , string error = "Ingresa un valor valido" )
        {
            
            if( msg != null )
            {
                msg = concatStringInstruccion(msg);
                Utils.printRule(msg);
            }

            string result = "";
            
            ConsoleKeyInfo lastKey;

            // read keys until Enter is pressed
            while ((lastKey = Console.ReadKey()).Key != ConsoleKey.Enter)
            {
                // if Escape is pressed, exit
                if (lastKey.Key == ConsoleKey.Escape)
                {
                    throw new Exception();
                }

                // otherwise, add the key entered to the input
                
                if( lastKey.Key != ConsoleKey.Backspace )
                {
                    result += lastKey.KeyChar.ToString();
                }
                
                if( lastKey.Key == ConsoleKey.Backspace )
                {
                    // Console.Write(" \b");
                    // Console.Write("\x1B[1D"); // Move the cursor one unit to the left
                    Console.Write("\x1B[1P");
                    try
                    {
                        result = result.Remove(result.Length - 1 , 1 );
                    }
                    catch{}
                }

            }

            System.Console.WriteLine(result);

            return result;

        }
        
        public static int askInt( string? msg = null , string error = "Ingresa un valor valido" , bool concat = true , bool clear = true )
        {
            
            if( msg != null )
            {
                if( concat )
                {
                    msg = concatStringInstruccion(msg);
                }
                Utils.printRule(msg);
                ValidationResult.Success();
            }

            string numbersEntered = "";
            
            ConsoleKeyInfo lastKey;

            // read keys until Enter is pressed
            while ((lastKey = Console.ReadKey()).Key != ConsoleKey.Enter)
            {
                // if Escape is pressed, exit
                if (lastKey.Key == ConsoleKey.Escape)
                {
                    throw new Exception();
                }

                // otherwise, add the key entered to the input

                if( lastKey.Key != ConsoleKey.Backspace )
                {
                    numbersEntered += lastKey.KeyChar.ToString();
                }
                
                if( lastKey.Key == ConsoleKey.Backspace )
                {
                    Console.Write(" \b");
                    try
                    {
                        numbersEntered = numbersEntered.Remove(numbersEntered.Length - 1 , 1 );
                    }
                    catch
                    {
                        
                    }
                }

            }

            while( true )
            {
                try
                {
                    
                    int result = int.Parse(numbersEntered);
                    
                    if( result < 0 )
                    {
                        throw new Exception("pene");
                    }
                    
                    System.Console.WriteLine(result);

                    return result;

                }
                catch
                {
                    
                    printRule("[red]Ingresa un valor valido[/]");
                    
                    return askInt( msg , error , false , clear );

                }
            }

        }

        public static double askDouble( string? msg = null , string error = "Ingresa un valor valido" , bool concat = true )
        {
            
            if( msg != null )
            {
                if( concat )
                {
                    msg = concatStringInstruccion(msg);
                }
                Utils.printRule(msg);
                ValidationResult.Success();
            }

            string numbersEntered = "";
            
            ConsoleKeyInfo lastKey;

            // read keys until Enter is pressed
            while ((lastKey = Console.ReadKey()).Key != ConsoleKey.Enter)
            {
                // if Escape is pressed, exit
                if (lastKey.Key == ConsoleKey.Escape)
                {
                    throw new Exception();
                }

                if( lastKey.Key != ConsoleKey.Backspace )
                {
                    numbersEntered += lastKey.KeyChar.ToString();
                }
                
                if( lastKey.Key == ConsoleKey.Backspace )
                {
                    Console.Write(" \b");
                    numbersEntered = numbersEntered.Remove(numbersEntered.Length - 1 , 1 );
                }
            }

            while( true )
            {
                try
                {
                    
                    double result = double.Parse(numbersEntered);
                    
                    if( result < 0 )
                    {
                        throw new Exception();
                    }
                    
                    System.Console.WriteLine(result);

                    return result;

                }
                catch
                {
                    // Menu.showMainLogo();
                    printRule("[red]Ingresa un valor valido[/]");
                    return askDouble( msg , error , false );
                }
            }

        }

        public static List<string> addSalirOpciones( List<string> opciones )
        {

            if( !opciones.Contains("Salir") )
            {
                opciones.Add("Salir");
            }

            return opciones;

        }

        public static string validarSeleccion( string opcion )
        {
            if( opcion == "Salir" )
            {
                throw new Exception();
            }

            return opcion;

        }

        public static string askOpciones( List<string> opciones , string? msg = "Selecciona una opcion"  )
        {

            opciones = addSalirOpciones(opciones);

            //arreglo de opciones
            if( msg == null )
            {
                string result = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(10)
                        .AddChoices(opciones));
                
                return validarSeleccion(result);

            }
            
            var eleccion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[red]{msg}[/]")
                    .PageSize(10)
                    .AddChoices(opciones));

            return validarSeleccion(eleccion);

        }
        
        public static List<string> askMultiOpciones( List<string> opciones , string? msg = "Selecciona una opcion"  )
        {

            string instrucciones = "[grey](Muevete con las flechas del teclado)[/] \n[grey](Presiona ESPACIO para seleccionar)[/] \n[grey](Presiona ENTER para terminar)[/]";

            //arreglo de opciones
            if( msg == null )
            {
                return AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .PageSize(10)
                    .InstructionsText(instrucciones)
                    .AddChoices(opciones));
            }
            
            var eleccion = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title($"[red]{msg}[/]")
                    .PageSize(10)
                    .InstructionsText(instrucciones)
                    .AddChoices(opciones));

            return eleccion;

        }

        public static bool handleConfirm( string msg = "" )
        {
            var seleccion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(msg)
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Confirmar", "Cancelar"
                    }));

            return seleccion == "Confirmar";

        }

    }
}