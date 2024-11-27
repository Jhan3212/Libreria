document.addEventListener('DOMContentLoaded', function () {
    const usuarioActual = sessionStorage.getItem('usuarioActual');

    if (!usuarioActual) {
        alert('No se ha iniciado sesión. Por favor, inicia sesión primero.');
        window.location.href = 'inicio.html';
        return;
    }

    let carritoPorUsuario = JSON.parse(localStorage.getItem('carritoPorUsuario')) || {};
    let carrito = carritoPorUsuario[usuarioActual] || [];

    const contenedorCarrito = document.getElementById('contenedor-carrito');
    const totalElemento = document.getElementById('total'); 
    const searchInput = document.querySelector(".busqueda input");

    function mostrarCarrito(librosACargar) {
        contenedorCarrito.innerHTML = ''; 
        let total = 0; 

        if (librosACargar.length === 0) {
            contenedorCarrito.innerHTML = '<p>No tienes libros en el carrito aún.</p>';
        } else {
            librosACargar.forEach(libro => {
                const precio = isNaN(libro.precio) ? 0 : libro.precio;

                const libroElemento = document.createElement('div');
                libroElemento.classList.add('libro');

                libroElemento.innerHTML = `
                    <a href="detallelibro.html?id=${libro.id}">
                        <img src="${libro.portada}" alt="Portada de ${libro.titulo}" />
                    </a>
                    <h3>${libro.titulo}</h3>
                    <p>Precio: $${precio.toFixed(2)}</p> <!-- Mostrar precio -->
                    <button class="eliminar" data-id="${libro.id}">Eliminar del carrito</button>
                `;

                contenedorCarrito.appendChild(libroElemento);
                total += precio;
            });
            totalElemento.innerHTML = `Total: $${total.toFixed(2)}`;
        }
    }

    mostrarCarrito(carrito);

    searchInput.addEventListener('input', function () {
        const query = searchInput.value.toLowerCase();

        const carritoFiltrado = carrito.filter(libro =>
            (libro.titulo && libro.titulo.toLowerCase().includes(query)) ||
            (libro.autor && libro.autor.toLowerCase().includes(query))
        );

        mostrarCarrito(carritoFiltrado);
    });

    contenedorCarrito.addEventListener('click', function (event) {
       
        if (event.target && event.target.classList.contains('eliminar')) {
            const libroId = event.target.getAttribute('data-id'); 

            carrito = carrito.filter(libro => libro.id !== libroId);

            carritoPorUsuario[usuarioActual] = carrito;
            localStorage.setItem('carritoPorUsuario', JSON.stringify(carritoPorUsuario));

            event.target.parentElement.remove();

            let total = carrito.reduce((acc, libro) => acc + (isNaN(libro.precio) ? 0 : libro.precio), 0);
            totalElemento.innerHTML = `Total: $${total.toFixed(2)}`;
        }
    });
});
