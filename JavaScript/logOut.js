document.addEventListener('DOMContentLoaded', function () {
    const perfilItem = document.getElementById('perfil');
    const usuarioActual = sessionStorage.getItem('usuarioActual');

    if (usuarioActual) {
        perfilItem.innerHTML = `<a href="#" id="cerrarSesion">Cerrar Sesión</a>`;

        const cerrarSesionBtn = document.getElementById('cerrarSesion');
        cerrarSesionBtn.addEventListener('click', function () {
            const confirmacion = confirm('¿Estás seguro que quieres cerrar sesión?');
            if (confirmacion) {
                sessionStorage.clear(); 
                alert('Has cerrado sesión.');
                window.location.href = 'inicio.html'; 
            }
        });
    }
});
