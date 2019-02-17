const code = document.getElementById('txtCodigo');
const name = document.getElementById('txtNombre');
const cicle = document.getElementById('txtCiclo');
const teoric = document.getElementById('rdbTeorico');
const laboratory = document.getElementById('rdbLaboratorio');
const uv = document.getElementById('txtUV');
const prerequisite = document.getElementById('txtPrerequisito');
const description = document.getElementById('txtDescripcion');

const inputs = [code, name, cicle, prerequisite, description, uv]

//Delegacion de eventos
document.getElementById('table').addEventListener('click', function (e) {
    if (e.target && e.target.nodeName === 'INPUT') {
        const tr = e.target.parentElement.parentElement;
        const children = tr.children
        for (let i = 0; i <= children.length - 4; i++) {
            const child = children[i]
            const value = child.textContent.trim()
            inputs[i].value = value           
        }
        const id = document.getElementById('btnAgregar');
        id.className = "btn btn-success";
        id.value = "Agregar";
    }
})