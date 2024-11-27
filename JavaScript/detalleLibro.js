const urlParams = new URLSearchParams(window.location.search);
const libroId = urlParams.get('id');

const API_URL = "https://localhost:7061/api/Libros/all";

async function obtenerLibros() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) {
            throw new Error(`Error al obtener libros: ${response.status}`);
        }

        const libros = await response.json();
        mostrarDetalle(libros);
    } catch (error) {
        console.error("Error al obtener datos de la API:", error);
        document.getElementById("detalle").innerHTML = `
            <p>Error al cargar los datos. <a href="index.html">Volver al Catálogo</a></p>
        `;
    }
}

function mostrarDetalle(libros) {
    if (!libroId || isNaN(libroId)) {
        document.getElementById("detalle").innerHTML = `
            <p>ID inválido. <a href="index.html">Volver al Catálogo</a></p>
        `;
        return;
    }

    const libro = libros.find((libro) => libro.idlibro == libroId);

    if (libro) {
        document.getElementById("titulo").innerText = libro.titulo;
        document.getElementById("portada").src = libro.urlPortada || "img/default.jpg";
        document.getElementById("portada").alt = `Portada del libro: ${libro.titulo}`;
        document.getElementById("autor").querySelector("span").innerText = libro.autor;
        document.getElementById("descripcion").querySelector("span").innerText = libro.descripcion;

        const precioElemento = document.createElement("p");
        precioElemento.innerText = `Precio: $${libro.precio.toFixed(2)}`;
        document.querySelector(".informacion").appendChild(precioElemento);
    } else {
        document.getElementById("detalle").innerHTML = `
            <p>Libro no encontrado.</p>
            <img src="img/default.jpg" alt="Portada por defecto">
        `;
    }
}

document.addEventListener("DOMContentLoaded", obtenerLibros);
