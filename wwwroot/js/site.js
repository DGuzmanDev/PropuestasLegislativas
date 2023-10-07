var tipo_identificacion_masks = {
    "Nacional": "9-1999-9999",
    "DIMEX": "999999999999"
};

const provincias = [
    "San José",
    "Alajuela",
    "Cartago",
    "Heredia",
    "Guanacaste",
    "Puntarenas",
    "Limón"
]

const cantones = {
    "San José": [
        "San José",
        "Alajuelita",
        "Vazquez de Coronado",
        "Acosta",
        "Tibas",
        "Moravia",
        "Montes de Oca",
        "Turrubares",
        "Dota",
        "Curridabat",
        "Perez Zeledón",
        "Escazú",
        "León Cortes Castro",
        "Desamparados",
        "Puriscal",
        "Tarrazu",
        "Aserri",
        "Mora",
        "Goicoechea",
        "Santa Ana"
    ],
    "Alajuela": [
        "Alajuela",
        "San Ramón",
        "Grecia",
        "San Mateo",
        "Atenas",
        "Naranjo",
        "Palmares",
        "Poás",
        "Orotina",
        "San Carlos",
        "Zarcero",
        "Sarchí",
        "Upala",
        "Los Chiles",
        "Guatuso",
        "Río Cuarto"
    ],
    "Cartago": [
        "Alvarado",
        "Cartago",
        "El Guarco",
        "Jiménez",
        "La Unión",
        "Oreamuno",
        "Paraíso",
        "Turrialba"
    ],
    "Heredia": [
        "Barva",
        "Belén",
        "Flores",
        "Heredia",
        "San Isidro",
        "San Pablo",
        "San Rafael",
        "Santa Bárbara",
        "Santo Domingo",
        "Sarapiquí"
    ],
    "Guanacaste": [
        "Liberia",
        "Nicoya",
        "Santa Cruz",
        "Bagaces",
        "Carrillo",
        "Cañas",
        "Abangares",
        "Tilarán",
        "Nandayure",
        "La Cruz",
        "Hojancha"
    ],
    "Puntarenas": [
        "Buenos Aires",
        "Corredores",
        "Coto Brus",
        "Esparza",
        "Garabito",
        "Golfito",
        "Montes de Oro",
        "Monteverde",
        "Osa",
        "Parrita",
        "Puerto Jiménez",
        "Puntarenas",
        "Quepos"
    ],
    "Limón": [
        "Limón",
        "Pococí",
        "Siquirres",
        "Talamanca",
        "Matina",
        "Guácimo"
    ]
}

function animate_feedback(element_id, timeout, show_duration, hide_duration) {
    $("#" + element_id).show(show_duration);
    setTimeout(function () {
        $("#" + element_id).hide(hide_duration);
    }, timeout);
}

function llenar_provincias() {
    $.each(provincias, function (i, provincia) {
        $('#Provincia').append($('<option>', {
            value: provincia,
            text: provincia
        }));
    });

    $("#Provincia").on('change', function (event) {
        llenar_cantones(this.value);
    });

    $("#Provincia").val(provincias[0]);
    llenar_cantones(provincias[0]);
}

function llenar_cantones(provincia) {
    var cantones_select = cantones[provincia]

    $("#Canton").empty();
    $.each(cantones_select, function (i, canton) {
        $('#Canton').append($('<option>', {
            value: canton,
            text: canton
        }));
    });
}

function registrar_evento_tipo_id() {
    $("#TipoIdentificacion").on('change', function (event) {
        var tipoIdentificacion = this.value;
        $("#Identificacion").attr("data-inputmask", "'mask': '" + tipo_identificacion_masks[tipoIdentificacion] + "'");
        $("#Identificacion").inputmask();
    });
}

function enviar_formulario() {
    var propuesta_legislativa = {
        "nombre": $("#Nombre").val(),
        "apellidos": $("#Apellidos").val(),
        "identificacion": $("#Identificacion").val(),
        "provincia": $("#Provincia").val(),
        "canton": $("#Canton").val(),
        "propuesta": $("#Propuesta").val(),
        "tipoIdentificacion": $("#TipoIdentificacion").val(),
        "correoElectronico": $("#Correo").val(),
        "telefono": $("#Telefono").val()
    }

    $.ajax({
        type: "POST",
        url: "/api/Xml/write/dynamic",
        data: JSON.stringify(propuesta_legislativa),
        success: function (data, status) {
            window.location.replace("/Success");
        },
        error: function (data, status) {
            console.log('HTTP request error, status' + status);
            window.location.replace("/Error");
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
    });
}

function registrar_evento_formulario() {
    $("#enviar").on('click', function (event) {
        event.preventDefault();

        var validForms = true;
        var form = $(".needs-validation")[0];
        $(form).addClass("was-validated");

        if (form.checkValidity() === false) {
            validForms = false;
        }

        if (!validForms) {
            animate_feedback("error_formulario", 3000, 500, 500);
        } else {
            // en el FE solo validar que el trim no me muestra vacio, en el BE puedo validar el regex

            enviar_formulario();
            $(form).removeClass("was-validated");
            form.reset();
        }
    });
}

function registrar_evento_borrar() {
    $("#cancelar").on('click', function (event) {
        $("#formulario_registro")[0].reset();
    });
}

$(document).ready(function () {
    console.log('site.js JavaScript - Daniel Guzman Chaves - 03101 – Programación avanzada en web - UNED IIIQ 2023');
    $(":input").inputmask();
    llenar_provincias();
    registrar_evento_tipo_id();
    registrar_evento_formulario();
    registrar_evento_borrar();
});