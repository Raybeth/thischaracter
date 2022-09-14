using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

class PersonajesContext : DbContext
{
    public DbSet<Personaje> Personajes { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Estado> Estados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=personajes.db");

    }
}

public class Personaje
{
    public int Id { get; set; }
    public string Nombre { get; set; } ="";
    public string Apellido { get; set; }
    public string Foto { get; set; }
    public string Pronunciacion { get; set; }
    public string Serie { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Poder { get; set; } //Habilidad del personaje
    public string FraseFav { get; set; }
    public string Vestimenta { get; set; }
    public string Altura { get; set; }
    public string Gender { get; set; }
    public string Estado { get; set; }

    public string Direccion { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public double Edad ()
    {
        DateTime fNacimiento = FechaNacimiento;
        DateTime fechaActual = DateTime.Now;
        int edad = fechaActual.Year - fNacimiento.Year;

        return edad;

    } 
    
    public string Signo()
        {
            DateTime fNacimiento = FechaNacimiento;
            var mes = FechaNacimiento.Month;
            var dia = FechaNacimiento.Day;

            string signo = "";

            if(dia >= 22 && mes == 12 || dia <= 19 && mes == 01)
            {
                signo = "Capricornio";

            }
            else if(dia >= 20 && mes == 01 || dia <= 18 && mes == 02)
            {
                signo = "Acuario";
            }
            else if(dia >= 19 && mes == 02 || dia <= 20 && mes == 03)
            {
                signo = "Piscis";
            }
            else if(dia >= 21 && mes == 03 || dia <= 19 && mes == 04)
            {
                signo = "Aries";
            }
            else if(dia >= 20 && mes == 04 || dia <= 20 && mes == 05)
            {
                signo = "Tauro";
            }
            else if(dia >= 21 && mes == 05 || dia <= 20 && mes == 06)
            {
                signo = "Géminis";
            }
            else if(dia >= 21 && mes == 06 || dia <= 22 && mes == 07)
            {
                signo = "Cáncer";
            }
            else if(dia >= 23 && mes == 07 || dia <= 22 && mes == 08)
            {
                signo = "Acuario";
            }
            else if(dia >= 23 && mes == 08 || dia <= 22 && mes == 09)
            {
                signo = "Virgo";
            }
            else if(dia >= 23 && mes == 09 || dia <= 22 && mes == 10)
            {
                signo = "Libra";
            }
            else if(dia >= 23 && mes == 10 || dia <= 21 && mes == 11)
            {
                signo = "Escorpio";
            }
            else if(dia >= 22 && mes == 11 || dia <= 21 && mes == 12)
            {
                signo = "Sagitario";
            }

            return signo;
        }

}

public class Serie
{
    public int Id { get; set; }
    public string Name { get; set; }
     

}

public class Gender
{
    public int Id { get; set; }
    public string Sexo { get; set; }
}
public class Estado
{
    public int Id { get; set; }
    public string Condicion { get; set; }
}
