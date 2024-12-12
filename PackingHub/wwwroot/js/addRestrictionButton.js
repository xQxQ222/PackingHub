
// Функция для открытия модального окна
function openCreateRestrictionModal() {
    document.getElementById('createRestrictionModal').style.display = 'flex';
}

// Функция для закрытия модального окна
function closeCreateRestrictionModal() {
    document.getElementById('createRestrictionModal').style.display = 'none';
}

// Обработка отправки формы
document.getElementById('create-restriction-form').addEventListener('submit', function (event) {
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

    fetch('/CargoRestriction/CreateCargoRestriction', {
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
                document.getElementById('btn-restrictions').click();
            } else {
                alert('Ошибка при добавлении ограничения.');
            }
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-restrictions').addEventListener('click', function () {
    fetch('/CargoRestriction/GetCargoRestrictionList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data;
            document.getElementById('create-restriction-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

document.querySelectorAll('.menu-button').forEach(button => {
    button.addEventListener('click', function () {
        // Скрываем кнопку "Создать адрес"
        document.getElementById('create-restriction-btn').classList.add('hidden');
    });
});