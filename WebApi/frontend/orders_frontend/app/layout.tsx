import '@ant-design/v5-patch-for-react-19';
import "./globals.css";
import Layout, { Header, Content, Footer } from "antd/es/layout/layout";
import { Menu } from "antd";
import Link from "next/link";
import CurrentUserComponent from './Components/CurrentUserComponent';
import LogoutComponent from './Components/LogoutComponent';
//import { useEffect, useState } from "react";
//import { logout } from "@/app/Services/service";


//const logoutHandler = () => {
//    logout();
//}

//key: "/", onClick: logoutHandler, label: <Link href="/">LogOut</Link>

//const [currentUser, setCurrentuser] = useState("");

//const items = [
//    { key: "home", label: <Link href="/">Home</Link> },
//    { key: "allorders", label: <Link href="/allorders">All Orders</Link> },
//    { key: "neworder", label: <Link href="/neworder">New Order</Link> },
//    { key: "/", label: <Link href="/">LogOut</Link>  }
//    { key: "/", label: <Link href="/">{currentUser}</Link>  }
//]


export default function RootLayout({ children, }: { children: React.ReactNode; })   
{
    //const [currentUser, setCurrentuser] = useState("");

    //useEffect(() => {
    //    const setCurrentUser = async () => {
    //        if (typeof window !== 'undefined') {
    //            const currentUser = localStorage.getItem('user') || '';
    //            setCurrentuser(currentUser);
    //        }
    //    };
    //    setCurrentUser();
    //});

    let handleLogoutClick () {                  //event
        console.log('event.target.value');
        //setState the content your component will re render and content will be updated.
    }

    const items = [
        { key: "home", label: <Link href="/">Home</Link> },
        { key: "allorders", label: <Link href="/allorders">All Orders</Link> },
        { key: "neworder", label: <Link href="/neworder">New Order</Link> },
        { key: "PPP", label: <CurrentUserComponent /> },
        { key: "BBB", onclick={handleLogoutClick }, label: "LogOut" }
    ]


    return (
        <html lang="en">
            <body>
                <Layout style={{ minHeight: '100vh' }}>
                    <Header>
                        <Menu
                            theme="dark"
                            mode="horizontal"
                            items={items}
                            style={{ flex: 1, minWidth: 0 }}
                        />
                    </Header>
                    <Content style={{ padding: '0 50px' }}>
                        {children}
                    </Content>
                    <Footer style={{ textAlign: 'center' }}>
                        Created at 2025 by Boris FatBoy
                    </Footer>
                </Layout>
            </body>
        </html>
    );
}

