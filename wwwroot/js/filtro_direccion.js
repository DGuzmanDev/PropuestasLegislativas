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

function llenar_provincias() {
    $.each(provincias, function (i, provincia) {
        $('#Provincia').append($('<option>', {
            value: provincia,
            text: provincia
        }));
    });

    $("#Provincia").on('change', function (event) {
        console.log('La provincia es ' + this.value);
        llenar_cantones(this.value);
    });

    // aqui selecionar el primer elemento de la lista de provincias
    $("#Provincia").val(provincias[0]);
}

function llenar_cantones(provincia) {
    var cantones_select = cantones[provincia]

    console.log('Cantones: ' + cantones_select);
    $("#Canton").empty();

    $.each(cantones_select, function (i, canton) {
        $('#Canton').append($('<option>', {
            value: canton,
            text: canton
        }));
    });
}

$(document).ready(function () {
    console.log('filtro_direccion.js JavaScript - Daniel Guzman Chaves - 03101 – Programación avanzada en web - UNED IIIQ 2023');
    llenar_provincias();
});