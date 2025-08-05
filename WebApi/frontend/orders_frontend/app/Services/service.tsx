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
    search: string;
    sortItem: string;
    sortOrder: string; 
}


export interface CurrentUser {
    id: string; 
    username: string; 
    role: string;    
    isactive: boolean;
    token: string; 
    password: string;
}




// CRUD
export const getAllOrders = async (filter: FilterInterface) => {
    const token = localStorage.getItem('token');

    const response = await fetch("http://localhost:5134/orders", {
            headers: {
                "Content-type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Headers": "Content-Type, Authorization" ,
                "Access-Control-Allow-Credentials": 'true',
                "Access-Control-Allow-Methods": 'GET',
                'Authorization': `Bearer ${token}`,
            },
            method: 'GET',
            mode: 'cors',
            //params: {
            //    search: filter?.search, 
            //    sortItem: filter?.sortItem, 
            //    sortOrder: filter?.sortOrder
            //}
    })
        .then(response => {
            if (!response.ok) {
                console.log('token ', token   );
                console.log('filter ', filter); 
                window.location.href = 'noauthorized';
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            console.log('data: ', data);
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
            'Authorization': `Bearer ${token}`
        },
        method: 'GET',
        mode: 'cors'
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
    const token = localStorage.getItem('token');
    await fetch("http://localhost:5134/orders", {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        mode: 'cors',
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
        mode: 'cors',
        body: JSON.stringify(orderRequest)
    });
}



export const deleteOrder = async (id: string) => {
    const token = localStorage.getItem('token');
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'DELETE',
        headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`,
        },
        mode: 'cors'
    });
    window.location.href = 'allorders'; 
}



export const loginUser = async (request: UserLoginRequest) => {
    let username: string = "";
    let token: string = ""
    let role: string = "";

    await fetch("http://localhost:5134/accounts/login", {
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
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            username = data['userName'];
            role = data['rolename'];
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
    const token = localStorage.getItem('token');
    await fetch("http://localhost:5134/accounts/register", {
        method: 'POST',
        mode: 'cors',
        //credentials: true,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    }).then(response => {
        if (!response.ok) {
            alert("Ошибка регистрации");
            console.log("Ошибка регистрации");
        }
        else {
            alert("Регистрация прошла успешно")
            window.location.href = 'login';
        }
    }).catch(err => {
        console.log('registerError: ', err);
    }); 
}


export const logOut = async () => {
    await fetch("http://localhost:5134/accounts/logout/");    
}
