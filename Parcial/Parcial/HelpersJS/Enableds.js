const teo = document.getElementById("CheckBox1")
    .addEventListener('click', function (e) {
        document.getElementById("CheckBox2").disabled = true;
    });
const lab = document.getElementById("CheckBox2")
    .addEventListener('click', function (e) {
        document.getElementById("CheckBox1").disabled = true;
    });

function habilitar() {
    teo.disabled = false;
    lab.disabled = false;
    teo.checked = false;
    lab.checked = false;
}