//import { Interface } from "readline/promises";
//import axios from "axios";


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
    login: string;
    password: string;
}

export interface UserLoginRequest {
    login: string;
    password: string;
}


export interface FilterInterface {
    search: "";
    sortItem: "cityfrom";
    sortOrder: ""
}

//export const getAllOrders = async () => {
//    const response = await fetch("http://localhost:5134/orders");
//    return response.json();
//};


export const getAllOrders = async (filter: FilterInterface) => {
    try {
        const response = await fetch("http://localhost:5134/orders", {
            params: {
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder,
            },
        });
        //console.log('response: ', response);
        return response.json();     
    } catch (e) {
        console.error(e);
    }
};


export const getOneOrder = async (id: string) => {
    const response = await fetch("http://localhost:5134/orders/" + id, {
        method: 'GET'
    });
    //console.log('getOneOrder');
    return response.json();
};


export const createOrder = async (orderRequest: OrderRequest) => {
    await fetch("http://localhost:5134/orders/", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        },
        body: JSON.stringify(orderRequest)
    });  
}


export const registrationUser = async (userRegistrationRequest: UserRegistrationRequest) => {
    console.log('userRegistrationRequest: ', userRegistrationRequest)
}


export const loginUser = async (userLoginRequest: UserLoginRequest) => {
    console.log('userLoginRequest: ', userLoginRequest)
}


export const updateOrder = async (id: string, orderRequest: OrderRequest) => {
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(orderRequest)
    });
}


export const deleteOrder = async (id: string) => {
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'DELETE'
    });
}



//}).then(response => {
//    return response.json();
//})
//    .then(response => {
//        console.log('createOrder response ', response);
//    }).catch(err => {
//        console.log('createOrder err ', err);
//    });