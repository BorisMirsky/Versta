"use client"

//registrationUser,
import React from 'react';
import { registerUser ,UserRegistrationRequest } from "@/app/Services/service";
//import { getAllOrders } from "@/app/Services/service"; 
//import { CreateOrderForm } from "@/app/Components/CreateOrderComponent";   
//import { Order } from "@/app/Models/Order";
import { FormProps, Button, Form, Input, Space } from 'antd';
//import { useRouter } from 'next/navigation';
//import moment from 'moment';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import Link from "next/link";



export default function Registration() {
    //const router = useRouter();
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        setLoading(false);
    });

    const onFinishFailed: FormProps<UserRegistrationRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    }

    const onFinish: FormProps<UserRegistrationRequest>['onFinish'] = (values) => {
        console.log('register values', values);
        registerUser(values);
        //router.push("/allorders");
    }

    return (
        <div >
            <h1>Регистрация </h1>
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
                    <Form.Item<UserRegistrationRequest>
                        label="Email"
                        name="email"
                        rules={[{ required: true, message: 'Please input login!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<UserRegistrationRequest>
                        label="Password"
                        name="password"
                        rules={[{ required: true, message: 'Please input password!' }]}
                    >
                        <Input />
                        </Form.Item>

                    <Form.Item<UserRegistrationRequest>
                        label="UserName"
                        name="username"
                        rules={[{ required: true, message: 'Please input login!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<UserRegistrationRequest>
                        label="Role"
                        name="role"
                        rules={[{ required: true, message: 'Please input password!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item label={null}>
                        <Space>
                            <Button
                                type="primary"
                                htmlType="submit"
                            >
                                Регистрация
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
            <br></br>
            <br></br>
            <p>
                <Link
                href={{
                    pathname: "login"
                }}
                legacyBehavior={true}
                >Войти под своим логином
                </Link>
            </p>
        </div >
    );
}