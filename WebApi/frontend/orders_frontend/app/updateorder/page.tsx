"use client"

import React from 'react';
import { updateOrder, OrderRequest, getOneOrder } from "@/app/Services/service";
import { Order } from "@/app/Models/Order";
import { FormProps, Button, Form, Input, InputNumber, DatePicker, Space } from 'antd';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from "react";  
import { useSearchParams } from 'next/navigation';
import Title from "antd/es/typography/Title";
import moment from 'moment';



export default function UpdateOrder() {   
    const [order, setOrder] = useState<Order>();
    const router = useRouter();
    const searchParams = useSearchParams();
    const params = new URLSearchParams(searchParams);
    const id = params.toString().split("=")[1];
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        const getOrder = async () => {
            const responce = await getOneOrder(id);
            setLoading(false);
            setOrder(responce);
        };
        getOrder();
    });  

    const onFinishFailed: FormProps<OrderRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    }

    const onFinish: FormProps<OrderRequest>['onFinish'] = (values) => {
        updateOrder(id, values);
        router.push("/oneorder?id=" + id);        
    }


    return (
        <div >
            <h1>Редактирование заказа </h1>
            <br></br>
            <br></br>
            <br></br>
            {loading ? (
                <Title>Loading ...</Title>
            ) : (
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 600 }}
                initialValues={{
                    cityFrom: order?.cityFrom ?? "",
                    adressFrom: order?.adressFrom ?? "",
                    cityTo: order?.cityTo ?? "",
                    adressTo: order?.adressTo ?? "",
                    weight: order?.weight ?? "",
                    date: moment(order?.date),   // ?? "",
                    specialNote: order?.specialNote ?? ""
                }}   
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <div>
                <Form.Item<OrderRequest>
                    label="City From"
                    name="cityFrom"
                    rules={[{ required: true, message: 'Please input city from!' }]}
                >
                        <Input/>
                </Form.Item>

                <Form.Item<OrderRequest>
                    label="Adress From"
                    name="adressFrom"
                    rules={[{ required: true, message: 'Please input adress from!' }]}
                    >
                        <Input/>
                </Form.Item>

                <Form.Item<OrderRequest>
                    label="City To"
                    name="cityTo"
                    rules={[{ required: true, message: 'Please input city to!' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item<OrderRequest>
                    label="Adress To"
                    name="adressTo"
                    rules={[{ required: true, message: 'Please input adress to!' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item<OrderRequest>
                    label="Weight"
                    name="weight"
                    rules={[{ required: true, message: 'Please input weight!' }]}
                >
                    <InputNumber min={1} max={1000} />
                </Form.Item>

                <Form.Item<OrderRequest>
                    label="Date"
                    name="date"
                    rules={[{ required: true, message: 'Please input date!' }]}
                >
                                <DatePicker/>
                </Form.Item>

                <Form.Item<OrderRequest>
                    label="Special Note"
                    name="specialNote"
                    rules={[{ required: false }]}
                >
                    <Input.TextArea />
                </Form.Item>
                </div>

                <Form.Item label={null}>
                    <Space>
                        <Button
                            type="primary"
                            htmlType="submit"
                        >
                            Сохранить
                        </Button>
                    </Space>
                    <Space>
                        <Button htmlType="reset">
                            Сбросить
                        </Button>
                    </Space>
                </Form.Item>
                </Form>
            )}
        </div >
    );
}
