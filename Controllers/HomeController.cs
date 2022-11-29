using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp_9.Models;

namespace Tp_9.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpPost]
    public IActionResult GuardarUsuario(string nombre, string pass, DateTime fechaNacimiento)
    {
        BD.AgregarUsuario(nombre, pass, fechaNacimiento);
        ViewBag.Perfil=BD.verInfoUsuario2(nombre, pass);
        
        ViewBag.Usuarios=BD.cargarListaUsuarios();
        ViewBag.Computadoras=BD.cargarComputadoras(ViewBag.Perfil.idUsuario);
        ViewBag.Error=null;
        return View("Ingreso");
    }
    [HttpPost]
    public IActionResult BuscarUsuario(string nombre, string pass)
    {
        Usuario intento = BD.verInfoUsuario2(nombre, pass);
        if(intento!=null){
            ViewBag.Usuarios=BD.cargarListaUsuarios();
            ViewBag.Perfil=BD.verInfoUsuario2(nombre, pass);
            ViewBag.Error=null;
            return View("Ingreso");
        }
        else{
            return RedirectToAction("Index");
        }
    }
    public IActionResult VerComputadoras(int idUsuario)
    {
        ViewBag.Computadoras=BD.cargarComputadoras(idUsuario);
        ViewBag.Usuarios=BD.cargarListaUsuarios();
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        return View();
    }
    public Usuario mostrarInfoUsuarioAjax(int idUsuario)
    {
        Usuario elUsuario = BD.verInfoUsuario(idUsuario);
        return elUsuario;
    }
    public IActionResult filtrarBusqueda(int idUsuario, string marca)
    {
        ViewBag.Computadoras=BD.filtrarComputadoras(idUsuario, marca);
        ViewBag.Usuarios=BD.cargarListaUsuarios();
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        return View("VerComputadoras");
    }
    public Computadora mostrarInfoComputadoraAjax(int idPC)
    {
        Computadora laComputadora = BD.VerInfoComputadora(idPC);
        return laComputadora;
    }
    public IActionResult verPublicaciones(int idUsuario)
    {
        ViewBag.TusComputadoras=BD.cargarTusComputadoras(idUsuario);
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        return View("Publicaciones");
    }
    public IActionResult EliminarComputadora(int idUsuario, int idPC)
    {
        BD.EliminarComputadora(idPC);
        return RedirectToAction("verPublicaciones", new {idUsuario = idUsuario}); //parámetro = nombre del parámetro de la otra view
    }
    public IActionResult AgregarComputadora(int idUsuario)
    {
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        return View("AgregarComputadora");
    }
    [HttpPost]
    public IActionResult GuardarComputadora(int idUsuario, string nombre, int Precio, string Marca, string Procesador, string Mother, string PlacaVideo, string SO, string ram, bool EnvioADomicilio, string FuenteAlimentacion, string ImagenPortada) //Eliminar?
    {
        BD.AgregarComputadora(idUsuario, nombre, Precio, Marca, Procesador, Mother, PlacaVideo, SO, ram, EnvioADomicilio, FuenteAlimentacion, ImagenPortada);
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);

        return RedirectToAction ("verPublicaciones", new { idUsuario = idUsuario});
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Ingreso(int idUsuario)
    {
        ViewBag.Usuarios=BD.cargarListaUsuarios();
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        ViewBag.Error=null;
        return View();
    }
    public IActionResult validarCompra(int idUsuario, int idPC)
    {
        Computadora compu = BD.VerInfoComputadora(idPC);
        Usuario usuario = BD.verInfoUsuario(idUsuario);
        Usuario vendedor = BD.verInfoVendedorPC(idPC);
        if(usuario.Plata>=compu.Precio){ //CompraValidada
            BD.agregarVentaUsuarioPC(idPC); //agrega la venta al vendedor de la computadora
            BD.agregarCompraUsuario(idUsuario); //agrega la compra al usuario
            BD.descontarDineroCompraUsuario(idUsuario, compu.Precio); //se descuenta la plata al usuario
            switch(usuario.ComputadorasCompradas+usuario.ComputadorasVendidas)
            {
                case >= 20:
                usuario.Rango='A';
                break;
                case >= 18:
                usuario.Rango='B';
                break;
                case >= 16:
                usuario.Rango='C';
                break;
                case >= 14:
                usuario.Rango='D';
                break;
                case >= 12:
                usuario.Rango='E';
                break;
                case >= 10:
                usuario.Rango='F';
                break;
                case >= 8:
                usuario.Rango='G';
                break;
                case >= 6:
                usuario.Rango='H';
                break;
                case >= 4:
                usuario.Rango='I';
                break;
                default:
                usuario.Rango='J';
                break;
            }
            switch(vendedor.ComputadorasCompradas+vendedor.ComputadorasVendidas)
            {
                case >= 20:
                vendedor.Rango='A';
                break;
                case >= 18:
                vendedor.Rango='B';
                break;
                case >= 16:
                vendedor.Rango='C';
                break;
                case >= 14:
                vendedor.Rango='D';
                break;
                case >= 12:
                vendedor.Rango='E';
                break;
                case >= 10:
                vendedor.Rango='F';
                break;
                case >= 8:
                vendedor.Rango='G';
                break;
                case >= 6:
                vendedor.Rango='H';
                break;
                case >= 4:
                vendedor.Rango='I';
                break;
                default:
                vendedor.Rango='J';
                break;
            }
            BD.actualizarRangoUsuario(idUsuario, usuario.Rango); //Actualiza el rango del usuario
            BD.actualizarRangoUsuario(vendedor.idUsuario, vendedor.Rango); //Actualiza el rango del vendedor
            BD.CompuNoDisponible(compu.idPC); //Deshabilita la computadora (todas las computadoras son unicas)
            ViewBag.Error="¡Compra completada!";
        }
        else{
            ViewBag.Error="No se pudo comprar la computadora. Fondos Insuficientes";
        }

        ViewBag.Computadoras=BD.cargarComputadoras(idUsuario);
        ViewBag.Usuarios=BD.cargarListaUsuarios();
        ViewBag.Perfil=usuario;
        return View("VerComputadoras");
    }
    [HttpPost]
    public IActionResult ConfirmarPago(int idUsuario, int plata)
    {
        BD.AgregarPlata(idUsuario,plata);

        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        ViewBag.Mensaje="¡Se ha realizado la transacción! Saldo actual: $" + ViewBag.Perfil.Plata;
        return View("AgregarFondos");
    }
    public IActionResult AgregarFondos(int idUsuario)
    {
        ViewBag.Mensaje=null;
        ViewBag.Perfil=BD.verInfoUsuario(idUsuario);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
