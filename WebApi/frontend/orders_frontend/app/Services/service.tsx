//import { Interface } from "readline/promises";
//import axios from "axios";
//import { useRouter } from 'next/navigation';



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
    username: string;
    password: string;
}

export interface UserLoginRequest {
    username: string;
    password: string;
}

export interface FilterInterface {
    search: "";
    sortItem: "cityfrom";
    sortOrder: ""
}

export const getAllOrders = async (filter: FilterInterface) => {
    try {
        const response = await fetch("http://localhost:5134/orders", {
            mode: 'cors',
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


export const registerUser = async (request: UserRegistrationRequest) => {
    console.log('(request ', (request));
    await fetch("http://localhost:5134/auth/register", {
        method: 'POST',
        redirect: "manual",
        headers: {
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        },
        body: JSON.stringify(request)
    }).then(response => {
        console.log('response ', response);
        return response.json();
    }).then(response => {
        if (response.message == "User registration unsuccessful") {
            alert("User registration unsuccessful")
        }
        else {
            window.location.href = 'allorders';
        }
    });
}





export const loginUser = async (request: UserLoginRequest) => {
    await fetch("http://localhost:5134/auth/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        },
        body: JSON.stringify(request)
    }).then(response => {
        console.log(response);
        return response.json();
    }).then(response => {
        if (response.message == "User login unsuccessful") {
            alert("User login unsuccessful")
        }
        else {
            window.location.href = 'allorders';
        }
    });
}



export const registrationUser = async (userRegistrationRequest: UserRegistrationRequest) => {
    console.log(userRegistrationRequest);
    //await fetch("http://localhost:5134/auth/register/", {
    //    method: 'POST',
    //    headers: {
    //        'Content-Type': 'application/json',
    //        'Cache-Control': 'no-cache',
    //    },
    //    body: JSON.stringify(userRegistrationRequest)
    //});
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