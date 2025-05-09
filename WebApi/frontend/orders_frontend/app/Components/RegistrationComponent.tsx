'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function RegistrationComponent() {
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const Register = async () => {
            const result = localStorage.getItem("user") || "";
            setCurrentUser(result);
        }
        Register();
    }, []);


    return (
        <div >
            {currentUser ? (
                <div></div>
            ) : (
                    <h4><Link href="/registration">Регистрация</Link></h4>
            )}

        </div >
    );
}
