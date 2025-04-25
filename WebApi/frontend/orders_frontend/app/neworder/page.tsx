"use client"

import React from 'react';
import { createOrder, OrderRequest } from "@/app/Services/service";   
//import { getAllOrders } from "@/app/Services/service"; 
//import { CreateOrderForm } from "@/app/Components/CreateOrderComponent";   
//import { Order } from "@/app/Models/Order";
import { FormProps, Button, Form, Input, InputNumber, DatePicker, Space } from 'antd';
import { useRouter } from 'next/navigation'; 
import moment from 'moment';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";  


export default function NewOrder() {
    const router = useRouter();
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        setLoading(false);
    });  

    const onFinishFailed: FormProps<OrderRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    }

    const onFinish: FormProps<OrderRequest>['onFinish'] = (values) => {
        createOrder(values);
        router.push("/allorders");       
    }

    return (
        <div >
            <h1>Создание нового заказа </h1>
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
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                    onFinishFailed={onFinishFailed}
                    autoComplete="off"
                >
                    <Form.Item<OrderRequest>
                        label="City From"
                        name="cityFrom"
                        rules={[{ required: true, message: 'Please input city from!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<OrderRequest>
                        label="Adress From"
                        name="adressFrom"
                        rules={[{ required: true, message: 'Please input adress from!' }]}
                    >
                        <Input />
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
                        <DatePicker
                           format="YYYY-MM-DD"
                        />
                    </Form.Item>

                    <Form.Item<OrderRequest>
                        label="Special Note"
                        name="specialNote"
                        rules={[{ required: false }]}
                    >
                        <Input.TextArea />
                    </Form.Item>

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