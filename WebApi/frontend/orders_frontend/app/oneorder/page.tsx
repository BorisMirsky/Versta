"use client"

import React from 'react';
import { getOneOrder, deleteOrder } from "@/app/Services/service";   
import { Order } from "@/app/Models/Order";
import { useEffect, useState } from "react";   
import Card from "antd/es/card/Card";
import Button from "antd/es/button/button";
//import { router } from 'next/navigation'; // router'
import { useRouter } from 'next/navigation';


export default function OneOrder() { 
    //const [orders, setOrder] = useState<Order>([]);  
    const [order, setOrder] = useState<Order>();
    const id = "8c6af0f6-4ced-4a39-bfff-a952f8a56bf2"
    const router = useRouter()


    useEffect(() => {
        const getOrder = async () => {
            const responce = await getOneOrder(id);
            setOrder(responce);
            //console.log('OneOrder responce: ', responce);
        };
        getOrder();
    }, []);  

    const title = "Заказ id = " + order?.id;  //"Заказ id=${id}"

    const handleDelete = async (id: string) => {
        await deleteOrder(id);
        router.push("allorders");
    };

    return (
        <div >
            <br></br>
            <br></br>
            <h1>Страница одного заказа </h1>
            <br></br>
            <br></br>
            <br></br>
            <div>
                <Card
                    key={order?.id}
                    title={title}
                    variant={"outlined"}
                >
                    <p>Город отправления: <b>{order?.cityFrom}</b></p>
                    <p>Адрес забора груза: <b>{order?.adressFrom}</b></p>
                    <p>Город доставки: <b>{order?.cityTo}</b></p>
                    <p>Адрес доставки: <b>{order?.adressTo}</b></p>
                    <p>Вес груза: <b>{order?.weight}</b></p>
                    <p>Дата: <b>{order?.date}</b></p>
                    <p>Отметки: <b>{order?.specialnote}</b></p>
                    <br></br>
                    <br></br>
                    <br></br>
                    <div className="card_buttons">
                        <Button
                            //onClick={() => handleOpen(book)}
                            style={{ flex: 1 }}
                        >
                            Редактировать</Button>
                        <Button
                            onClick={() => handleDelete(id)}
                            danger
                            style={{ flex: 1 }}
                        >
                            Удалить</Button>
                    </div>
                </Card>
            </div>
        </div >
    );
}