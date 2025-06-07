'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function LoginComponent() {
    const [currentRole, setCurrentRole] = useState("");


    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
    }, []);


    return (
        <div >
            {currentRole ? (
                <div></div>
            ) : (
                   <h4><Link href="/login">Войти на сайт под своим логином</Link></h4>
            )}

        </div >
    );
}
