
// Функция для открытия модального окна
function openCreateCargoModal() {
    document.getElementById('createCargoModal').style.display = 'flex';
}

// Функция для закрытия модального окна
function closeCreateCargoModal() {
    document.getElementById('createCargoModal').style.display = 'none';
}

// Обработка отправки формы
document.getElementById('create-cargo-form').addEventListener('submit', function (event) {
    event.preventDefault(); // Предотвращаем перезагрузку страницы

    const newAddress = {
        name: document.getElementById('name').value,
        length: document.getElementById('length').value,
        width: document.getElementById('width').value,
        height: document.getElementById('height').value,
        weight: document.getElementById('weight').value,
        supplier: document.getElementById('supplier').value,
        customer: document.getElementById('customer').value,
        deliveryAddress: document.getElementById('deliveryAddress').value,
        fragility: document.getElementById('fragility').checked,
        flammable: document.getElementById('flammable').checked,
        chemicallyActive: document.getElementById('chemicallyActive').checked,
        status: document.getElementById('status').value,
        addEq: document.getElementById('addEq').checked
    };

    fetch('/Cargos/CreateCargo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAddress)
    })
        .then(response => {
            if (response.ok) {
                alert('Груз успешно добавлен!');
                closeCreateCargoModal(); // Закрыть модальное окно
                // Обновить список адресов
                document.getElementById('btn-cargos').click();
            } else {
                alert('Ошибка при добавлении груза.');
            }
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-cargos').addEventListener('click', function () {
    // Показываем карточки адресов
    fetch('/Cargos/GetCargoList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data;
            document.getElementById('create-cargo-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

// Если нужно, скрываем кнопку "Создать адрес" при клике на другие кнопки
document.querySelectorAll('.menu-button').forEach(button => {
    button.addEventListener('click', function () {
        // Скрываем кнопку "Создать адрес"
        document.getElementById('create-cargo-btn').classList.add('hidden');
    });
});