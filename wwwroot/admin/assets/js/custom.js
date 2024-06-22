$(document).ready(function () {
    $('#upload').on('change', function (event) {
        readURL(event.target);
        showFileName(event.target);
    });
});

function readURL(input) {
    if (input.files) {
        console.log(input.files);
        $('#imageResult').empty(); // Clear previous images
        [...input.files].forEach(file => {
            let reader = new FileReader();
            reader.onload = function (e) {
                let imgElement = $('<img>', {
                    src: e.target.result,
                    class: 'img-fluid rounded shadow-sm mx-auto d-block mb-2'
                });
                $('#imageResult').append(imgElement);
            };
            reader.readAsDataURL(file);
        });
    }
}

function showFileName(input) {
    var infoArea = document.getElementById('upload-label');
    var fileNames = Array.from(input.files).map(file => file.name);
    infoArea.textContent = 'File names: ' + fileNames.join(', ');
}
