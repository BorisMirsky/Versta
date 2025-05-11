'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function LoginComponent() {
    const [currentUserToken, setCurrentUserToken] = useState("");

    useEffect(() => {
        const logIn = async () => {
            const token = localStorage.getItem("token") || "";
            setCurrentUserToken(token);
        }
        logIn();
    }, []);


    return (
        <div >
            {currentUserToken ? (
                <div></div>
            ) : (
                   <h4><Link href="/login">Войти на сайт под своим логином</Link></h4>
            )}

        </div >
    );
}
