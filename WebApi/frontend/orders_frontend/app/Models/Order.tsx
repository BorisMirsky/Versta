// как будет выглядеть книга, ейный интерфейс

export interface Order {
    id: string;
    cityFrom: string;
    adressFrom: string;
    cityTo: string;
    adressTo: string;
    weight: number,
    date: Date,
    specialnote: string
}