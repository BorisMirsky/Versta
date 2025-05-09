"use client"

import React from 'react';
import { getOneOrder, deleteOrder } from "@/app/Services/service";   
import { Order } from "@/app/Models/Order";
import { useEffect, useState } from "react";   
import Card from "antd/es/card/Card";
import Button from "antd/es/button/button";
import { useRouter } from 'next/navigation';
//import Router from 'next/router'
import { useSearchParams } from 'next/navigation';
import Title from "antd/es/typography/Title";
import moment from 'moment';


export default function OneOrder() { 
    const [order, setOrder] = useState<Order>();
    const router = useRouter();
    const [loading, setLoading] = useState(true);
    const searchParams = useSearchParams();
    const params = new URLSearchParams(searchParams);
    const id = params.toString().split("=")[1];

    useEffect(() => {
        const getOrder = async () => {
            const responce = await getOneOrder(id);
            setLoading(false);
            setOrder(responce);
        };
        getOrder();
    });     

    const title = "Заказ id = " + order?.id;  

    const handleDelete = async (id: string) => {
        await deleteOrder(id);
        router.push("/");        //allorders
    };

    const handleUpdate = async () => {
        router.push("/updateorder?id=" + id);
    };


    return (
        <div>
            <br></br>
            <br></br>
            <h1>Страница одного заказа </h1>
            <br></br>
            <br></br>
            <br></br>
            <div>
                {loading ? (
                    <Title>Loading ...</Title>
                ) : (
                            <Card
                        key={order?.id}
                        title={title}
                        variant={"outlined"}
                        className="custom-card"
                    >
                        <p>Город отправления: <b>{order?.cityFrom}</b></p>
                        <p>Адрес забора груза: <b>{order?.adressFrom}</b></p>
                        <p>Город доставки: <b>{order?.cityTo}</b></p>
                        <p>Адрес доставки: <b>{order?.adressTo}</b></p>
                        <p>Вес груза: <b>{order?.weight}</b></p>
                            <p>Дата: <b>{moment(order?.date).format("DD/MM/YYYY")}</b></p>
                        <p>Отметки: <b>{order?.specialNote}</b></p>
                        <br></br>
                        <br></br>
                        <br></br>
                        <div className="card_buttons">
                            <Button
                                onClick={() => handleUpdate()}
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
                )}
            </div>
        </div >
    );
}