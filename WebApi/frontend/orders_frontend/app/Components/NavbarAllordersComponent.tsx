'use client'


import React from 'react';
import { useEffect, useState } from "react";
import Link from "next/link";

export default function NavbarAllordersComponent() {
    const [currentUserRole, setCurrentUserRole] = useState("");

    useEffect(() => {
        const navbarAllorders = async () => {
            const role = localStorage.getItem("role") || "";
            setCurrentUserRole(role);
        }
        navbarAllorders();
    }, []);


    return (
        <div >
            {(currentUserRole != "admin" && currentUserRole != "") ? (
                <Link href="/allorders">All Orders</Link>
            ) : (
                <div></div>
            )}

        </div >
    );
}
