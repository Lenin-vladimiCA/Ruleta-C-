using System.Diagnostics;
using System.Runtime.Serialization.DataContracts;
using System.Threading.Tasks.Dataflow;
using NAudio.Wave;
using Spectre.Console;

internal class Program
{
    private static string [] OpcionesMeru = new string[]
    {     
        "Iniciar",
        "Reiniciar",
        "Actualizar Lista",
        "Cerrar Programa ",

    };

    private static string[]OpcionesInternas = new string[]
    {
        "Agregar",
        "Eliminar",

    };

    public static int x;
    public static int y;

    public static int s;
    public static int b;


    public static string paricipante_DV = @"C:\Users\vladi\OneDrive\Escritorio\competencia\paricipante_DV.txt";
    public static string Participante_FED = @"C:\Users\vladi\OneDrive\Escritorio\competencia\Participante_FED";
    
    private static void Main(string[] args)
    {
        
        Console.Clear();

        bool loop = true;
        int contador = 0;
        
        ConsoleKeyInfo tecla;

        Console.CursorVisible = false;
                    
        
        Console.WriteLine("Seleciona una opcion de menu" + Environment.NewLine);
                
        
        x = Console.CursorLeft;
        y = Console.CursorTop;
        Console.GetCursorPosition();

        string resultado = Menu(OpcionesMeru,contador);
        while(loop)
        {
            while((tecla=Console.ReadKey(true)).Key!=ConsoleKey.Enter)
            {

              

              //Este el teclado
                switch (tecla.Key)
                {
                    //Esto hace que si le das a cursor de abajo baja
                    case ConsoleKey.DownArrow:
                    if(contador == OpcionesMeru.Length -1)continue;
                    contador++;

                    
                    break;

                    //Esto hace que si le das a cursor de arribe sube 
                    case ConsoleKey.UpArrow:
                    if(contador==0)continue;
                    contador--;
                    break;
                    default:
                    break;
                }

                Console.CursorLeft = x;
                Console.CursorTop = y;
                resultado = Menu(OpcionesMeru,contador);

            }
                switch(contador)
                {
                    case 0:
                    // este es el sonido cuando selecionas algo del menu
                     var audio_de_seleccion = @"C:\Users\vladi\OneDrive\Escritorio\Sonidos\interface-124464.mp3";
                                using(var leer_efecto =  new AudioFileReader(audio_de_seleccion))
                                using(var salida_efecto = new WaveOutEvent())
                                {
                                    salida_efecto.Init(leer_efecto);
                                    salida_efecto.Play();
                                    while(salida_efecto.PlaybackState == PlaybackState.Playing)
                                    {
                                            Thread.Sleep(10);
                                    }
                                }
                     try
                    {
                      ConsoleKeyInfo Parar ;
                      Console.Clear();
                      

                      //LLamada y arreglo de lista
                      string Blog_notas = @"C:\Users\vladi\OneDrive\Escritorio\competencia\Blog_nota";
                      string[] verificacion_prin = File.ReadAllLines(paricipante_DV);
                      string[] Participantes_prin = File.ReadAllLines(Blog_notas);
                     
                      //Esto ordena las lista                       
                      Array.Sort(Participantes_prin);
                      Array.Sort(verificacion_prin);

                      // eso verifica la listas si son iguales   
                      bool Lista_iguales = verificacion_prin.SequenceEqual(Participantes_prin);
                      
                      //esta linea de codigo para la ejecucion Alectoria
                      if((Parar = Console.ReadKey(true)).Key!=ConsoleKey.P)
                      {
                        
                      }
                      
                      while (!Lista_iguales)
                      {
                          List<string> Participantes_DV = new List<string>();
                          List<string> Participantes_FED = new List<string>();

                          using (StreamReader Notas = new StreamReader(Blog_notas))
                          {
                              string Linea;
                              while ((Linea = Notas.ReadLine()!) != null)
                              {
                                  Participantes_DV.Add(Linea);
                                  Participantes_FED.Add(Linea);
                              }
                          }
                          
                          //esto silver para contar lo que hay dentro de la lista 
                          int Contador_FED = Participantes_FED.Count;
                          int Contador_DV = Participantes_DV.Count;

                          Random random1 = new Random();
                          Random random2 = new Random();

                          List<int> Numerodisponible2 = new List<int>();
                          List<int> NumeroDisponible = new List<int>();

                          for (int D = 0; D < Contador_DV; D++) {NumeroDisponible.Add(D); }
                          for (int F = 0; F < Contador_FED; F++) { Numerodisponible2.Add(F); }

                          while (Lista_iguales != true)
                          {
                              int Alectorio1 = random1.Next(0, NumeroDisponible.Count);
                              string Desarrollador = Participantes_DV[NumeroDisponible[Alectorio1]];

                              int Alectorio2 = random2.Next(0, Numerodisponible2.Count);
                              string Facilitador = Participantes_FED[Numerodisponible2[Alectorio2]];

                              using (StreamWriter Escribe = new StreamWriter(paricipante_DV, true)) { Escribe.WriteLine(Desarrollador); }
                              using (StreamWriter Escribe = new StreamWriter(Participante_FED, true)) { Escribe.WriteLine(Facilitador); }

                              NumeroDisponible.RemoveAt(Alectorio1);
                              Numerodisponible2.RemoveAt(Alectorio2);
                              
                              string esp ="                      ";
                              string sal ="\n";
                              Console.WriteLine($"{esp}{sal}{sal}Desarrollador En Vivo\n{Desarrollador}");
                              Console.WriteLine($"{esp}{esp}{sal}Facilitador de Ejercicio a Desarrollar\n{Facilitador}");

                              Console.ReadKey();
                              Console.Clear();
                          }

                          Console.WriteLine("Se te acabaron los participantes");

                          
                          //Esto verifica  si la listas son iguales 
                          Lista_iguales = verificacion_prin.SequenceEqual(File.ReadAllLines(Blog_notas));
                          
                      }
                     // En caso de que no funcione el codigo anterior
                    }catch(Exception)
                    {
                    Console.WriteLine("Disculpa no hay más participantes sin repetir. Por favor inténtalo más tarde o reinicie la lista");
                    Console.WriteLine("\"Preciona Cualquier Tecla a Parte de <Enter> para regresar al Menu  ");
                    Console.Clear();

                    }
                    Console.WriteLine("Seleciona una opcion de Menu" + Environment.NewLine);
                    break;
                    case 1:
                      //esto borra las listas para
                    Console.Clear();
                    string punto1 = "."; 
                    string punto2 = ".";
                    string punto3 = ".";
                    Console.WriteLine("REINICIANDO" + punto1 + punto2 +punto3); 
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine("Gracias por la espera Reinicio listo");
                    
                    //ruta del sonido
                    var Ruta_del_audio =@"C:\Users\vladi\OneDrive\Escritorio\Sonidos\simple-notification-152054.mp3";
                    //esto silver para darle sonido de finalizacion al codigo 
                    using(var Audio_de_confirmacion =  new AudioFileReader(Ruta_del_audio))
                    using(var Salida_de_dispositivo = new WaveOutEvent())
                    {
                        Salida_de_dispositivo.Init(Audio_de_confirmacion);
                        Salida_de_dispositivo.Play();
                        while(Salida_de_dispositivo.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    Thread.Sleep(4000);
                    Console.Clear();
                    File.WriteAllText(paricipante_DV,string.Empty);
                    File.WriteAllText(Participante_FED,string.Empty);
                    Console.WriteLine("Seleciona una opcion de menu" + System.Environment.NewLine);
                    Console.WriteLine("\"Presione cualquier tecla para mostar opciones de menu\"");
                
                    continue ;
                    
                    case 2:
                    Console.Clear();

                    //ConsoleKeyInfo tecla2;
                    bool MenuInterno = true;
                    Console.CursorVisible = false;
                    Console.WriteLine("\"Elige que quiere hacer \" " + Environment.NewLine);
                    x = Console.CursorLeft;
                    y = Console.CursorTop;
                    Console.GetCursorPosition();
                    int contador1 = 0;
                    string busqueda = Menu(OpcionesInternas,contador1);

                    while(MenuInterno)
                    {
                    
                        while((tecla = Console.ReadKey(true)).Key!=ConsoleKey.Enter)
                        {
                            switch(tecla.Key)
                            {
                                case ConsoleKey.DownArrow:
                                if(contador1 == OpcionesInternas.Length-1) continue;
                                contador1++;
                                break;
                                

                                case ConsoleKey.UpArrow:
                                if(contador1 == 0)continue;
                                contador1--;
                                break;

                                default:
                                break;
                            }
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        busqueda = Menu(OpcionesInternas,contador1);
                            
                        }
                        
                        string Numero_Minimo_de_letras = Console.ReadLine()!;
                    
                        
                        switch(contador1)
                        {
                            case 0:

                       
                             
                        Console.Clear();
                        string Agregado_a_lista = @"C:\Users\vladi\OneDrive\Escritorio\Programa para la competencia\Intento2\Blog_nota";
                        Console.WriteLine("Dame un Nombre que Desees Agregar");
                        string agregado = Console.ReadLine()!;
                        using(StreamWriter Nuevo_Participante =new StreamWriter(Agregado_a_lista,true))
                        {
                            if(Numero_Minimo_de_letras.Length > 3)
                            {
                            Nuevo_Participante.WriteLine("\n" + agregado);

                            }else{

                            Console.WriteLine("lo lamento tu nombre no cuenta con lo requisitos minimos de letras");
                            break;  
                            }
                        }
                            break;
                        
                            //Aqui va eliminar
                            case 1:
            Console.Clear();
            Console.WriteLine("Dime el nombre que deseas eliminar");
            string nombreAEliminar = Console.ReadLine()!;
             // Lee todas las líneas del archivo
            string ruta = @"C:\Users\vladi\OneDrive\Escritorio\Programa para la competencia\Intento2\Blog_nota";
            string[] lineas = File.ReadAllLines(ruta);
            bool nombreEncontrado = false;
            string[] nuevasLineas = new string[lineas.Length];
            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].Trim() == nombreAEliminar)
                {
                    nombreEncontrado = true;
                }
                else
                {
                    nuevasLineas[i] = lineas[i];
                }

            }
            if (nombreEncontrado)
            {
            File.WriteAllLines(ruta, nuevasLineas);
            Console.WriteLine($"El nombre '{nombreAEliminar}' se eliminó correctamente del archivo de notas.");
            }
            else
            {
            Console.WriteLine($"El nombre '{nombreAEliminar}' no se encontró en el archivo de notas.");
            }
            
            continue;
            default:
            break;
            }
            if(tecla.Key == ConsoleKey.Enter)
            {
            MenuInterno = false;
            }

            Console.Clear();
            }

            continue;
                    // Esto Cierra la Ejecucion del Programa
                    case 3:
                    loop = false;
                    Console.WriteLine("Adios");
                    break;
                    
                        
                    default:
                    break;
                }
                    

        }
    //Esto le da el aspecto visual al menu

    }
    private static string Menu(string[] item,int opcion)
    {
        string Selecion_actual= string.Empty;
        int destacado =0;
        Array.ForEach(item,elemento =>{
            if(destacado == opcion){
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor =ConsoleColor.Gray;
                Console.WriteLine("==>" + elemento + "<==");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor =ConsoleColor.Black;
                Selecion_actual =elemento;
            }else{
                Console.Write(new string(' ',Console.WindowWidth));
                Console.CursorLeft = 0;   
                Console.WriteLine(elemento);         
            }
            destacado++;
        });
        
        return Selecion_actual;
    }

    
}
            

            

           
          

                         

