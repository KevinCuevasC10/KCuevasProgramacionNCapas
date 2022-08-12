using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Ocupar la libreria System Data
using System.Data.SqlClient;//Ocupar la libreria System data y hacer referencia al servidor

namespace BL
{
    public class Usuario// Todas las clases deben ser publicas 
    {
        public static ML.Result Add(ML.Usuario usuario)//Metodo de agregar que pedira a la DL y verificar el resultado de la informacion
        {
            ML.Result result = new ML.Result();//Instanciamos La variable compuesta y creamos el objeto resul que contenga todo lo de Resultado

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))//Metodo de conexion
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "INSERT INTO usuario(NombreUsuario,ApellidoPaterno,ApellidoMaterno,Email,Contraseña,FechaNacimiento,Sexo,Telefono,Curp,IDrol,UserName) VALUES(@NombreUsuario, @ApellidoPaterno, @ApellidoMaterno, @Email, @Contraseña, @FechaNacimiento,@Sexo,@Telefono,@Curp,@IDrol,@UserName)";
                    cmd.Connection = context;
                    SqlParameter[] collection = new SqlParameter[11];

                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;

                    collection[1] = new SqlParameter("NombreUsuario", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;

                    collection[5] = new SqlParameter("Contraseña", SqlDbType.Date);
                    collection[5].Value = usuario.Password;

                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Text);
                    collection[6].Value = usuario.FechaNacimiento;

                    collection[7] = new SqlParameter("Sexo", SqlDbType.Date);
                    collection[7].Value = usuario.Sexo;

                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;

                    collection[9] = new SqlParameter("Curp", SqlDbType.VarChar);
                    collection[9].Value = usuario.Curp;

                    collection[10] = new SqlParameter("IdRol", SqlDbType.Int);
                    collection[10].Value = usuario.Rol.IdRol;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        /*
            *@Este metodo actualiza la informacion

         */
        public static ML.Result Update(ML.Usuario usuario)

        {

            ML.Result result = new ML.Result();//Instanciamos La variable compuesta y creamos el objeto resul que contenga todo lo de Resultado

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))//Metodo de conexion
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "Update usuario Set Nombre = @Nombre,ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno,Genero = @Genero,FechaNacimiento = @FechaNacimiento,Correo = @Correo where IDalumno = @IDalumno";
                    cmd.Connection = context; // Realiza la conexion con la variable context
                    SqlParameter[] collection = new SqlParameter[12];


                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;

                    collection[1] = new SqlParameter("NombreUsuario", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;

                    collection[5] = new SqlParameter("Contraseña", SqlDbType.Date);
                    collection[5].Value = usuario.Password;

                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Text);
                    collection[6].Value = usuario.FechaNacimiento;

                    collection[7] = new SqlParameter("Sexo", SqlDbType.Date);
                    collection[7].Value = usuario.Sexo;

                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;

                    collection[9] = new SqlParameter("Curp", SqlDbType.VarChar);
                    collection[9].Value = usuario.Curp;

                    collection[10] = new SqlParameter("IdRol", SqlDbType.Int);
                    collection[10].Value = usuario.Rol.IdRol;

                    collection[11] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[11].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();//Instanciamos La variable compuesta y creamos el objeto resul que contenga todo lo de Resultado

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))//Metodo de conexion
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "DELETE FROM usuario where IDalumno = @IDalumno";
                    cmd.Connection = context;
                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("IDalumno", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();//Instanciamos La variable compuesta y creamos el objeto resul que contenga todo lo de Resultado

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))//Metodo de conexion
                {
                    SqlCommand cmd = new SqlCommand();

                    //cmd.CommandText = "INSERT INTO usuario(Nombre,ApellidoPaterno,ApellidoMaterno,Genero,FechaNacimiento,Correo) VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Genero, @FechaNacimiento, @Correo)";
                    cmd.CommandText = "UsuarioAdd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = context;
                    SqlParameter[] collection = new SqlParameter[11];

                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;

                    collection[1] = new SqlParameter("NombreUsuario", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;

                    collection[5] = new SqlParameter("Contraseña", SqlDbType.Date);
                    collection[5].Value = usuario.Password;

                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Text);
                    collection[6].Value = usuario.FechaNacimiento;

                    collection[7] = new SqlParameter("Sexo", SqlDbType.Date);
                    collection[7].Value = usuario.Sexo;

                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;

                    collection[9] = new SqlParameter("Curp", SqlDbType.VarChar);
                    collection[9].Value = usuario.Curp;

                    collection[10] = new SqlParameter("IdRol", SqlDbType.Int);
                    collection[10].Value = usuario.Rol.IdRol;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateSP(ML.Usuario usuario)

        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "UsuarioUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[12];

                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;

                    collection[1] = new SqlParameter("NombreUsuario", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;

                    collection[5] = new SqlParameter("Contraseña", SqlDbType.Date);
                    collection[5].Value = usuario.Password;

                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Text);
                    collection[6].Value = usuario.FechaNacimiento;

                    collection[7] = new SqlParameter("Sexo", SqlDbType.Date);
                    collection[7].Value = usuario.Sexo;

                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;

                    collection[9] = new SqlParameter("Curp", SqlDbType.VarChar);
                    collection[9].Value = usuario.Curp;

                    collection[10] = new SqlParameter("IdRol", SqlDbType.Int);
                    collection[10].Value = usuario.Rol.IdRol;

                    collection[11] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[11].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "UsuarioDelete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery();
                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "UsuarioGetAll";
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable tableUsuario = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);

                    data.Fill(tableUsuario);

                    if (tableUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in tableUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento = row[7].ToString();
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Curp = row[10].ToString();
                            usuario.Rol.IdRol = int.Parse(row[11].ToString());

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UsuarioGetById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    DataTable tableUsuario = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);

                    data.Fill(tableUsuario);

                    if (tableUsuario.Rows.Count > 0)
                    {
                        DataRow row = tableUsuario.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Nombre = row[0].ToString();
                        usuario.ApellidoPaterno = row[1].ToString();
                        usuario.ApellidoMaterno = row[2].ToString();


                        result.Object = usuario;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Curp, usuario.Rol.IdRol, usuario.UserName, usuario.Celular,null, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento.ToString(), usuario.Sexo, usuario.Telefono, usuario.Curp, usuario.Rol.IdRol,usuario.UserName, usuario.Celular,null,usuario.Direccion.IdDireccion,usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, usuario.Status);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.UsuarioDelete(usuario.IdUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAllEF(ML.Usuario usuarioBusquedaAbierta)
       
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    //ML.Usuario usuario = new ML.Usuario();
                    var query = context.UsuarioGetAll(usuarioBusquedaAbierta.Nombre,usuarioBusquedaAbierta.ApellidoPaterno,usuarioBusquedaAbierta.ApellidoMaterno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objUsuario in query)
                        {                        
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = objUsuario.IdUsuario;
                            usuario.Nombre = objUsuario.Nombre;
                            usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                            usuario.Email = objUsuario.Email;
                            usuario.Password = objUsuario.Password;
                            usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString();
                            usuario.Sexo = objUsuario.Sexo;
                            usuario.Telefono = objUsuario.Telefono;
                            usuario.Curp = objUsuario.Curp;
                            usuario.UserName = objUsuario.UserName;
                            usuario.Celular = objUsuario.Celular;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = objUsuario.IdRol.Value;
                            usuario.Rol.Nombre = objUsuario.NombreRol;
                            //Direccion
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                            usuario.Direccion.Calle = objUsuario.Calle;                      
                            usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;
                            usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                            //Colonia
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;
                            //Municipio
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;
                            //Estado
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;
                            //Pais
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities()) {
                    
                    var objUsuario = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    if(objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        //usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString();
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Curp = objUsuario.Curp;
                        //ML.Rol usuario = ML.Rol();
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Celular = objUsuario.Celular;
                        //Direccion
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        //Colonia
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;
                        //Municipio
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;
                        //Estado
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;
                        //Pais
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;

                        result.Object = usuario;
                        result.Correct = true;
                    
                    }

                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();
                    usuarioLINQ.Nombre = usuario.Nombre;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Curp = usuario.Curp;
                    usuario.Rol = new ML.Rol();// instancia de la clase 
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.Celular = usuario.Celular;

                    context.Usuarios.Add(usuarioLINQ);
                    context.SaveChanges();
                    result.Correct = true;
                   
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario(); 

                    usuarioLINQ.IdUsuario = usuario.IdUsuario;
                    usuarioLINQ.Nombre = usuario.Nombre;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Curp = usuario.Curp;
                    usuario.Rol = new ML.Rol();// instancia de la clase 
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.Celular = usuario.Celular;

                    context.Usuarios.Add(usuarioLINQ);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();

                    usuarioLINQ.IdUsuario = usuario.IdUsuario;

                    context.Usuarios.Add(usuarioLINQ);
                    context.SaveChanges();
                    result.Correct = true;

                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
 

    }
}