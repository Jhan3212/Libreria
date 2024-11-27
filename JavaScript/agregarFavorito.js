document.addEventListener('DOMContentLoaded', function () {
    const usuarioActual = sessionStorage.getItem('usuarioActual');

    if (!usuarioActual) {
        alert('No se ha iniciado sesión. Por favor, inicia sesión primero.');
        window.location.href = 'inicio.html';
        return;
    }

    let favoritosPorUsuario = JSON.parse(localStorage.getItem('favoritosPorUsuario')) || {};
    let favoritos = favoritosPorUsuario[usuarioActual] || [];

    const contenedorFavoritos = document.getElementById('contenedor-favoritos');
    const searchInput = document.querySelector(".busqueda input");

    function mostrarFavoritos(librosAFiltrar) {
        contenedorFavoritos.innerHTML = ''; 
        if (librosAFiltrar.length === 0) {
            contenedorFavoritos.innerHTML = '<p>No tienes libros favoritos aún.</p>';
        } else {
            librosAFiltrar.forEach(libro => {
                const libroElemento = document.createElement('div');
                libroElemento.classList.add('libro');

                libroElemento.innerHTML = `
                    <a href="detallelibro.html?id=${libro.id}">
                        <img src="${libro.portada}" alt="Portada de ${libro.titulo}" />
                    </a>
                    <h3>${libro.titulo}</h3>
                    <button class="eliminar" data-id="${libro.id}">Eliminar de favoritos</button>
                `;

                contenedorFavoritos.appendChild(libroElemento);
            });
        }
    }

    mostrarFavoritos(favoritos);

    searchInput.addEventListener('input', function () {
        const query = searchInput.value.toLowerCase();

        console.log('Favoritos antes del filtro:', favoritos);

        const favoritosFiltrados = favoritos.filter(libro =>
            (libro.titulo && libro.titulo.toLowerCase().includes(query)) ||
            (libro.autor && libro.autor.toLowerCase().includes(query))
        );

        console.log('Favoritos después del filtro:', favoritosFiltrados);

        mostrarFavoritos(favoritosFiltrados);
    });

    contenedorFavoritos.addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('eliminar')) {
            const libroId = event.target.getAttribute('data-id');
            favoritos = favoritos.filter(libro => libro.id !== libroId);
            favoritosPorUsuario[usuarioActual] = favoritos;
            localStorage.setItem('favoritosPorUsuario', JSON.stringify(favoritosPorUsuario));
            event.target.parentElement.remove();
            mostrarFavoritos(favoritos);
        }
    });
});
