
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
    });  //.then(response => {
    //    return response.json();
    //})
    //    .then(response => {
    //        console.log('createOrder response ', response);
    //    }).catch(err => {
    //        console.log('createOrder err ', err);
    //    });
}


export const updateOrder = async (id: string, orderRequest: OrderRequest) => {
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(orderRequest)
    });
    //}).then(response => {
    //    return response.json();
    //})
    //    .then(response => {
    //        console.log('createOrder response ', response);
    //    }).catch(err => {
    //        console.log('createOrder err ', err);
    //    });
}


export const deleteOrder = async (id: string) => {
    await fetch('http://localhost:5134/orders/' + id, {
        method: 'DELETE'
    }).then(response => {
        return response.json();
    });
        //.then(response => {
        //    console.log('deleteOrder response ', response);
        //}).catch(err => {
        //    console.log('deleteOrder err ', err);
        //});
}