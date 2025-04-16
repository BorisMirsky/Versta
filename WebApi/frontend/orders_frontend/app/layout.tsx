import '@ant-design/v5-patch-for-react-19';
import "./globals.css";
import Layout, { Header, Content, Footer } from "antd/es/layout/layout";
import { Menu } from "antd";
import Link from "next/link";



const items = [
    { key: "home", label: <Link href="/">Home</Link> },
    { key: "allorders", label: <Link href="/allorders">All Orders</Link> },
    { key: "neworder", label: <Link href="/neworder">New Order</Link> }
]

export default function RootLayout({
    children,
}: {
    children: React.ReactNode;
}) {
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

