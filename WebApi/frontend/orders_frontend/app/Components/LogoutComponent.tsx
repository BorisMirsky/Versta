'use client'


import React from 'react';
import { useEffect } from "react";  //, useState


export default function LogoutComponent() {
    //const [loading, setLoading] = useState(true);
    //const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const logoutUser = async () => {
            //setLoading(false);
            //localStorage.setItem("user") = "";
            //const result = localStorage.getItem("user") || "";
            //setCurrentUser(result);
            console.log('from logout')
        }
        logoutUser();
    }, []);

    return (
        <div >
                   LogOut
        </div >
    );
}




//import { cookies } from 'next/headers'
//import { deleteSession } from '@/app/lib/session'

//export async function logout() {
//    await deleteSession()
//    redirect('/login')
//}