// Функция для очистки контейнера с карточками
function clearContentArea() {
    const contentArea = document.getElementById('main-content');
    if (contentArea) {
        contentArea.innerHTML = '';  // Очистить содержимое
    }
}

// Скрыть все кнопки "Создать"
function hideCreateButtons() {
    document.getElementById('create-address-btn').classList.add('hidden');
    document.getElementById('create-transport-btn').classList.add('hidden');
    document.getElementById('create-cargo-btn').classList.add('hidden');
    document.getElementById('create-organization-btn').classList.add('hidden');
    document.getElementById('create-restriction-btn').classList.add('hidden');
    document.getElementById('create-container-btn').classList.add('hidden');
    document.getElementById('create-route-btn').classList.add('hidden');
}

// Обработчик для кнопки "Адреса"
document.getElementById('btn-addresses').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/Address/GetAddressList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания адреса
            document.getElementById('create-address-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

// Обработчик для кнопки "Транспорт"
document.getElementById('btn-transport').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/Transport/GetTransportList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания транспорта
            document.getElementById('create-transport-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});



document.getElementById('btn-organizations').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/Organizations/GetOrganizationsList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания транспорта
            document.getElementById('create-organization-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-restrictions').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/CargoRestriction/GetCargoRestrictionList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания транспорта
            document.getElementById('create-restriction-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-cargos').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/Cargos/GetCargoList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания транспорта
            document.getElementById('create-cargo-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-routes').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/Routes/GetRoutesList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания транспорта
            document.getElementById('create-route-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});

document.getElementById('btn-containers').addEventListener('click', function () {
    clearContentArea();  // Очистить содержимое перед загрузкой новых данных
    hideCreateButtons();  // Скрыть все кнопки создания

    fetch('/Containers/GetContainersList')
        .then(response => response.text())
        .then(data => {
            document.getElementById('main-content').innerHTML = data; // Загружаем новые карточки
            // Показываем кнопку для создания транспорта
            document.getElementById('create-container-btn').classList.remove('hidden');
        })
        .catch(error => console.error('Error:', error));
});




