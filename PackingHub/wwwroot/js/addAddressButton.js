
// Функция для открытия модального окна
function openCreateAddressModal() {
    const modal = document.getElementById('createAddressModal');
    modal.style.display = 'flex';
    modal.classList.remove('hidden');
}

// Функция для закрытия модального окна
function closeCreateAddressModal() {
    document.getElementById('createAddressModal').style.display = 'none';
}

// Обработка отправки формы
document.getElementById('createAddressForm').addEventListener('submit', function (event) {
    event.preventDefault(); // Предотвращаем перезагрузку страницы

    const newAddress = {
        name: document.getElementById('addressName').value,
        country: document.getElementById('addressCountry').value,
        city: document.getElementById('addressCity').value,
        street: document.getElementById('addressStreet').value,
        house: document.getElementById('addressHouse').value,
        comments: document.getElementById('addressComments').value
    };

    fetch('/Address/CreateAddress', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAddress)
    })
        .then(response => {
            if (response.ok) {
                alert('Адрес успешно создан!');
                closeCreateAddressModal(); // Закрыть модальное окно
                // Обновить список адресов
                document.getElementById('btn-addresses').click();
            } else {
                alert('Ошибка при создании адреса.');
            }
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-addresses').addEventListener('click', function () {
    // Показываем карточки адресов
    fetch('/Address/GetAddressList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data;
            // Показываем кнопку "Создать адрес"
        })
        .catch(error => console.error('Error:', error));
});