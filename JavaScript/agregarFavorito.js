document.addEventListener('DOMContentLoaded', function () {
    // Obtener los libros favoritos desde localStorage
    let favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];

    const contenedorFavoritos = document.getElementById('contenedor-favoritos');

    // Si no hay favoritos, mostramos un mensaje
    if (favoritos.length === 0) {
        contenedorFavoritos.innerHTML = '<p>No tienes libros favoritos aún.</p>';
    } else {
        // Mostrar los favoritos en el contenedor
        favoritos.forEach(libro => {
            const libroElemento = document.createElement('div');
            libroElemento.classList.add('libro'); // Usamos la misma clase de estilo que para los libros del catálogo

            libroElemento.innerHTML = `
                <a href="detallelibro.html?id=${libro.id}">
                    <img src="${libro.portada}" alt="Portada de ${libro.titulo}" />
                </a>
                <h3>${libro.titulo}</h3>
                <p>Autor: ${libro.autor}</p>
            `;

            // Agregar el libro al contenedor de favoritos
            contenedorFavoritos.appendChild(libroElemento);
        });
    }
});
