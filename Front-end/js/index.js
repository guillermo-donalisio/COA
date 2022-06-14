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

    let colorBtn = ''
    if(type === 'edit') {
        button.href = `./user.html?id=${userId}`;    
        colorBtn = 'warning'
    } else {
        button.onclick = () => { deleteUser(userId) }
        colorBtn = 'danger'
    }
    button.type = "button";
    button.classList.add("btn", "btn-sm", `btn-outline-${colorBtn}`);
    button.text = type.replace(/^\w/, (c) => c.toUpperCase());    
    const td = document.createElement("td");
    td.appendChild(button);
    return td;
}

fetch("https://localhost:5001/get/users")
    .then((response) => {
        return response.json();
    })
    .then((user) => {
        loadTable(user)
    })
    .catch((e) => {
        console.log(e)
    })

function deleteUser(idUser){    

    Swal.fire({
        title: 'Are you sure do you want to delete this user?',
        text: "The record will be deleted from the list of users",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#198754',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Accept',
    }).then((result) => {
        if (result.isConfirmed) {
            
            const id = parseInt(idUser);
            let user = {
                "id": id
            };
        
            const options = {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(user),
            };
        
            fetch(`https://localhost:5001/delete/user/${id}`, options)
                .then(data => {
                    if (!data.ok) {
                        throw Error(data.status);
                    }
                    return data.json();
                }).then(update => {
                    window.location.replace("index.html");
                }).catch(e => {
                    console.log(e);
                });
        }
    })
    return false;
};