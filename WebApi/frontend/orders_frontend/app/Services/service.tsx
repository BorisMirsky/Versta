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


//name: = "";
export interface CurrentUser {
    id: ""; 
    username: "";
    role: "";   //Everyone
    isactive: boolean;
    token: "";
    password: "";   
}


export const getAllOrders = async (filter: FilterInterface) => {
    const token = localStorage.getItem('token');
    try {
        const response = await fetch("http://localhost:5134/orders", {
            headers: {
                'Content-type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
            mode: 'cors',
            params: {
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder,
            },
        });
        return response.json();     
    } catch (e) {
        console.error(e);
    }
};


export const getOneOrder = async (id: string) => {
    const response = await fetch("http://localhost:5134/orders/" + id, {
        method: 'GET',
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
    //console.log('(request ', (request));
    await fetch("http://localhost:5134/auth/register", {
        method: 'POST',
        'mode': 'cors',
        'credentials': 'include',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    }).then(response => {
        console.log('response1 ', response);
        return response.json();
    }).then(response => {
        if (response.message == "User registration unsuccessful") {
            alert("User registration unsuccessful")
        }
        else {
            //console.log('response2 ', response);
            window.location.href = 'allorders';
        }
    });
}




export const loginUser = async (request: UserLoginRequest) => {
    let user: string = "";
    let token: string = "";
    await fetch("http://localhost:5134/auth/login", {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    })
        .then(response => response.json())
        .then(data => {
            user = data['userName'];
            token = data['token'];
            localStorage.setItem('user', user);
            localStorage.setItem('token', token);
            window.location.href = 'allorders';
        });
        //.then(response => {
        //    if (response.message == "User login unsuccessful") {
        //        alert("User login unsuccessful")
        //    }
        //    else {
        //        console.log("");
        //        //window.location.href = 'allorders';
        //    }
        //}).catch(err => {
        //            console.log('Error: ', err);
        //});
}       



//export const loginUser = async (request: UserLoginRequest) => {
//    let user: string = "";
//    let token: string = "";
//    const response = await fetch("http://localhost:5134/auth/login", {
//        method: 'POST',
//        mode: 'cors',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(request)
//    })
//        //.then(response => response.json())
//        //.then(data => {
//        //    user = data['userName'];
//        //    token = data['token'];
//        //    localStorage.setItem('user', user);
//        //    localStorage.setItem('token', token);
//        //    window.location.href = 'allorders';
//    //});
//    try {
//        if (response.ok) {
//            console.log("");
//            data => {
//                user = data['userName'];
//                token = data['token'];
//                localStorage.setItem('user', user);
//                localStorage.setItem('token', token);
//                window.location.href = 'allorders';
//            }
//        }
//    }
//    catch (e: Error) {
//        if (e.message == "User login unsuccessful") {
//            alert("User login unsuccessful")
//        }
//    }
//    //}).catch(err => {
//    //            console.log('Error: ', err);
//    //});
//}    



//    }).then(response => {
//        if (response.message == "User login unsuccessful") {
//            alert("User login unsuccessful")
//        }
//        else {
//            console.log("");
//            //window.location.href = 'allorders';
//        }
//    }).catch(err => {
//                console.log('Error: ', err);
//    });
//}

    //}).then(response => response.json())
    //.then(data => {
    //    user = data['userName'];
    //    //console.log('user ', user);
    //    localStorage.setItem('user ', user);
    //})




export const logout = async () => {
    console.log("logout");
    await fetch("http://localhost:5134/auth/logout/");
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