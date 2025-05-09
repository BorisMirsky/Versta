'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function LoginComponent() {
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const logIn = async () => {
            const result = localStorage.getItem("user") || "";
            setCurrentUser(result);
        }
        logIn();
    }, []);


    return (
        <div >
            {currentUser ? (
                <div></div>
            ) : (
                   <h4><Link href="/login">Войти на сайт под своим логином</Link></h4>
            )}

        </div >
    );
}
