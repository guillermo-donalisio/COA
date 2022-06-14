
var idUser = new URLSearchParams(window.location.search).get('id');

if(idUser !== null) {
    loadUser()
}

function loadUser() {
    fetch(`https://localhost:5001/get/users/${idUser}`)
        .then((response) => {
            return response.json();
        })
        .then((user) => {
            document.getElementById('idUserName').value = user.userName
            document.getElementById('idName').value = user.name
            document.getElementById('idEmail').value = user.email
            document.getElementById('idPhone').value = user.phone
        })
        .catch((e) => {
            console.log(e)
        })
}
function validate(userName, name, email) {

    if (userName == "") {
        return false;
    }

    if (name == "" || /\d/.test(name)){
        return false;
    }  

    var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
    if (email == "" || !expr.test(email)){      
        return false;
    } 

    return true;
}

let cancelButton = document.getElementById("idCancel");
cancelButton.addEventListener("click", function(event) {
    event.preventDefault();
    Swal.fire({
        title: 'Are you sure do you want to cancel the operation?',
        text: "You will be redirected to the main page",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#198754',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Accept',
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.replace("index.html");
        }
    })
    return false;
});

let saveButton = document.getElementById("idSave");
saveButton.addEventListener("click", function(event) {
    event.preventDefault();

    let userName = document.getElementById('idUserName').value
    let name = document.getElementById('idName').value
    let email = document.getElementById('idEmail').value
    let phone = document.getElementById('idPhone').value

    if(!validate(userName, name, email, phone))
    {
        Swal.fire({
            title: 'Wrong data',
            text: "Please, set a valid information",
            icon: 'warning',
            showCancelButton: false,
            confirmButtonColor: '#198754',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Accept'
        })
        return false;
    }
    else {

        Swal.fire({
            title: 'Are you sure do you want to proceed?',
            text: "The record will be displayed in the list of users",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#198754',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Accept'
        }).then((result) => {
            if (result.isConfirmed) {
                createOrUpdateUser(idUser, userName, name, email, phone);            
            }
        })
        return false;
    }  

});

function createOrUpdateUser(id, userName, name, email, phone){
    
    let user = {
        "userName": userName,
        "name": name,
        "email": email,
        "phone": phone
    };

    let action = 'create'

    if(id !== null) {
        user.id = parseInt(id)
        action = 'update'
    }

    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    };

    fetch(`https://localhost:5001/${action}/user`, options)
        .then(data => {
            if (!data.ok) {
                throw Error(data.status);
            }
            return data.json();
        }).then(update => {
            window.location.replace("./index.html");
        }).catch(e => {
            console.log(e);
        });
};