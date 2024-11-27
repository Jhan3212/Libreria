document.addEventListener('DOMContentLoaded', function () {
    const btnCarrito = document.querySelector('.add-to-cart');

    if (btnCarrito) {
        btnCarrito.addEventListener('click', function () {
            // Obtener el ID del libro de la URL
            const urlParams = new URLSearchParams(window.location.search);
            const libroId = urlParams.get('id');

            if (!libroId || isNaN(libroId)) {
                alert('ID de libro inválido.');
                return;
            }

            // URL de la API
            const API_URL = "https://localhost:7061/api/Libros/all";

            // Obtener los detalles del libro desde la API
            async function obtenerLibro() {
                try {
                    const response = await fetch(API_URL);
                    if (!response.ok) {
                        throw new Error(`Error al obtener el libro: ${response.status}`);
                    }

                    const libros = await response.json();
                    const libro = libros.find(libro => libro.idlibro == libroId);

                    if (libro) {
                        const libroInfo = {
                            id: libro.idlibro,
                            titulo: libro.titulo,
                            autor: libro.autor,
                            descripcion: libro.descripcion,
                            portada: libro.urlPortada || "img/default.jpg",
                            precio: libro.precio 
                        };

                        const usuarioActual = sessionStorage.getItem('usuarioActual');
                        if (!usuarioActual) {
                            alert('No se ha iniciado sesión. Por favor, inicia sesión primero.');
                            return;
                        }

                        let carritoPorUsuario = JSON.parse(localStorage.getItem('carritoPorUsuario')) || {};
                        let carrito = carritoPorUsuario[usuarioActual] || [];

                        if (!carrito.some(car => car.id === libroInfo.id)) {
                            carrito.push(libroInfo);
                            carritoPorUsuario[usuarioActual] = carrito;
                            localStorage.setItem('carritoPorUsuario', JSON.stringify(carritoPorUsuario));
                            alert('Libro agregado al carrito');
                        } else {
                            alert('Este libro ya está en tu carrito');
                        }
                    } else {
                        alert('Libro no encontrado en la base de datos');
                    }
                } catch (error) {
                    console.error("Error al obtener el libro:", error);
                }
            }

            obtenerLibro();
        });
    }
});
