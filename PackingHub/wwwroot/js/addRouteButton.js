
// Функция для открытия модального окна
function openCreateRouteModal() {
    document.getElementById('createRouteModal').style.display = 'flex';
}

// Функция для закрытия модального окна
function closeCreateRouteModal() {
    document.getElementById('createRouteModal').style.display = 'none';
}

// Обработка отправки формы
document.getElementById('create-route-form').addEventListener('submit', function (event) {
    event.preventDefault(); // Предотвращаем перезагрузку страницы

    const newAddress = {
        name: document.getElementById('name').value,
        length: document.getElementById('length').value,
        width: document.getElementById('width').value,
        height: document.getElementById('height').value,
        weight: document.getElementById('weight').value,
        wallThickness: document.getElementById('wallThickness').value,
        status: document.getElementById('status').value
    };

    fetch('/Routes/CreateRoute', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAddress)
    })
        .then(response => {
            if (response.ok) {
                alert('Контейнер успешно добавлен!');
                closeCreateCargoModal(); // Закрыть модальное окно
                // Обновить список адресов
                document.getElementById('btn-organizations').click();
            } else {
                alert('Ошибка при добавлении маршрута.');
            }
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-routes').addEventListener('click', function () {
    fetch('/Routes/GetRoutesList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data;
            document.getElementById('create-route-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

document.querySelectorAll('.menu-button').forEach(button => {
    button.addEventListener('click', function () {
        document.getElementById('create-route-btn').classList.add('hidden');
    });
});