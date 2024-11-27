// detalles.js
const urlParams = new URLSearchParams(window.location.search);
const libroId = urlParams.get('id');

console.log("ID en detalles:", libroId);

if (!libroId || isNaN(libroId)) {
    document.getElementById("detalle").innerHTML = `
        <p>ID inválido. <a href="index.html">Volver al Catálogo</a></p>
    `;
} else {
    const libro = libros.find((libro) => libro.id === libroId);

    if (libro) {
        document.getElementById("titulo").innerText = libro.titulo;
        document.getElementById("portada").src = libro.portada || "assets/images/default.jpg";
        document.getElementById("portada").alt = `Portada del libro: ${libro.titulo}`;
        document.getElementById("autor").querySelector("span").innerText = libro.autor;
        document.getElementById("descripcion").querySelector("span").innerText = libro.descripcion;
    } else {
        document.getElementById("detalle").innerHTML = `
            <p>Libro no encontrado.</p>
            <img src="assets/images/default.jpg" alt="Portada por defecto">
        `;
    }
}
