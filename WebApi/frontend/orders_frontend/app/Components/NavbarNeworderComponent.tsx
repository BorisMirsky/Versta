'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";



export default function NavbarNeworderComponent() {
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const navbarNeworder = async () => {
            const result = localStorage.getItem("username") || "";
            setCurrentUser(result);
        }
        navbarNeworder();
    }, []);


    return (
        <div >
            {currentUser ? (
                <Link href="/neworder">New order</Link>
            ) : (
                <div></div>
            )}

        </div >
    );
}
