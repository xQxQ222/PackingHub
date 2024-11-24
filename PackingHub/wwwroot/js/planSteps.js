function loadStep(action) {
    fetch(`/Load/${action}`)
        .then(response => response.text())
        .then(html => {
            document.getElementById('main-content').innerHTML = html;
        })
        .catch(error => console.error('Error:', error));
}

function submitLoad() {


    fetch(`/Load/SubmitLoad`)
        .then(response => response.text())
        .then(html => {
            document.getElementById('main-content').innerHTML = html;
        })
        .catch(error => console.error('Error:', error));
}
