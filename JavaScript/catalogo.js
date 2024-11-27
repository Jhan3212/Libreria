document.addEventListener('DOMContentLoaded', async function () {
    const API_URL = "https://localhost:7061/api/Libros/all";
    const catalogoContainer = document.getElementById("catalogo-container");
    const searchInput = document.querySelector(".busqueda input");

    async function obtenerLibros() {
        try {
            const response = await fetch(API_URL);
            if (!response.ok) {
                throw new Error(`Error al obtener libros: ${response.status}`);
            }
            return await response.json();
        } catch (error) {
            console.error("Error al obtener libros:", error);
            catalogoContainer.innerHTML = `
                <p>Error al cargar el catálogo. Por favor, inténtalo más tarde.</p>
            `;
            return [];
        }
    }

    function mostrarLibros(librosAFiltrar) {
        catalogoContainer.innerHTML = '';
        if (librosAFiltrar.length === 0) {
            catalogoContainer.innerHTML = `<p>No se encontraron libros.</p>`;
            return;
        }

        librosAFiltrar.forEach(libro => {
            const libroElement = document.createElement("div");
            libroElement.classList.add("libro");

            libroElement.innerHTML = `
                <a href="detallelibro.html?id=${libro.idlibro}">
                    <img src="${libro.urlPortada || 'img/default.jpg'}" alt="${libro.titulo}">
                </a>
                <h3>${libro.titulo}</h3>
                <p>Autor: ${libro.autor}</p>
            `;

            catalogoContainer.appendChild(libroElement);
        });
    }

    const libros = await obtenerLibros();
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
