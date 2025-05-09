import '@ant-design/v5-patch-for-react-19';
import "./globals.css";
import Layout, { Header, Content, Footer } from "antd/es/layout/layout";
import { Menu } from "antd";
import Link from "next/link";
import CurrentUserComponent from './Components/NavbarCurrentUserComponent';
import LogoutComponent from './Components/NavbarLogoutComponent';
import NavbarAllordersComponent from './Components/NavbarAllordersComponent';
import NavbarNeworderComponent from './Components/NavbarNeworderComponent';


export default function RootLayout({ children, }: { children: React.ReactNode; })   
{
    const items = [
        { key: "home", label: <Link href="/">Home</Link> },
        { key: "allorders", label: <NavbarAllordersComponent /> },
        { key: "neworder", label: <NavbarNeworderComponent /> },
        { key: "currentuser", label: <CurrentUserComponent /> },
        { key: "logout", label: <LogoutComponent /> }
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

