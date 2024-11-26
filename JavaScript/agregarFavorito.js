document.addEventListener('DOMContentLoaded', function () {
    let favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];

    const contenedorFavoritos = document.getElementById('contenedor-favoritos');

    if (favoritos.length === 0) {
        contenedorFavoritos.innerHTML = '<p>No tienes libros favoritos aún.</p>';
    } else {
        favoritos.forEach(libro => {
            const libroElemento = document.createElement('div');
            libroElemento.classList.add('libro');

            console.log("ID del libro:", libro.id); 

            libroElemento.innerHTML = `
                <a href="detallelibro.html?id=${libro.id}">
                    <img src="${libro.portada}" alt="Portada de ${libro.titulo}" />
                </a>
                <h3>${libro.titulo}</h3>
            `;

            contenedorFavoritos.appendChild(libroElemento);
        });
    }
});
