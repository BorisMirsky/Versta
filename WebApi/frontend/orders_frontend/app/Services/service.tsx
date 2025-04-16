//import { useRouter } from 'next/navigation'; // 'next/router';

export interface OrderRequest {
    cityFrom: string;
    adressFrom: string;
    cityTo: string;
    adressTo: string;
    weight: number,
    date: Date,
    specialNote?: string
}

export const getAllOrders = async () => {
    const response = await fetch("http://localhost:5134/orders");
    return response.json();
};


export const getOneOrder = async (id: string) => {
    const response = await fetch("http://localhost:5134/orders/" + id);   
    //console.log('service getOneOrder id', response.json());
    return response.json();
};


export const createOrder = async (orderRequest: OrderRequest) => {
    //console.log('createOrder from service ', orderRequest); 
    await fetch("http://localhost:5134/orders/", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(orderRequest)
    });
}


//export const updateOrder = async (id: string, orderRequest: OrderRequest) => {
//    await fetch('h ttp://localhost:5134/orders/' + id, {
//        method: 'PUT',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(orderRequest)
//    });
//}


export const deleteOrder = async (id: string) => {
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'DELETE'
    });
}