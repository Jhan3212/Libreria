const urlParams = new URLSearchParams(window.location.search);
const libroId = urlParams.get('id');

console.log("ID en detalles:", libroId); 

const libros = [
    {
        id: "1",
        titulo: "Harry Potter",
        autor: "J.K. Rowling",
        portada: "https://m.media-amazon.com/images/M/MV5BOTA1Mzc2N2ItZWRiNS00MjQzLTlmZDQtMjU0NmY1YWRkMGQ4XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
        descripcion: "El cuarto libro de la saga Harry Potter."
    },
    {
        id: "2",
        titulo: "El Señor de los Anillos",
        autor: "J.R.R. Tolkien",
        portada: "https://ellector.com.pa/cdn/shop/products/9788445003022_470dfeea-3bed-4348-87ac-7f8b69271abf.jpg?v=1658292704",
        descripcion: "Una épica aventura en la Tierra Media."
    }
];

if (!libroId || isNaN(libroId)) {
    document.getElementById("detalle").innerHTML = `
        <p>ID inválido. <a href="index.html">Volver al Catálogo</a></p>
    `;
} else {
    const libro = libros.find((libro) => libro.id === libroId);

    if (libro) {
        document.getElementById("titulo").innerText = libro.titulo;
        document.getElementById("portada").src = libro.portada || "assets/images/default.jpg";
        document.getElementById("portada").alt = `Portada del libro: ${libro.titulo}`;
        document.getElementById("autor").querySelector("span").innerText = libro.autor;
        document.getElementById("descripcion").querySelector("span").innerText = libro.descripcion;
    } else {
        document.getElementById("detalle").innerHTML = `
            <p>Libro no encontrado.</p>
            <img src="assets/images/default.jpg" alt="Portada por defecto">
        `;
    }
}
