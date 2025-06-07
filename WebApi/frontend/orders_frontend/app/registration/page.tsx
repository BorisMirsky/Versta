"use client"

import React from 'react';
import { registerUser ,UserRegistrationRequest } from "@/app/Services/service";
import { Select, FormProps, Button, Form, Input, Space } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";


export default function Registration() {
    const [currentRole, setCurrentRole] = useState("");
    const [loading, setLoading] = useState(true);
    const { Option } = Select;


    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
        setLoading(false);
    }, []);

    const onFinishFailed: FormProps<UserRegistrationRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    }

    const onFinish: FormProps<UserRegistrationRequest>['onFinish'] = (values) => {
        registerUser(values);
    }

    return (
        <div>
            {
                (currentRole === 'admin') ? (
                    <div >
                        <br></br>
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
                                    rules={[{ required: true, message: 'Please input login(email)!' }]}
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
                                    rules={[{ required: true, message: 'Please input UserName!' }]}
                                >
                                    <Input />
                                </Form.Item>

                                <Form.Item<UserRegistrationRequest>
                                    label="Role"
                                    name="role"
                                    rules={[{ required: true}]}
                                >
                                        <Select
                                            onChange={(value) => {
                                                alert(value)
                                            }}
                                            placeholder="Выбор роли">
                                            <Option value="manager">manager</Option>
                                            <Option value="visitor">visitor</Option>
                                        </Select>
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
                    </div >
                ) : (
                        <div>
                            <h1>Регистрируют только админы</h1>
                        </div>
                )
            }
        </div>
    );
}