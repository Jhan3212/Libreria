document.querySelector("form").addEventListener("submit", function (e) {
    e.preventDefault();

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const usuarios = [
        { username: "jhan", password: "12345" },
        { username: "12345", password: "jhan" }
    ];

    const usuarioValido = usuarios.find(
        (user) => user.username === username && user.password === password
    );

    if (usuarioValido) {
        sessionStorage.setItem('usuarioActual', username);
        window.location.href = "index.html"; 
    } else {
        alert("Usuario o contraseña incorrectos");
    }
});
