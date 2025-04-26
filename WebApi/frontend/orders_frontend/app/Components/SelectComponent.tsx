//import '../App.css';
import { Select } from 'antd';
const { Option } = Select;


export default function SelectComponnet({ filter, setFilter }) {
    return (
        <Select
            defaultValue="Сначала новые"
            style={{ width: 220 }}
            onChange={(e) => setFilter({ ...filter, sortOrder: e})}>
            <Option value="1">Сначала старые</Option>
            <Option value="2">Сначала новые</Option>
        </Select>
    );
}

