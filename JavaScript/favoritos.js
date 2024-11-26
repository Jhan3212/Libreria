// Seleccionamos el botón de favoritos
const btnFavorite = document.querySelector('.favorite');

// Aquí puedes almacenar los libros favoritos en el localStorage o en una variable
// Si quieres guardarlos en el almacenamiento local, puedes usar localStorage.

btnFavorite.addEventListener('click', function () {
    // Recogemos los detalles del libro
    const tituloLibro = document.getElementById('titulo').textContent;
    const autorLibro = document.getElementById('autor').querySelector('span').textContent;
    const descripcionLibro = document.getElementById('descripcion').querySelector('span').textContent;

    const portadaLibro = document.getElementById('portada').src;

    // Crear un objeto del libro
    const libro = {
        titulo: tituloLibro,
        autor: autorLibro,
        portada: portadaLibro
    };

    // Guardamos el libro en el almacenamiento local (localStorage)
    // Puedes usar localStorage para que los favoritos persistan entre recargas de página
    let favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];

    // Agregar el libro si no está en la lista
    if (!favoritos.some(fav => fav.titulo === libro.titulo)) {
        favoritos.push(libro);
        localStorage.setItem('favoritos', JSON.stringify(favoritos));
        alert('Libro agregado a favoritos');
    } else {
        alert('Este libro ya está en tus favoritos');
    }
});
