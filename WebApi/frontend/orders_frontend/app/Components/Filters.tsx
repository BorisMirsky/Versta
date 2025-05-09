//import '../App.css';
import { Input } from 'antd';
//import FilterInterface from "@/app/Services/service";
//import { Select } from 'antd';


export default function Filters({ filter, setFilter }) {  
    //console.log('filter: ', filter)
    return (
        <div className="flex flex-col gap-5">
            <Input
                style={{ width: 220 }}
                placeholder="поиск по городу отправки"
                onChange={(e) => setFilter(
                    { ...filter, search: e.target.value },
                    //console.log('e.target.value ', e.target.value) 
                )
                }
            />            
        </div>
    );
}

{/*<Input*/ }
{/*    placeholder="поиск по городу доставки"*/ }
{/*onChange={(e) => setFilter({ ...filter, search: e.target.value })}*/ }
{/*/>*/ }

