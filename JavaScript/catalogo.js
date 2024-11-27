document.addEventListener('DOMContentLoaded', function () {
    const catalogoContainer = document.getElementById("catalogo-container");
    const searchInput = document.querySelector(".busqueda input");

    function mostrarLibros(librosAFiltrar) {
        catalogoContainer.innerHTML = '';
        librosAFiltrar.forEach(libro => {
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
    }

    // Mostrar todos los libros al cargar la página
    mostrarLibros(libros);

    searchInput.addEventListener('input', function () {
        const query = searchInput.value.toLowerCase();
        const librosFiltrados = libros.filter(libro =>
            libro.titulo.toLowerCase().includes(query) ||
            libro.autor.toLowerCase().includes(query)
        );
        mostrarLibros(librosFiltrados);
    });
});
