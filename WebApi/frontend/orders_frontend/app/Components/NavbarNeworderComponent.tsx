'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";



export default function NavbarNeworderComponent() {
    const [currentUserRole, setCurrentUserRole] = useState("");

    useEffect(() => {
        const navbarNeworder = async () => {
            const role = localStorage.getItem("role") || "";
            setCurrentUserRole(role);
        }
        navbarNeworder();
    }, []);


    return (
        <div >
            {(currentUserRole != "admin" && currentUserRole != "visitor" && currentUserRole != "") ? (
                <Link href="/neworder">New order</Link>
            ) : (
                <div></div>
            )}

        </div >
    );
}
