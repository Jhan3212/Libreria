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

    if (favoritos.length === 0) {
        contenedorFavoritos.innerHTML = '<p>No tienes libros favoritos aún.</p>';
    } else {
        favoritos.forEach(libro => {
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

    contenedorFavoritos.addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('eliminar')) {
            const libroId = event.target.getAttribute('data-id');
            favoritos = favoritos.filter(libro => libro.id !== libroId);

            favoritosPorUsuario[usuarioActual] = favoritos;
            localStorage.setItem('favoritosPorUsuario', JSON.stringify(favoritosPorUsuario));

            event.target.parentElement.remove();

            if (favoritos.length === 0) {
                contenedorFavoritos.innerHTML = '<p>No tienes libros favoritos aún.</p>';
            }
        }
    });
});
