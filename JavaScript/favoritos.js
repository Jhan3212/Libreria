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

    let favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];

    if (!favoritos.some(fav => fav.id === libro.id)) {
        favoritos.push(libro);
        localStorage.setItem('favoritos', JSON.stringify(favoritos));
        alert('Libro agregado a favoritos');
    } else {
        alert('Este libro ya está en tus favoritos');
    }
});
