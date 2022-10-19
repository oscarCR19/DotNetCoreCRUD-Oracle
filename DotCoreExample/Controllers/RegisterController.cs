using DotCoreExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;


namespace DotCoreExample.Controllers
{
    public class RegisterController : Controller

    {
        // GET: RegisterController
        public ActionResult Register()
        {
            return View();
        }

        public List<User> ObtenerUsuarios()
        {
            DataTable dt = new DataTable();
            List<User> users=new List<User>();
            DBConnectionController dbConnectionController = new DBConnectionController();
            List<OracleParameter> param = new List<OracleParameter>();
            param.Add(new OracleParameter("@personsCursor", OracleDbType.RefCursor, ParameterDirection.InputOutput));
            dt=dbConnectionController.fillStoreDb("dbausuarios.pckgUsuario.GetPersons", param);
            
            foreach (DataRow item in dt.Rows)
            {
                users.Add(new User
                {
                    Id = Convert.ToInt32(item["id_usuario"]),
                    nombre1 = item["nombre1"].ToString(),
                    nombre2 = item["nombre2"].ToString(),
                    apellido1 = item["apellido1"].ToString(),
                    apellido2 = item["apellido2"].ToString(),
                    cedula = item["cedula"].ToString(),
                    correo = item["correo"].ToString(),
                    usuario = item["usuario"].ToString(),
                    contra = item["contra"].ToString(),
                    foto = item["foto"].ToString(),
                    fecha_nac = Convert.ToDateTime(item["fech_nac"])
                });
            }
            return users;
        }

        public List<User> validarUsuarios(string cedula,string Correo, string Usuario)
        {
            List<User> users=new List<User>();
            users = ObtenerUsuarios();

            foreach (var item in users)
            {
                if(item.cedula==cedula || item.usuario==Usuario || item.correo == Correo)
                {
                    users.Clear();
                    break;
                }
            }

            return users;
        }

        public ViewResult RegistrarUsuario(string txtcedula, string txtNombre1, string txtNombre2, string txtApellido1, string txtApellido2, string txtCorreo, string txtFecha, string txtUsuario, string txtContra)
        {
            List<User> users = new List<User>();
            users = validarUsuarios(txtcedula, txtCorreo,txtUsuario);
            if (users.Count == 0)
            {
                ViewBag.mensaje = "Datos registrados";
                return View("~/Views/Shared/message.cshtml");
            }
            else { 




            DBConnectionController dbConnectionController = new DBConnectionController();
            List<OracleParameter> param = new List<OracleParameter>();

            param.Add(new OracleParameter("cedula", txtcedula));
            param.Add(new OracleParameter("nombre1", txtNombre1));
            param.Add(new OracleParameter("nombre2", txtNombre2));
            param.Add(new OracleParameter("apellido1", txtApellido1));
            param.Add(new OracleParameter("apellido2", txtApellido2));
            param.Add(new OracleParameter("fech_nac",Convert.ToDateTime(txtFecha).ToString("dd-MM-yyyy")));
            param.Add(new OracleParameter("correo", txtCorreo));
            param.Add(new OracleParameter("usuario", txtUsuario));
            param.Add(new OracleParameter("contra", txtContra));

            dbConnectionController.executeStoreDB("dbausuarios.pckgUsuario.insertPerson", param);
            
                
            }
            ViewBag.mensaje = "Usuario registrado exitosamente";
            return View("~/Views/Shared/message.cshtml");


        }

       



        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
