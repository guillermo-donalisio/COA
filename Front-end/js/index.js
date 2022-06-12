function loadTable(users) {

    users.forEach ((user) => {
        const tr = document.createElement('tr');
        Object.keys(user).forEach((key) => {
            const td = document.createElement('td')
            td.innerHTML = user[key]
            if (key === 'id') {
                td.style.display = 'none' 
            }
            tr.appendChild(td)
        })

        let table = document.getElementById('cuerpo-tabla')
        table.append(tr);
     
        let buttons = ["edit", "delete"];
        buttons.forEach((type) => {
            table.lastChild.appendChild(createButton(type, user.id));
        })
    });
}

function createButton(type, userId) {

    const button = document.createElement('a');
    button.href = `./user.html?id=${userId}`;
    button.type = "button";
    let colorBtn = (type === 'edit') ? 'warning' : 'danger'
    button.classList.add("btn", "btn-sm", `btn-outline-${colorBtn}`);
    button.text = type.replace(/^\w/, (c) => c.toUpperCase());    
    const td = document.createElement("td");
    td.appendChild(button);
    return td;
}

async function getUsers(){
    let response = await fetch("https://localhost:5001/get/users");
    let data = await response.json();
    return data;
}

const users = getUsers()
users.then((data) => {
    loadTable(data)
})
