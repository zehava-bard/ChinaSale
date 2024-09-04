import React, { useState, useEffect } from 'react';
import { Button } from 'primereact/button';
import { DataView, DataViewLayoutOptions } from 'primereact/dataview';
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { GetPresentsPurcheses } from '../axios/CostumerApi';
import { DeleteCard } from '../axios/CostumerApi';
import { Toolbar } from 'primereact/toolbar';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { FinishPurchase } from '../axios/MangerApi';
export default function BasicDemo() {
    const [products, setProducts] = useState([]);
    const [render, setRender] = useState("hello world!!!")
    const [visible, setVisible] = useState(false);


    useEffect(() => {
        GetPresentsPurcheses().then((data_response) => {
            const sortedProducts = data_response.data.sort((a, b) => a.name.localeCompare(b.name));
            setProducts(sortedProducts);
        });
    }, [render]);


    const gridItem = (product) => {
        return (
            <div className="col-12 sm:col-6 lg:col-12 xl:col-4 p-2">
                <div className="p-4 border-1 surface-border surface-card border-round">
                    <div className="flex flex-wrap align-items-center justify-content-between gap-2">
                        <div className="flex align-items-center gap-2">
                            <i className="pi pi-tag"></i>
                            <span className="font-semibold">{product.category.name}</span>
                        </div>
                        {/* <Tag value={product.inventoryStatus} severity={getSeverity(product)}></Tag> */}
                    </div>
                    <div className="flex flex-column align-items-center gap-3 py-5">
                        {/* <img className="w-9 shadow-2 border-round" src={`https://primefaces.org/cdn/primereact/images/product/${product.image}`} alt={product.name} /> */}
                        <div className="text-2xl font-bold">{product.name}</div>
                        {/* <Rating value={product.rating} readOnly cancel={false}></Rating> */}
                    </div>
                    <div className="flex align-items-center justify-content-between">
                        <span className="text-2xl font-semibold">{product.price}</span>
                        <Button icon="pi pi-minus" className="p-button-rounded" onClick={() => mydecrement(product)}></Button>
                    </div>
                </div>
            </div>
        );
    };

    const mydecrement = (product) => {
        DeleteCard(product.id)
        setRender("hi!!!")
        // .then(setCounter(prevCount => {
        //     if (prevCount > 0) {
        //         return prevCount - 1;
        //     } else {
        //         return 0;
        //     }
        // }))
    };

    const itemTemplate = (product) => {
        if (!product) {
            return;
        }
        return gridItem(product);
    };

    const header = () => {
        return (
            <span >the shopping cart</span>
        );
    };
    const payment = () => {
        return <Button label="close and pay" className="p-button-help" />;
    };

    const footerContent = (
        <div>
            <Button label="cancel" icon="pi pi-times" onClick={() => setVisible(false)} className="p-button-text" />
            <Button label="save" icon="pi pi-check" onClick={() => finishPurch(false)} autoFocus />
        </div>
    );
    const finishPurch=()=>{
        finishPurch()
        setVisible(false)
    }

    return (
        <div className="card">
            <DataView value={products} itemTemplate={itemTemplate} header={header()} />
            <div className="card flex justify-content-center">
                <Button label="close and pay" onClick={() => setVisible(true)} />
                <Dialog header="insert credit card details" visible={visible} style={{ height: '45vw', width: '50vw' }} onHide={() => { if (!visible) return; setVisible(false); }} footer={footerContent}>
                    <p className="m-0">
                        <div>
                            <div className="inline-flex flex-column gap-2">
                                <label htmlFor="username">
                                    Card owner name
                                </label>
                                <InputText id="username" label="Username" className="bg-white-alpha-20 p-3 text-primary-50"></InputText>
                            </div>
                            <br></br><br></br>
                            <div className="inline-flex flex-column gap-2">
                                <label htmlFor="username">
                                    Username
                                </label>
                                <InputText id="password" label="Password" className="bg-white-alpha-20 p-3 text-primary-50" type="password"></InputText>
                            </div>
                        </div>
                    </p>
                </Dialog>
            </div>

        </div>
    )
}
