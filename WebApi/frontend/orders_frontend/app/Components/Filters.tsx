//import '../App.css';
import { Input } from 'antd';
//import { Select } from 'antd';


export default function Filters({ filter, setFilter }) {  
    return (
        <div className="flex flex-col gap-5">
            <Input
                placeholder="поиск по городу отправки"
                onChange={(e) => setFilter({ ...filter, search: e.target.value })}
            />
            {/*<Input*/}
            {/*    placeholder="поиск по городу доставки"*/}
            {/*onChange={(e) => setFilter({ ...filter, search: e.target.value })}*/}
            {/*/>*/}
        </div>
    );
}


