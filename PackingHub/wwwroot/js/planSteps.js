function loadStep(action) {
    var check = true;
    if (action === "GetContainers") {
        const checkboxes = document.querySelectorAll(
            'input[type="checkbox"]',
        );
        check = atLeastOneCheckboxChecked(checkboxes)
        if (!check) {
            alert("Выберите хотя бы один груз!")
        }
    }
    if (action === "GetRoutes") {
        const radios = document.querySelectorAll(
            'input[type="radio"]',
        );
        check = atLeastOneRadioButtonChecked(radios);
        if (!check) {
            alert("Выберите один контейнер!")
        }
    }
    if (check) {
        fetch(`/Load/${action}`)
            .then(response => response.text())
            .then(html => {
                document.getElementById('main-content').innerHTML = html;
            })
            .catch(error => console.error('Error:', error));
    }
}

function atLeastOneCheckboxChecked(checkboxes) {
    return Array.from(checkboxes).some(
        checkbox => checkbox.checked,
    );
}

function atLeastOneRadioButtonChecked(radiobutt) {
    return Array.from(radiobutt).some(
        radiobutt => radiobutt.checked
    );
}

function submitLoad() {
    const radios = document.querySelectorAll(
        'input[type="radio"]',
    );
    check = atLeastOneRadioButtonChecked(radios);
    if (!check) {
        alert("Выберите один маршрут!")
    }
    else {

        fetch(`/Load/SubmitLoad`)
            .then(response => response.text())
            .then(html => {
                document.getElementById('main-content').innerHTML = html;
            })
            .catch(error => console.error('Error:', error));
    }
}
