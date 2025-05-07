'use client'


import React from 'react';
import { useEffect, useState } from "react";


export default function CurrentUserComponent() {
    const [loading, setLoading] = useState(true);
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const getUser = async () => {
            setLoading(false);
            const result = localStorage.getItem("user") || "";
            setCurrentUser(result); 
        }
        getUser();
    }, []);

    return (
        <div >
            {loading ? (
                <div>...</div>
            ) : (
                <div>Вы вошли как <b>{currentUser}</b></div>
            )}
        </div >
    );
}