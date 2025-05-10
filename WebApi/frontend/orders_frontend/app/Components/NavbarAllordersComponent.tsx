'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function NavbarAllordersComponent() {
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const navbarAllorders = async () => {
            const result = localStorage.getItem("username") || "";
            setCurrentUser(result);
        }
        navbarAllorders();
    }, []);


    return (
        <div >
            {currentUser ? (
                <Link href="/allorders">All Orders</Link>
            ) : (
                <div></div>
            )}

        </div >
    );
}
