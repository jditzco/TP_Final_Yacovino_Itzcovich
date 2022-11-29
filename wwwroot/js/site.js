// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mostrarInfoComputadoraAjax(idPC) //Las variables siempre empiezan con minúscula
    {
        $.ajax(
            {
                type:'POST',
                dataType: 'json',
                url: '/Home/mostrarInfoComputadoraAjax',
                data: {idPC: idPC}, //Datos que paso al controller
                success:
                    function (response){
                        $("#Titulo").html(response.nombre);
                        $("#Marca").html(response.marca);
                        $("#Procesador").html(response.procesador);
                        $("#Mother").html(response.mother);
                        $("#PlacaVideo").html(response.placaVideo);
                        $("#Precio").html(response.Precio);
                        $("#FuenteAlimentacion").html(response.fuenteAlimentacion);
                        $("#SO").html(response.sO);
                        $("#RAM").html(response.ram);
                        
                        let envio = "No";
                        if (response.envioADomicilio) envio = "Sí"
                        $("#EnvioADomicilio").html(envio);

                    },
                    error : (xhr, status) => {
                        alert("Hubo un problema con el modal")
                    }
            });
    }

    function mostrarInfoUsuarioAjax(idUsuario) //Las variables siempre empiezan con minúscula
    {
        $.ajax(
            {
                type:'POST',
                dataType: 'json',
                url: '/Home/mostrarInfoUsuarioAjax',
                data: {idUsuario: idUsuario}, //Datos que paso al controller
                success:
                    function (response){
                        $("#Nombre").html(response.nombre);
                        
                        let nacimento = "Fecha de nacimiento: " + response.fechaNacimiento;
                        $("#FechaNacimiento").html(nacimento);
                        
                        let signUp = "Fecha de creación de la cuenta: " + response.fechaSignUp;
                        $("#FechaSignUp").html(signUp);
                        
                        let plata = "Fondos: $" + response.plata;
                        $("#Plata").html(plata);
                        
                        let compradas = "Computadoras Compradas: " + response.computadorasCompradas;
                        $("#ComputadorasCompradas").html(compradas);
                        
                        let vendidas = "Computadoras Vendidas: " + response.computadorasVendidas;
                        $("#ComputadorasVendidas").html(vendidas);
                        
                        let elrango = "Rango " + response.rango;
                        $("#Rango").html(elrango);
                    },
                    error : (xhr, status) => {
                        alert("Hubo un problema con el modal")
                    }
            });
    }
