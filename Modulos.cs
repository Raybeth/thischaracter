using Microsoft.EntityFrameworkCore;
using System.Linq;
class Modulos{
    public static void GestionarPersonaje()
    {
        var db = new PersonajesContext();
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine(@"

            Gestion de Personaje

            1. Agregar Personaje
            2. Modificar Personaje
            3. Eliminar Personaje
            r. Regresar
            
            ");

            var option = Utils.ReadString("Seleccione la opcion que desea realizar: ");
            switch (option.ToLower())
            {
                case "1":
                Console.Clear( );
                Console.WriteLine("Agregar Personaje: ");
                var p = new Personaje();
                
                p.Nombre = Utils.ReadString("Ingrese el nombre del personaje: ");
                p.Apellido = Utils.ReadString("Apellido del personaje: ");
                p.Foto = Utils.ReadString("Foto del personaje: ");
                p.Pronunciacion = Utils.ReadString("Pronunciacion del nombre: ");
                var listadoSerie = db.Series.ToList();
                foreach (var serie in listadoSerie) 
                {
                    Console.WriteLine($"{serie.Id} {serie.Name}");

                }
                while (p.Serie == null)
                {
                Console.WriteLine("Ingrese el Id de la serie que desea agregar");
                var s = db.Series.Find(int.Parse(Console.ReadLine()??""));
                    if (s == null)
                    {
                        Utils.Pausa("No se encontro la serie");
                    }
                    else
                    {
                        p.Serie = s.Name;
                    }
                }
                
                p.FechaNacimiento = DateTime.Parse(Utils.ReadString("Fecha de nacimiento: "));
                p.Poder = Utils.ReadString("Poder o habilidad del personaje: ");
                p.FraseFav = Utils.ReadString("Frase Favorite: ");
                p.Vestimenta = Utils.ReadString("Vestimenta del personaje: ");
                p.Altura = Utils.ReadString("Altura del personaje: ");
                var listadoSexo = db.Genders.ToList();
                foreach (var sex in listadoSexo) 
                {
                    Console.WriteLine($"{sex.Id} {sex.Sexo}");
                }
                while (p.Gender == null)
                {
                    Console.WriteLine("Ingrese el Id del Sexo del personaje: ");
                    var sex = db.Genders.Find(int.Parse(Console.ReadLine()??""));
                    if(sex == null)
                    {
                        Utils.Pausa("No se encontro el Sexo, vaya a registrarlo.");
                    }
                    else
                    {
                        p.Gender = sex.Sexo;
                    }
                }

                var listaEstado = db.Estados.ToList();
                foreach (var estado in listaEstado)
                {
                    Console.WriteLine($"{estado.Id} {estado.Condicion}");
                }
                while (p.Estado == null)
                {
                    Console.WriteLine("Ingresa el ID del estado del personaje");
                    var e = db.Estados.Find(int.Parse(Console.ReadLine()??""));
                    if(e == null)
                    {
                    Utils.Pausa("No se encontro el estado del personaje");
                    }
                    else
                    {
                        p.Estado = e.Condicion;
                    }
                    
                }

                p.Direccion = Utils.ReadString("Direccion del personaje: ");
                p.Latitude = Utils.ReadString("Latitude del personaje: ");
                p.Longitude = Utils.ReadString("Longitude del personaje: ");


                
                db.Personajes.Add(p);
                db.SaveChanges();
                Utils.Pausa("Personaje agregado exitosamente.");

                break;

                case "2":
                Console.Clear();
                Console.WriteLine("Editar personaje");

                List<Personaje> personajes = db.Personajes.ToList();
                foreach (var pers in personajes)
                {
                    Console.WriteLine($" {pers.Id} . {pers.Apellido} {pers.Nombre}");
                }
                Console.WriteLine("Ingrese el ID del personaje que desea editar: ");
                var editar = db.Personajes.Find(int.Parse(Console.ReadLine()??""));
                if (editar == null)
                {
                    Utils.Pausa("Personaje no localizado.");
                
                }
                else
                {
                    Console.WriteLine($" Editar nombre: ({editar.Nombre})");
                    editar.Nombre = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Apellido: ({editar.Apellido})");
                    editar.Apellido = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Foto: ({editar.Foto})");
                    editar.Foto = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Pronunciacion: ({editar.Pronunciacion})");
                    editar.Pronunciacion = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Fecha de Nac.: ({editar.FechaNacimiento})");
                    editar.FechaNacimiento = DateTime.Parse(Console.ReadLine()??"");
                    Console.WriteLine($" Editar Poder: ({editar.Poder})");
                    editar.Poder = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Frase Favorita: ({editar.FraseFav})");
                    editar.FraseFav = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Vestimenta: ({editar.Vestimenta})");
                    editar.Vestimenta = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Altura: ({editar.Altura})");
                    editar.Altura = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Direcion: ({editar.Direccion})");
                    editar.Direccion = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Latitude: ({editar.Latitude})");
                    editar.Latitude = Console.ReadLine()??"";
                    Console.WriteLine($" Editar Longitude: ({editar.Longitude})");
                    editar.Longitude = Console.ReadLine()??"";
                    Utils.Pausa("Personaje editado exitosamente.");
                    db.SaveChanges();

                }
                break;

                case "3":
                Console.Clear();
                Console.WriteLine("Eliminar personaje: ");
                List<Personaje> thispersonaje = db.Personajes.ToList();
                foreach (var pers in thispersonaje)
                {
                    Console.WriteLine($"{pers.Id} - {pers.Nombre}");

                }
                Console.WriteLine("Ingrese el ID del personaje que desea eliminar");
                var eliminar = db.Personajes.Find(int.Parse(Console.ReadLine()??""));
                if (eliminar == null)
                {
                    Utils.Pausa("Personaje no localizado.");
                }
                else
                {
                    db.Personajes.Remove(eliminar);
                    db.SaveChanges();
                    Utils.Pausa("Personaje eliminado exitosamente.");
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


    public static void GestionarReportes()
    {
        var db = new PersonajesContext();
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine(@"
            
            REPORTES
            1. Listado de Personajes
            2. Personaje y el Zodiaco
            3. Personaje y Cumpleanos
            4. Ubicacion de Personaje
            5. Exportar personaje 
            6. Personajes por serie
            7. Estado de personaje
            r. Regresar

             ");

             var opcion = Utils.ReadString("Ingrese la opcion deseada: ");
             switch (opcion.ToLower()) 
             {
                case "1":
                Console.Clear();
                Console.WriteLine("Listado de personajes: ");
                List<Personaje> thischaracter = db.Personajes.ToList();
                foreach (var person in thischaracter)
                {
                    Console.WriteLine($"{person.Id} - {person.Nombre} {person.Apellido}  {person.Edad()} Años " ); 

                }
                Utils.Pausa("Gracias por consultar");
                break;

                case "2":
                Console.Clear();
                Console.WriteLine("Personajes y el Zodiaco: ");
                List<Personaje> listapersonaje = db.Personajes.ToList();
                {
                int results = 0;
                    
                foreach (var Personaje in listapersonaje)
                {
                    if(Personaje.Signo() == Personaje.Signo())

                    {    
                        results++;

                    }
                    Console.WriteLine($" {(Personaje.Signo())} {(results)}");

                    
                }

            }
                Utils.Pausa("Estos son los resultados");

                break;
                case "3":
                Configuracion.Cumpleanos();


                break;
                case "4":
                Console.WriteLine("Ver Mapa");

                var marcadores = "";

                var per = db.Personajes.ToList();

                foreach (var p in per)
                {
                    marcadores += @$"

                        
                        var marker = L.marker([{p.Latitude}, {p.Longitude}])
                        .addTo(map)
                        .bindPopup(`
                        <h2>{p.Nombre}</h2>
                        Serie: {p.Serie}<br/>
                        Estado: {p.Estado}<br/>
                        Habilidad: {p.Poder}<br/>
                        Genero: {p.Gender}<br/>
                        
                        `);

                    ";
                }

                var plantilla = System.IO.File.ReadAllText("plantilla.html");
                plantilla = plantilla.Replace("CODIGODINAMICOC#", marcadores);

                System.IO.File.WriteAllText("Maps.html", plantilla);
                var uri = "Maps.html";
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                System.Diagnostics.Process.Start(psi);

                Utils.Pausa("Mapa abierto");
            

                break;
                case "5":
                
                Console.Clear();
                Console.WriteLine("Exportar personaje");
                Personaje personaje= null;
                while (personaje == null) 
                {
                    var id = Utils.ReadString("Ingrese el ID del personaje o x  para ver un listado: ");
                    if (id.ToLower().Trim() == "x")
                    {
                        var listadoPersonaje = db.Personajes.ToList();


                        foreach (var p in listadoPersonaje)
                        {
                            Console.WriteLine($" {p.Id} - {p.Nombre} {p.Apellido}");

                        }
                        id = Utils.ReadString("Ingrese el ID del personaje que desea exportar: ");
                        personaje = db.Personajes.Find(int.Parse(id));
                        if (personaje == null)
                        {
                            Utils.Pausa("Cancelado");
                            return;
                        }

                    }
                    var html = @$"
            <html>
                <head><!-- Compiled and minified CSS -->
                <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css'>
                </head>
                <body>
                <div class='container'>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>

                <nav>
                    <div class='nav-wrapper #f44336 red'>
                <h2 style='text-align: center;'> Personaje Base de Datos <strong></strong></h2>
                    </div>
                </nav>
                
                <p style='text-align: left;'>&nbsp;</p>
                
                <div class='row'>
                <div class='col s5'>
                <img style = 'max-width: 400px' src= {personaje.Foto} alt = 'logo' class= 'logo'> 
                </div>
                

                
                <div class='col s7'>
                <p style='text-align: left;'>&nbsp;</p>
                <b>Nombre: </b> {personaje.Nombre} {personaje.Apellido}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Serie: </b> {personaje.Serie}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Fecha de Nacimiento: </b>{personaje.FechaNacimiento}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Habilidad Especial: </b>{personaje.Poder}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Frase Favorita: </b>{personaje.FraseFav}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Sexo: </b>{personaje.Gender}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Estado: </b>{personaje.Estado}
                <p style='text-align: left;'>&nbsp;</p>
                <b>Vestimenta: </b>{personaje.Vestimenta}

                </div>
                </div>

                
                <p style='text-align: left;'>&nbsp;</p>
                <p style='text-align: left;'> © 2022 por Lisbeth Jimenez</p>
                <hr/>
                </div>         
                </body>
            </html>
                    ";
                    System.IO.File.WriteAllText("personaje.html", html);
                    var url = "personaje.html";
                    var psl = new System.Diagnostics.ProcessStartInfo();
                    psl.UseShellExecute = true;
                    psl.FileName = url;
                    System.Diagnostics.Process.Start(psl);

                    Utils.Pausa("");


                
                }

                break;
                case "6":
                Console.Clear();
                Console.WriteLine("Lista de personajes por serie: ");
                List<Serie> listaSerie = db.Series.ToList();
                List<Personaje> listaPersonajes = db.Personajes.ToList(); 
                Console.WriteLine("--------------------------------");
                foreach (var serie in listaSerie)
                {
                    var total = 0;
                    foreach (var personajes in listaPersonajes)
                    {
                        if (personajes.Serie == serie.Name)
                        {
                            total++;

                        }
                    }
                    Console.WriteLine($"{serie.Name}: {total} personajes");
                }
                    Utils.Pausa("Resultados obtenidos");




                break;
                case "7":
                Console.Clear();
                Console.WriteLine("Lista de personajes por Estado:");
                List<Estado> listaestados = db.Estados.ToList();
                List<Personaje> listaPers = db.Personajes.ToList();
                Console.WriteLine("--------------------------------");
                foreach (var estado in listaestados)
                {
                    var total = 0;
                    foreach (var persona in listaPers)
                    {
                        if (persona.Estado == estado.Condicion)
                        {
                            total++;

                        }

                    }
                    Console.WriteLine($"{estado.Condicion}: {total} personajes");

                }
                Utils.Pausa("");
                Utils.Pausa("ENTER para continuar");



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


    public static void GestionarConfiguracion()

    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine(@"
            CONFIGURATION

            1. Series
            2. Estado
            3. Genero
            r. Regresar

            ");

        var opcion = Utils.ReadString("Increse la opcion deseada:");
        switch (opcion.ToLower())
        {
            case "1": 
            Configuracion.Serie_Setup();  
            break;
            case "2":
            Configuracion.Estado_Setup();
            break;
            case "3":
            Configuracion.Sexo_Setup();

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

    public static void GestionarAcerde()
    {
                    var url = "https://youtu.be/oMGFf6P0VCc";
                    var psl = new System.Diagnostics.ProcessStartInfo();
                    psl.UseShellExecute = true;
                    psl.FileName = url;
                    System.Diagnostics.Process.Start(psl);

                    Utils.Pausa("");
    }
}


