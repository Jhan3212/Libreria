document.addEventListener('DOMContentLoaded', function () {
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

    const catalogoContainer = document.getElementById("catalogo-container");

    libros.forEach(libro => {
        const libroElement = document.createElement("div");
        libroElement.classList.add("libro");

        libroElement.innerHTML = `
            <a href="detallelibro.html?id=${libro.id}">
                <img src="${libro.portada}" alt="${libro.titulo}">
            </a>
            <h3>${libro.titulo}</h3>
            <p>Autor: ${libro.autor}</p>
        `;

        catalogoContainer.appendChild(libroElement);
    });
});
