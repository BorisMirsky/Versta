
import { Input } from 'antd';
import { Select } from 'antd';
const { Option } = Select;


interface Props {
    filter?: object,
    setFilter(filter: object): void   
}

export default function Filters({ filter, setFilter }: Props) {  
    return (
        <div className="flex flex-col gap-5">
            <Input
                style={{ width: 220 }}
                placeholder="поиск по городу отправки"
                onChange={(e) => setFilter(
                    { ...filter, search: e.target.value },
                )}
            />   
            <Select
                defaultValue="Сначала новые"
                style={{ width: 220 }}
                onChange={(e) => setFilter({ ...filter, sortOrder: e })}>
                <Option value="1">Сначала старые</Option>
                <Option value="2">Сначала новые</Option>
            </Select>
        </div>
    );
}


