
// Функция для открытия модального окна
function openCreateContainerModal() {
    document.getElementById('createContainerModal').style.display = 'flex';
}

// Функция для закрытия модального окна
function closeCreateContainerModal() {
    document.getElementById('createContainerModal').style.display = 'none';
}

// Обработка отправки формы
document.getElementById('create-container-form').addEventListener('submit', function (event) {
    event.preventDefault(); // Предотвращаем перезагрузку страницы

    const newAddress = {
        name: document.getElementById('name').value,
        length: document.getElementById('length').value,
        width: document.getElementById('width').value,
        height: document.getElementById('width').value,
        weight: document.getElementById('weight').value,
        wallThickness: document.getElementById('wallThickness').value,
        status: document.getElementById('status').value
    };

    fetch('/Containers/CreateContainer', {
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
                document.getElementById('btn-containers').click();
            } else {
                alert('Ошибка при добавлении груза.');
            }
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-containers').addEventListener('click', function () {
    // Показываем карточки адресов
    fetch('/Containers/GetContainersList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data;
            document.getElementById('create-container-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

// Если нужно, скрываем кнопку "Создать адрес" при клике на другие кнопки
document.querySelectorAll('.menu-button').forEach(button => {
    button.addEventListener('click', function () {
        // Скрываем кнопку "Создать адрес"
        document.getElementById('create-container-btn').classList.add('hidden');
    });
});