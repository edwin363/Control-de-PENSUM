const code = document.getElementById("txtMateria");
document.getElementById("table").addEventListener('click', function (e) {
    if (e.target && e.target.nodeName === 'INPUT') {
        const tr = e.target.parentElement.parentElement;
        const children = tr.children
        code.value = children[0].textContent;
        /*for (let i = 0; i <= children.length - 2; i++) {
            const child = children[i]
            const value = child.textContent.trim()
            code.value = value
            console.log(children)
        }*/
    }
})