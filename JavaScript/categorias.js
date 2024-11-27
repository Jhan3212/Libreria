document.addEventListener('DOMContentLoaded', function () {
    const catalogoContainer = document.getElementById("catalogo-container");
    const urlParams = new URLSearchParams(window.location.search);
    const categoriaSeleccionada = urlParams.get('categoria');

    function mostrarLibros(librosAFiltrar) {
        catalogoContainer.innerHTML = ''; // Limpiar contenido previo

        if (librosAFiltrar.length === 0) {
            catalogoContainer.innerHTML = '<p>No hay libros en esta categoría.</p>';
            return;
        }

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

    if (categoriaSeleccionada) {
        const librosFiltrados = libros.filter(libro =>
            libro.categoria.toLowerCase() === categoriaSeleccionada.toLowerCase()
        );
        mostrarLibros(librosFiltrados);
    } else {
        mostrarLibros(libros); // Mostrar todos los libros si no hay categoría seleccionada
    }
});
