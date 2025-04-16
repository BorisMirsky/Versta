import React from 'react';
import { Button, Form, Input, InputNumber, DatePicker, Space } from 'antd';
import type { FormProps } from 'antd';
import { OrderRequest, createOrder } from "@/app/Services/service";   //createOrder
import { Order } from "@/app/Models/Order";
import { useEffect, useState } from "react";



interface Props {
    values: Order;
    handleCreate: (request: OrderRequest) => void;
}

export const CreateOrderForm = ({
    values                                  
        }: Props) => {
    const [cityFrom, setCityfrom] = useState<string>("");
    const [adressFrom, setAdressfrom] = useState<string>("");
    const [cityTo, setCityto] = useState<string>("");
    const [adressTo, setAdressto] = useState<string>("");
    const [weight, setWeight] = useState<number>(1);
    const [date, setDate] = useState<Date>(new Date());
    const [specialNote, setSpecialnote] = useState<string>("");

    useEffect(() => {
        setCityfrom(values.cityFrom);
        setAdressfrom(values.adressFrom);
        setCityto(values.cityTo);
        setAdressto(values.adressTo);
        setWeight(values.weight);
        setDate(values.date);
        setSpecialnote(values.specialnote);
    }, [values]);

    //const handleOnOk = async () => {
    //    const request: OrderRequest = {
    //        cityFrom, adressFrom, cityTo,
    //        adressTo, weight, date, specialNote
    //    };
    //    handleCreate(request);
    //};

    const onFinishFailed: FormProps<OrderRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    }

    const onFinish = () => {      //values: object
        const request: OrderRequest = {
            cityFrom: cityFrom, //values.cityFrom,
            cityTo: cityTo, //values.cityTo,
            adressFrom: adressFrom,  //values.adressFrom,
            adressTo: adressTo,  //values.adressTo,
            weight: weight,   //values.weight,
            date: date,   //values.date
            specialNote: specialNote
        }
        createOrder(request);
        console.log('onFinish ', request, typeof (request));
    }


    return (
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
                <DatePicker />
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
    );
}