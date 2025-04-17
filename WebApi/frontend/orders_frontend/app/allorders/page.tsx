"use client"

import { Table } from "antd";
import { getAllOrders } from "@/app/Services/service";    //getOneOrder
import { Order } from "@/app/Models/Order";    
import { useEffect, useState } from "react";
import { useRouter } from 'next/navigation'; // router'
import Link from "next/link";
import "../globals.css";



export default function AllOrders() {
    const [orders, setOrders] = useState<Order[]>([]);
    const router = useRouter();
    const handleClick = async (id1: string) => {   //id: string
        console.log("000");
        router.query = id1
        //router.push("/oneorder");
        //await getOneOrder(id);
    };

    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Uniq Id',
            dataIndex: 'uniqid',
            key: 'uniqid',
            render: (id: string) => (
                <Link
                    href={{
                        pathname: "oneorder",
                        query: {
                            id: id
                        }
                    }}        
                    legacyBehavior={true}
                >
                    <a
                        className="tableLink"
                        onClick={() => handleClick(id)}
                    >
                        {id}
                    </a>
                </Link>
            )
        },
        {
            title: 'City From',
            dataIndex: 'cityfrom',
            key: 'cityfrom',
        },
        {
            title: 'Adress From',
            dataIndex: 'adressfrom',
            key: 'adressfrom',
        },
        {
            title: 'City To',
            dataIndex: 'cityto',
            key: 'cityTo',
        },
        {
            title: 'Adress To',
            dataIndex: 'adressto',
            key: 'adressto',
        },
        {
            title: 'Weight',
            dataIndex: 'weight',
            key: 'weight',
        },
        {
            title: 'Date',
            dataIndex: 'date',
            key: 'date',
        }
    ]

    useEffect(() => {
        const getOrders = async () => {
            const responce = await getAllOrders();
            setOrders(responce);
        };
        getOrders();
    }, []);   

    const data = orders.map((order, index) => ({
        key: index,
        n: (index+1),
        uniqid: order.id,
        cityfrom: order.cityFrom,
        adressfrom: order.adressFrom,
        cityto: order.cityTo,
        adressto: order.adressTo,
        weight: order.weight,
        date: order.date
    })) 


    return (
        <div >
            <h1>Все заказы</h1>
            <Table
                dataSource={data}
                columns={columns}
                pagination={false}
                footer={() => ""}
                bordered
            />
        </div >
    );
}
