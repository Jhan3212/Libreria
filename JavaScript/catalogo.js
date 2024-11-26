document.addEventListener('DOMContentLoaded', function () {
    // Array de libros (puedes agregar más libros aquí)
    const libros = [
        {
            id: "1",
            titulo: "Harry Potter",
            autor: "J.K. Rowling",
            portada: "img/harrypotter.jpg",
            descripcion: "El cuarto libro de la saga Harry Potter."
        },
        {
            id: "2",
            titulo: "El Señor de los Anillos",
            autor: "J.R.R. Tolkien",
            portada: "img/señoranillo.jpg",
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
