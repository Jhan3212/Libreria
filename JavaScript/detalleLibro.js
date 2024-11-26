const urlParams = new URLSearchParams(window.location.search);
const libroId = urlParams.get('id');

const libros = [
    {
        id: "1",
        titulo: "Harry Potter",
        autor: "J.K. Rowling",
        portada: "img/harrypotter.jpg",
        descripcion: "El cuarto libro de la saga Harry Potter."
    },
    {
        id: "2",
        titulo: "El Señor de los Anillos",
        autor: "J.R.R. Tolkien",
        portada: "img/señoranillo.jpg",
        descripcion: "Una épica aventura en la Tierra Media."
    }
];

if (!libroId || isNaN(libroId)) {
    document.getElementById("detalle").innerHTML = `
        <p>ID inválido. <a href="index.html">Volver al Catálogo</a></p>
    `;
} else {
    const libro = libros.find((libro) => libro.id === libroId);

    if (libro) {
        // Mostrar los detalles del libro
        document.getElementById("titulo").innerText = libro.titulo;
        document.getElementById("portada").src = libro.portada || "assets/images/default.jpg";
        document.getElementById("portada").alt = `Portada del libro: ${libro.titulo}`;
        document.getElementById("autor").querySelector("span").innerText = libro.autor;
        document.getElementById("descripcion").querySelector("span").innerText = libro.descripcion;

        // Funcionalidad de agregar a favoritos
        const btnFavorite = document.querySelector('#btnFavorite');

        btnFavorite.addEventListener('click', function () {
            // Obtener los libros favoritos desde localStorage (si existen)
            let favoritos = JSON.parse(localStorage.getItem('favoritos')) || [];

            // Verificar si el libro ya está en los favoritos
            if (!favoritos.some(fav => fav.id === libro.id)) {
                // Agregar el libro a la lista de favoritos
                favoritos.push(libro);

                // Guardar la lista de favoritos actualizada en localStorage
                localStorage.setItem('favoritos', JSON.stringify(favoritos));
                alert('Libro agregado a favoritos');
            } else {
                alert('Este libro ya está en tus favoritos');
            }
        });

    } else {
        document.getElementById("detalle").innerHTML = `
            <p>Libro no encontrado.</p>
            <img src="assets/images/default.jpg" alt="Portada por defecto">
        `;
    }
}
