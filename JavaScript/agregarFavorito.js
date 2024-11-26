document.addEventListener('DOMContentLoaded', function () {
    let favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];

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
                <p>Autor: ${libro.autor}</p>
                <p>${libro.descripcion}</p>
                <button class="eliminar" data-id="${libro.id}">Eliminar de favoritos</button>
            `;

            contenedorFavoritos.appendChild(libroElemento);
        });
    }

    contenedorFavoritos.addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('eliminar')) {
            const libroId = event.target.getAttribute('data-id');
            favoritos = favoritos.filter(libro => libro.id !== libroId);
            localStorage.setItem('favoritos', JSON.stringify(favoritos));
            event.target.parentElement.remove(); 
        }
    });
});
