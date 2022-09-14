class Configuracion{
    public static void Serie_Setup()
    {
        var db = new PersonajesContext();
        bool continuar = true;
                while (continuar)
                {

                Console.Clear();
                Console.WriteLine(@"
                Manejador de series:
                1. Agregar series
                2. Editar series 
                3. Eliminar series
                r. Regresar

                
                ");

                    var opcion = Utils.ReadString("Ingrese la opcion deseada: ");
                    switch (opcion.ToLower())
                    {
                    case "1":
                    Console.Clear();
                    Console.WriteLine("Agregar series: ");
                    var s = new Serie();
                    s.Name = Utils.ReadString("Ingrse el nombre de la series: ");
            
                    db.Series.Add(s);
                    db.SaveChanges();
                    Utils.Pausa("Serie agregada satisfactoriamente.");
                    break;


                    case "2":
                    Console.Clear();
                    Console.WriteLine("Editar series: ");
                    List<Serie> series = db.Series.ToList();
                    foreach (var ser in series)
                    {
                        Console.WriteLine($"{ser.Id}.    {ser.Name}");

                    }
                    Console.WriteLine("Ingrese el ID de la serie que desea editar: ");
                    var editar = db.Series.Find(int.Parse(Console.ReadLine()??""));
                    if (editar == null)
                    {
                        Utils.Pausa("Serie no localizada, intete nueva vez");
                    }
                    else
                    {
                        Console.WriteLine($"Editar serie ---> ({editar.Name}");
                        editar.Name = Console.ReadLine()??"";
                        db.SaveChanges();
                        Utils.Pausa("Serie editada satisfactoriamente.");
                    }
                    break;


                    case "3":
                    Console.Clear();
                    Console.WriteLine("Eliminar series: ");
                    var eleminar = db.Series.Find(int.Parse(Console.ReadLine()??""));
                    if (eleminar == null)
                    {
                        Utils.Pausa("Serie no localizada");

                    }
                    else
                    {
                        db.Series.Remove(eleminar);
                        db.SaveChanges();
                        Utils.Pausa("Serie eliminada satisfactoriamente.");

                    }
                    break;

                    case "r":
                    continuar = false;
                    break;

                    default:
                    Utils.Pausa("Opcion no valida");
                    break;
                }
        }
  
    }

    public static void Estado_Setup()
    {


       var db = new PersonajesContext(); 
       bool continuar = true;
       while (continuar)
       {

       
       Console.WriteLine(@"
       Agregar Estado:
       1. Agregar
       r. Regrasar
       
       ");
       var opcion = Utils.ReadString("Elija la opcion: ");
       switch (opcion.ToLower())

        {
        case "1":
        Console.Clear();
        Console.WriteLine("Agregar estados: "); 
        var e = new Estado();
        e.Condicion = Utils.ReadString("Ingrese el estado: ");
        db.Estados.Add(e);
        db.SaveChanges();
        Utils.Pausa("Estado agregado!");
        break;
        case "r":
        continuar = false;
        break;
        default:
        Utils.Pausa("Opcion no valida");
        break;

        }
    }
        
 }

public static void Sexo_Setup()
{
    var db = new PersonajesContext(); 
    bool continuar = true;
while (continuar)
{
    Console.WriteLine(@"
    Agregar Sexo del personaje:
    1. Agregar
    r. Regrasar
    ");
 var opcion = Utils.ReadString("Ingrse el Sexo: ");
 switch (opcion.ToLower())
 {
    case "1":
    Console.Clear();
    Console.WriteLine("Agregar Sexo: ");
    var s = new Gender();
    s.Sexo = Utils.ReadString("Ingresar sexo: ");
    db.Genders.Add(s);
    db.SaveChanges();
    Utils.Pausa("Sexo agregado!");
    break;
    case "r":
    continuar = false;
    break;
    default:
    Utils.Pausa("Opcion no valida");
    break;

 }



}
}

public static void Cumpleanos()
{
    var db = new PersonajesContext(); 
    List<Personaje> listaPersonajes = db.Personajes.ToList(); 
    foreach (Personaje personaje in listaPersonajes)
    {
        DateTime mes = personaje.FechaNacimiento;
        var Cumpleanos = mes.Month;
        if (Cumpleanos == mes.Month)
        {   
            Console.Clear();
            List<Personaje> p = db.Personajes.ToList();
            Console.WriteLine($"{personaje.Nombre} {personaje.FechaNacimiento}");
        }
        else 
        {
            Utils.Pausa("No hay personajes con esta fecha");
        }
        Utils.Pausa("Fin");


        

        
       // Console.WriteLine($"{personaje.Nombre} {personaje.FechaNacimiento.Month}");

    }
    
    
        


}
    

}



