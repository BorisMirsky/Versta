'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function RegistrationComponent() {
    const [currentRole, setCurrentRole] = useState("");

    useEffect(() => {
        const Register = async () => {
            const role = localStorage.getItem("role") || "";
            setCurrentRole(role);
        }
        Register();
    }, []);


    return (
        <div >
            {
                (currentRole === 'admin') ? (
                    <h4><Link href="/registration">Регистрация</Link></h4>
                ) : (
                    <div></div>
                )
            }

        </div >
    );
}


