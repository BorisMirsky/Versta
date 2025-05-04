import styles from "./page.module.css";


export default function Home() {
    return (
        <div className={styles.page}>
            <h1>Сайт заказов </h1>
            <div>
            <h4><a href="/registration">Регистрация</a></h4>
                <h4><a href="/login">Войти на сайт под своим логином</a></h4>
            </div>
        </div >
    );
}
