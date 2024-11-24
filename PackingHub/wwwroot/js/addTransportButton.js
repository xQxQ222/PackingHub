
// Функция для открытия модального окна
function openCreateTransportModal() {
    document.getElementById('createTransportModal').style.display = 'flex';
}

// Функция для закрытия модального окна
function closeCreateTransportModal() {
    document.getElementById('createTransportModal').style.display = 'none';
}

// Обработка отправки формы
document.getElementById('create-transport-form').addEventListener('submit', function (event) {
    event.preventDefault(); // Предотвращаем перезагрузку страницы

    const newAddress = {
        vinNumber: document.getElementById('vinNumber').value,
        VehicleType: document.getElementById('vehicleType').value,
        brand: document.getElementById('brand').value,
        model: document.getElementById('model').value,
        loadCapacity: document.getElementById('loadCapacity').value,
        bodyVolume: document.getElementById('bodyVolume').value,
        comments: document.getElementById('comments').value
    };

    fetch('/Transport/CreateTransport', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAddress)
    })
        .then(response => {
            if (response.ok) {
                alert('Транспорт успешно создан!');
                closeCreateTransportModal(); // Закрыть модальное окно
                // Обновить список адресов
                document.getElementById('btn-transport').click();
            } else {
                alert('Ошибка при создании транспорта.');
            }
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-transport').addEventListener('click', function () {
    // Показываем карточки адресов
    fetch('/Transport/GetTransportList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data;
            document.getElementById('create-transport-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

// Если нужно, скрываем кнопку "Создать адрес" при клике на другие кнопки
document.querySelectorAll('.menu-button').forEach(button => {
    button.addEventListener('click', function () {
        // Скрываем кнопку "Создать адрес"
        document.getElementById('create-transport-btn').classList.add('hidden');
    });
});