const btnFavorite = document.querySelector('.favorite');

btnFavorite.addEventListener('click', function () {
    const tituloLibro = document.getElementById('titulo').textContent;
    const autorLibro = document.getElementById('autor').querySelector('span').textContent;
    const descripcionLibro = document.getElementById('descripcion').querySelector('span').textContent;
    const portadaLibro = document.getElementById('portada').src;

    const libro = {
        id: libroId,
        titulo: tituloLibro,
        portada: portadaLibro
    };

    const usuarioActual = sessionStorage.getItem('usuarioActual');

    if (!usuarioActual) {
        alert('No se ha iniciado sesión. Por favor, inicia sesión primero.');
        return;
    }

    let favoritosPorUsuario = JSON.parse(localStorage.getItem('favoritosPorUsuario')) || {};
    let favoritos = favoritosPorUsuario[usuarioActual] || [];

    if (!favoritos.some(fav => fav.id === libro.id)) {
        favoritos.push(libro);
        favoritosPorUsuario[usuarioActual] = favoritos; 
        localStorage.setItem('favoritosPorUsuario', JSON.stringify(favoritosPorUsuario));
        alert('Libro agregado a favoritos');
    } else {
        alert('Este libro ya está en tus favoritos');
    }
});
