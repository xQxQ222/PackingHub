document.addEventListener("DOMContentLoaded", function () {
    const dataButton = document.querySelector("#dataSection .menu-button");
    const submenu = document.querySelector("#dataSection .submenu");
    const arrow = document.querySelector("#dataSection .arrow");

    // Добавляем обработчик клика для кнопки "Данные"
    dataButton.addEventListener("click", function () {
        // Переключаем класс "open" для подменю
        submenu.classList.toggle("open");

        // Переключаем поворот стрелки
        arrow.classList.toggle("rotate");
    });
});



