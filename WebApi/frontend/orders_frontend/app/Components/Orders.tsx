import { Table } from "antd";


//interface Props {
//    orders: Order[];
//}

const dataSource = [
    {
        key: '',
        n: '',
        uniqid: '',
        cityfrom: '',
        addressfrom: '',
        cityto: '',
        addressto: '',
        weight: '',
        date: '',
        specialnote: ''
    }
]

const columns = [
    {
        title: 'N',
        dataIndex: 'n',
        key: 'n',
    },
    {
        title: 'Uniq Id',
        dataIndex: 'uniq id',
        key: 'uniq id',
    },
    {
        title: 'City From',
        dataIndex: 'city from',
        key: 'city from',
    },
    {
        title: 'Adress From',
        dataIndex: 'adress from',
        key: 'adress from',
    },
    {
        title: 'City To',
        dataIndex: 'city to',
        key: 'city to',
    },
    {
        title: 'Adress To',
        dataIndex: 'adress to',
        key: 'adress to',
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
    },
    {
        title: 'Special Note',
        dataIndex: 'special note',
        key: 'special note',
    }
]


export default function AllOrders1() {
    return (
        <div >
            <h1>Все заказы </h1>
            <Table dataSource={dataSource} columns={columns} />
        </div >
    );
}
