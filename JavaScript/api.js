fetch('https://localhost:7061/api/Libros/all')
    .then(response => {
        if (!response.ok) {
            throw new Error('Error en la solicitud');
        }
        return response.json(); 
    })
    .then(data => {
        console.log(data); 
    })
    .catch(error => {
        console.error('Hubo un problema:', error);
    });
