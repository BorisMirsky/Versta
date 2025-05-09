import styles from "./page.module.css";
import LoginComponent from './Components/LoginComponent';
import RegistrationComponent from './Components/RegistrationComponent';


export default function Home() {
    return (
        <div className={styles.page}>
            <h1>Сайт заказов </h1>
            <div>
              <LoginComponent />
              <RegistrationComponent />
            </div>
        </div >
    );
}
