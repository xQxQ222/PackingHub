document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById("loginForm");

    if (form) {
        form.addEventListener("submit", async function (event) {
            event.preventDefault();  // предотвращаем стандартное поведение формы

            const formData = new FormData(form);  // собираем данные формы

            try {
                const response = await fetch('/Index', {
                    method: 'POST',
                    body: formData,
                });

                // Проверка ответа от сервера
                const result = await response.json();
                if (response.ok && result.success) {
                    window.location.href = '/Dashboard';
                } else {
                    // Показываем сообщение об ошибке
                    document.getElementById("errorMessage").style.display = "block";
                }
            } catch (error) {
                console.error("Ошибка запроса:", error);
                document.getElementById("errorMessage").style.display = "block";  // Показываем ошибку при проблемах с запросом
            }
        });
    }
});
