/*  Nombre: Ada Lisbeth Jimenez Rosendo
    Matricula: 2022-0790
    Fecha: 21/08/2022
*/



bool continuar = true;
while (continuar)
{
    Console.Clear();

    //opciones a reflejar en consola al inicio del programa
    Console.WriteLine(@"

            |`-.._____..-'|
           :  > .  ,  <  :
           `./ __`' __ \,'
            | (|_) (|_) |
            ; _  .  __  :
            `.,' - `-. ,'
              `, `_  .'
              /       \
             /         :
            :          |_
           ,|  .    .  | \
          : :   \   |  |  :
          |  \   :`-;  ;  |
          :   :  | /  /   ;
           :-.'  ;'  / _,'`------.
           `'`''-`'''-'-''--.---  )
                        SSt `----'

    DIARIO DE TUS PERSONAJES FAVORITOS 

        1. Gestionar Personaje
        2. Reportes
        3. Configuracion
        4. Acerca de
        x. Salir
    
    
    ");

    var option = Utils.ReadString("Ingrese la opcion deseada: ");
    switch (option.ToLower())
    {
        case "1":
        Modulos.GestionarPersonaje();
    
        break;

        case "2":
        Modulos.GestionarReportes(); 

        break;

        case "3":
        Modulos.GestionarConfiguracion();

        break;

        case "4":
        Modulos.GestionarAcerde();

        break;

        case "x":
        continuar = false;
        Console.WriteLine("Vuelva pronto");
        break;

        default:
        Console.WriteLine("Opcion no valida");
        break;





    }

}