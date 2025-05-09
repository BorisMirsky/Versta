import React, { useState } from 'react';
import { Modal } from 'antd';




//export default function ModalComponent(mode: boolean) {
export const ModalComponent = (mode: boolean) => {
    const [isModalOpen, setIsModalOpen] = useState(false);     

    if (mode) {
        setIsModalOpen(true);
    }
    //const showModal = (mode) => {
    //    setIsModalOpen(true);
    //};

    const handleOk = () => {
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    return (
        <>
            <Modal
                title="Basic Modal"
                closable={{ 'aria-label': 'Custom Close Button' }}
                open={isModalOpen}
                onOk={handleOk}
                onCancel={handleCancel}
            >
                <p>Some contents...</p>
            </Modal>
        </>
    );
};

