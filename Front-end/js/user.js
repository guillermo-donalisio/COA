function insertUser(userName, name, email, phone){
    userName = document.getElementById('idUserName');
    name = document.getElementById('IdName');
    email = document.getElementById('idEmail');
    phone = document.getElementById('idPhone');

    let user = {
        UserName : userName,
        Name : name,
        Email : email,
        Phone : phone
    };

}

async function createUsers(){
    let response = await fetch("https://localhost:5001/create/user");
    let data = await response.json();
    return data;
}

const users = createUsers()
users.then((data) => {
    insertUser(userName, name, email, phone)
})