document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.querySelector(".busqueda input");
    const contenedorCategorias = document.getElementById("contenedor");
    const categorias = Array.from(contenedorCategorias.getElementsByClassName("informacion"));

    searchInput.addEventListener('input', function () {
        const query = searchInput.value.toLowerCase();
        categorias.forEach(categoria => {
            const texto = categoria.querySelector("p").textContent.toLowerCase();
            if (texto.includes(query)) {
                categoria.parentElement.style.display = 'block';
            } else {
                categoria.parentElement.style.display = 'none';
            }
        });
    });
});
