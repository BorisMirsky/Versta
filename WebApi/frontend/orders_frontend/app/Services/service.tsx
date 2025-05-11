//import ModalComponent from '../Components/ModalComponent';
//import { useState } from 'react';


export interface OrderRequest {
    cityFrom: string;
    adressFrom: string;
    cityTo: string;
    adressTo: string;
    weight: number,
    date: Date,
    specialNote?: string 
}

//name: string,
export interface UserRegistrationRequest {
    email: string;
    password: string;
    username: string;
    role: string;
}

export interface UserLoginRequest {
    email: string;
    password: string;
}

export interface FilterInterface {
    search: "";
    sortItem: "cityfrom";
    sortOrder: ""
}


export interface CurrentUser {
    id: ""; 
    username: "";
    role: "";   
    isactive: boolean;
    token: "";
    password: "";   
}



// CRUD
export const getAllOrders = async (filter: FilterInterface) => {
    const token = localStorage.getItem('token');
    const response = await fetch("http://localhost:5134/orders", {
            headers: {
                'Content-type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
            method: 'GET',
            mode: 'cors',
            params: {
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder,
            },
    })
        .then((response) => {
            if (!response.ok) {
                window.location.href = 'noauthorized';
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            return data;
        })
        .catch(err => {
            console.log('Error: ', err);
        });
    return response;

};


export const getOneOrder = async (id: string) => {
    const token = localStorage.getItem('token');
    const response = await fetch("http://localhost:5134/orders/" + id, {
        headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`,
        },
        method: 'GET'
    })
        .then((response) => {
            if (!response.ok) {
                window.location.href = 'error';
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            return data;
        })
        .catch(err => {
            console.log('Error: ', err);
        });
    return response;
};


export const createOrder = async (orderRequest: OrderRequest) => {
    console.log('orderRequest ', orderRequest)
    const token = localStorage.getItem('token');
    await fetch("http://localhost:5134/orders/", {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`,
        },
        body: JSON.stringify(orderRequest)
    }).catch(error => console.log("createOrderError: ", error));
}


export const updateOrder = async (id: string, orderRequest: OrderRequest) => {
    const token = localStorage.getItem('token');
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`,
        },
        body: JSON.stringify(orderRequest)
    });
}


export const deleteOrder = async (id: string) => {
    const token = localStorage.getItem('token');
    await fetch('http://localhost:5134/orders/' + id, {
        headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`,
        },
        method: 'DELETE'
    });
}


// privacy
export const loginUser = async (request: UserLoginRequest) => {
    //const [isOpen, setOpen] = useState(false);
    let username: string = "";
    let token: string = ""
    let role: string = "";

    await fetch("http://localhost:5134/auth/login", {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(request)
    })
        .then((response) => {
            if (!response.ok) {
                alert("Неверные логин или пароль")
                //ModalComponent(true);
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            //console.log('Data: ', data);
            username = data['userName'];
            role = data['role'];
            token = data['token'];
            localStorage.setItem('username', username);
            localStorage.setItem('role', role);
            localStorage.setItem('token', token);
            window.location.href = '/';
        })
        .catch(err => {
             console.log('Error: ', err);
        });
}       
   

export const registerUser = async (request: UserRegistrationRequest) => {
    //console.log('request: ', request);
    const token = localStorage.getItem('token');
    await fetch("http://localhost:5134/auth/register", {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    }).then(response => {
        return response.json();
    }).then(response => {
        if (response.message == "User registration unsuccessful") {
            alert("User registration unsuccessful")
        }
        else {
            alert("Регистрация прошла успешно\nТеперь надо залогиниться")
            window.location.href = 'login';
        }
    }); 
}


export const logOut = async () => {
    await fetch("http://localhost:5134/auth/logout/");    //   особого смысла нет
}

