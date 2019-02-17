const id = document.getElementById('txtid');
const name = document.getElementById('txtNombre');
const porce = document.getElementById('txtPorcentaje');
const code = document.getElementById('txtMateria');

const inputs = [id, name, porce, code];

document.getElementById("table").addEventListener('click', function (e) {
    if (e.target && e.target.nodeName === 'INPUT') {
        const tr = e.target.parentElement.parentElement;
        const children = tr.children
        code.value = children[0].textContent;
    }
})

document.getElementById('table2').addEventListener('click', function (e) {
    if (e.target && e.target.nodeName === 'INPUT') {
        const tr = e.target.parentElement.parentElement;
        const children = tr.children
        for (let i = 0; i <= children.length - 3; i++) {
            const child = children[i]
            const value = child.textContent.trim()
            inputs[i].value = value
            console.log(inputs[i])
        }
        const buton = document.getElementById("btnModificar");
        buton.style.visibility = "visible";
    }
})