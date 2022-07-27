using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]  
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
           
            ML.Result result = BL.Usuario.GetAllEF();        
            

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;

            }
            else
            {
                ViewBag.Mensaje = "No se ha podido acceder a la informacion del usuario " + result.Message;
            }
            return View(usuario);
            
        }


        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {

            ML.Usuario usuario = new ML.Usuario();// instanciar clase de modelo para tener acceso a las propiedades
            usuario.Rol = new ML.Rol(); // instanciamos la clase foranea con el objeto usuario 

            ML.Result resultRol = BL.Rol.GetAllRol();// instancia para mostrar el getallRol
            ML.Result resultPais = BL.Pais.PaisGetAll();
            

            if (resultPais.Correct)
            {
                if (resultRol.Correct)
                {
                    if (IdUsuario == null)// validar si es add o no 
                    {
                        usuario.Rol = new ML.Rol(); // instanciar la clase rol con usuario FK
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();                      
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;// Instaciar todas las clases para poder llegar a pais                                                                  
                        usuario.Rol.Roles = resultRol.Objects;

                        return View(usuario); //Retornar vista vacia
                    }
                    else
                    {

                        ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);// instanciar la clase que se va a mostrar


                        if (result.Correct)// Validar si entra
                        {
                            usuario.Rol = new ML.Rol();
                            usuario = (ML.Usuario)result.Object; // unboxing
                            usuario.Rol.Roles = result.Objects;
                            return View(usuario);
                        }
                        else
                        {
                            ViewBag.Mensaje = "Ocurrio un error: " + result.Message;
                            return View("Modal");// Retorna un error en el modal
                        }
                    }
                }
            
            else
            {
                ViewBag.Mensaje = "Ocurrio un error: " + resultRol.Message;
                return View("Modal");// Retorna un error en el modal
            }
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error: " + resultPais.Message;
                return View("Modal");
            }
            
        }
       
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            
                if (usuario.IdUsuario == 0)
                {
                    result = BL.Usuario.AddEF(usuario);
                                
                        if (result.Correct)
                        {
                             ViewBag.Message = "Se ha agregado al usuario de forma exitosa¡¡";
                        }
                        else
                        {
                            ViewBag.Message = "No se ha podido agregar al usuario " + result.Message;
                }
                }
                else
                {
                    result = BL.Usuario.UpdateEF(usuario);                    
                   
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se a actualizado al usuario";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar al usuario" + result.Message;
                    }
                }
            return View("Modal");
        }
            
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            
            ML.Usuario usuario = new ML.Usuario(); //Acceder a las propiedades
           usuario.IdUsuario =  IdUsuario;// MAndar el id 

           ML.Result result = BL.Usuario.DeleteEF(usuario);// Mandar todo el parametro con el usuario   

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                Console.WriteLine("No se ha borrado el usuario" + result.Message);
            }
            return View(usuario);

        }

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.EstadoGetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

    }
}