using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add() // Metodo de agregar

        
        {
                ML.Usuario usuario = new ML.Usuario();/* Datos compuestos. Crear objeto que contenga todo lo de la clase ML
            para ocuparlo en pedir los datos*/

            //Pedir datos por pantalla 


                Console.WriteLine("Ingrese el user name");
                usuario.UserName = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del usuario para agregarlo: ");
                usuario.Nombre = Console.ReadLine();//Objeto "usuario" es de la clase ML que contiene los atributos

                Console.WriteLine("Ingrese el apellido paterno del usuario: ");
                usuario.ApellidoPaterno = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido materno del usuario: ");
                usuario.ApellidoMaterno = Console.ReadLine();

                Console.WriteLine("Ingrese su nuevo Email: ");
                usuario.Email = Console.ReadLine();

                Console.WriteLine("Ingrese la contraseña: ");
                usuario.Password = Console.ReadLine();

                Console.WriteLine("Ingrese su fecha de nacimiento: ");
                usuario.FechaNacimiento = Console.ReadLine();

                Console.WriteLine("Ingrese su Genero: ");
                usuario.Sexo = Console.ReadLine();

                Console.WriteLine("Ingrese su numero telefonico: ");
                usuario.Telefono = Console.ReadLine();

                Console.WriteLine("Ingrese su curp");
                usuario.Curp = Console.ReadLine();

                usuario.Rol = new ML.Rol();
                Console.WriteLine("Ingrese el IdRol");
                usuario.Rol.IdRol = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el celular: ");
                usuario.Celular = Console.ReadLine();

            ML.Result result = BL.Usuario.AddEF(usuario);//Cambiar el metodo a EF
           // ML.Result result = BL.Usuario.AddLINQ(usuario); // Metodo lINQ
                     if (result.Correct)
                     {
                        Console.WriteLine("Alumno agregado correctamente");
                     }
                     else
                     {
                        Console.WriteLine("Ha ocurrido un error" +result.Message);
                     }

                Console.WriteLine(result);
            Console.ReadKey();
            
        }

        public static void Update() // Metodo agregar
        {

            ML.Usuario usuario = new ML.Usuario();/* Datos compuestos. Crear objeto que contenga todo lo de la clase ML
            para ocuparlo en pedir los datos*/

            //Pedir datos por pantalla 

            Console.WriteLine("Ingrese el id del usuario que desea actualzar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su User Name nuevo: ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del usuario que desea actualizar: ");
            usuario.Nombre = Console.ReadLine();//Objeto "usuario" es de la clase ML que contiene los atributos

            Console.WriteLine("Ingrese el apellido paterno del usuario: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su nuevo Email: ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese su fecha de nacimiento: ");
            usuario.FechaNacimiento = (Console.ReadLine());

            Console.WriteLine("Ingrese su Genero: ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese su numero telefonico: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese su curp");
            usuario.Curp = Console.ReadLine();
            
            usuario.Rol = new ML.Rol();
            Console.WriteLine("Ingrese el Id de Rol");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine("ingrese el celular: ");
            usuario.Celular = Console.ReadLine();

            ML.Result result = BL.Usuario.UpdateEF(usuario);//Duda

            if (result.Correct)
            {
                Console.WriteLine("Alumno actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.Message);
            }

            Console.WriteLine(result);
        }

        public static void Delete() // Metodo borrar
        {
            ML.Usuario usuario = new ML.Usuario();/* Datos compuestos. Crear objeto que contenga todo lo de la clase ML
            para ocuparlo en pedir los datos*/

            //Pedir datos por pantalla 

            //Console.WriteLine("Ingrese el id del usuario que desea eliminar");
            //usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el ID que desea eliminar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.DeleteEF(usuario);//Duda

            if (result.Correct)
            {
                Console.WriteLine("El usuario se ha borrado correctamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.Message);
            }

            Console.WriteLine(result);
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll();
            ML.Result result = BL.Usuario.GetAllEF();
            

            if (result.Correct)
            { 
                foreach(ML.Usuario usuario in result.Objects) 
                {

                        Console.WriteLine("El id del Usuario es: "+usuario.IdUsuario);
                        Console.WriteLine("El User name es: "+usuario.UserName);
                        Console.WriteLine("El nombre del usuario es:"+usuario.Nombre);
                        Console.WriteLine("El Apellido paterno del usuario es:"+usuario.ApellidoPaterno);
                        Console.WriteLine("El Apellido Materno del usuario es:"+usuario.ApellidoMaterno);
                        Console.WriteLine("El Email del usuario es: "+usuario.Email);
                        Console.WriteLine("La contraseña del usuario es: "+usuario.Password);
                        Console.WriteLine("La fecha de nacimiento del usuario es: "+usuario.FechaNacimiento);
                        Console.WriteLine("El genero del usuario es:"+usuario.Sexo);
                        Console.WriteLine("El telefono del usuario es:"+usuario.Telefono);
                        Console.WriteLine("El curp del usuario es: "+usuario.Curp);
                        Console.WriteLine("El id de rol es: "+usuario.Rol.IdRol);

                   

                }
            }
            else
            {
                Console.WriteLine("No se ha podido acceder a la informacion" + result.Message);
            }
            Console.ReadKey();

        }
        public static void GetById()
        {
            Console.WriteLine("Ingrese el ID que desea consultar");
            int IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetById(IdUsuario);
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);                

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                Console.WriteLine("El id del Usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El User name es: " + usuario.UserName);
                Console.WriteLine("El nombre del usuario es:" + usuario.Nombre);
                Console.WriteLine("El Apellido paterno del usuario es:" + usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno del usuario es:" + usuario.ApellidoMaterno);
                Console.WriteLine("El Email del usuario es: " + usuario.Email);
                Console.WriteLine("La contraseña del usuario es: " + usuario.Password);
                Console.WriteLine("La fecha de nacimiento del usuario es: " + usuario.FechaNacimiento);
                Console.WriteLine("El genero del usuario es:" + usuario.Sexo);
                Console.WriteLine("El telefono del usuario es:" + usuario.Telefono);
                Console.WriteLine("El curp del usuario es: " + usuario.Curp);
                Console.WriteLine("El id de rol es: " + usuario.Rol.IdRol);

            }
            else
            {
                Console.WriteLine("No se ha podido consultar la informacion"+result.Message);
            }

            Console.ReadKey();
        }
    }

}
