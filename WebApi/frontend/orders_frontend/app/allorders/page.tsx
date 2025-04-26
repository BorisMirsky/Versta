"use client"

import { Table } from "antd";
import { getAllOrders } from "@/app/Services/service";    
import { Order } from "@/app/Models/Order";    
import { useEffect, useState } from "react";
import Link from "next/link";
import "../globals.css";
import Title from "antd/es/typography/Title";
import moment from 'moment';
import Filters from '../Components/Filters';
import SelectComponent from '../Components/SelectComponent';


export default function AllOrders() {
    const [orders, setOrders] = useState<Order[]>([]);
    const [loading, setLoading] = useState(true);
    const [filter, setFilter] = useState({
        search: "",
        sortItem: "date",
        sortOrder: "desc",
    });



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
                    <a className="tableLink" >
                        {id}
                    </a>
                </Link>
            )
        },
        {
            title: 'Город отправки',
            dataIndex: 'cityfrom',
            key: 'cityfrom',
        },
        {
            title: 'Адрeс отправки',
            dataIndex: 'adressfrom',
            key: 'adressfrom',
        },
        {
            title: 'Город доставки',
            dataIndex: 'cityto',
            key: 'cityTo',
        },
        {
            title: 'Адрес доставки',
            dataIndex: 'adressto',
            key: 'adressto',
        },
        {
            title: 'Вес',
            dataIndex: 'weight',
            key: 'weight',
        },
        {
            title: 'Дата доставки',
            dataIndex: 'date',
            key: 'date',
        }
        //{
        //    title: 'Special Note',
        //    dataIndex: 'specialnote',
        //    key: 'specialnote',
        //}
    ]

    //useEffect(() => {
    //    const fetchData = async () => {
    //        let orders = await fetchOrders(filter);
    //        setOrders(orders);
    //    };
    //    fetchData();
    //})          

    useEffect(() => {
        const getOrders = async () => {
            const responce = await getAllOrders(filter);
            setLoading(false);
            setOrders(responce);
        };
        getOrders();
    }, [filter]);   

    const data = orders.map((order, index) => ({
        key: index,
        n: (index + 1),
        uniqid: order.id,
        cityfrom: order.cityFrom,
        adressfrom: order.adressFrom,
        cityto: order.cityTo,
        adressto: order.adressTo,
        weight: order.weight,
        date: moment(order.date).format("DD/MM/YYYY") 
        //specialnote: order.specialnote
    })); 


    return (
        <div><br></br><br></br><br></br><br></br>
            <h1>Все заказы</h1>
            <br></br><br></br><br></br><br></br>
            {loading ? (
                <Title>Loading ...</Title>
            ) : (
                    <div>
                        <Filters filter={filter} setFilter={setFilter} />
                        <br></br>
                        <SelectComponent filter={filter} setFilter={setFilter} />
                        <br></br><br></br><br></br><br></br>
                <Table
                    dataSource={data}
                    columns={columns}
                    pagination={false}
                    footer={() => ""}
                    bordered
                        />
                </div>
            )}
        </div >
    );
}
