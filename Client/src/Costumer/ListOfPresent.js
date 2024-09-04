import React, { useState } from "react";
import { useEffect } from "react";
import { getAllPresent } from "../axios/CostumerApi";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { useCounter } from 'primereact/hooks';
import { DataScroller } from 'primereact/datascroller';
import { Toolbar } from 'primereact/toolbar';
import { useNavigate } from 'react-router-dom';
import { AddCard } from '../axios/CostumerApi';
import { DeleteCard } from "../axios/CostumerApi";

const ListOfPressent = () => {


    const [listOfPressent, setListOfPressent] = useState([]);
    const [basket, setBasket] = useState([]);
    const [counter, setCounter] = useState(0);
    const [purchaseId, setPurchaseId] = useState('');


    const navigate = useNavigate();

    useEffect(() => {
        getAllPresent().then((data) => setListOfPressent(data))
    }, [])


    const formatCurrency = (value) => {
        return value.toLocaleString('en-US', { style: 'currency', currency: 'ILS' });
    };

    const imageBodyTemplate = (product) => {
        //another function
        return <img src={product.image} alt={product.image} className="w-6rem shadow-2 border-round" />;
    };

    const priceBodyTemplate = (product) => {
        return formatCurrency(product.price);
    };

    const header = (
        <div className="flex flex-wrap align-items-center justify-content-between gap-2">
            <span className="font-bold text-4xl mb-5">Present</span>
            <span ></span>
            <span className="text-xl text-900 font-bold">{counter}</span>
            <Button icon="pi pi-refresh" rounded raised />
        </div>
    );

    const myincrement = (product) => {
        AddCard(product.id)
            .then(setCounter(prevCount => prevCount + 1))


    };

    // const mydecrement = (product) => {
    //     DeleteCard(product.id)
    //     .then(setCounter(prevCount => {
    //         if (prevCount > 0) {
    //             return prevCount - 1;
    //         } else {
    //             return 0; 
    //         }
    //     }))
    // };
    
    const actionBodyTemplate = (rowData) => {
        return (
            <React.Fragment>
                <Button icon="pi pi-shopping-cart" rounded outlined className="mr-2" onClick={() => myincrement(rowData)} />
                {/* <Button icon="pi pi-plus" className="p-button-outlined p-button-rounded p-button-success" onClick={() => myincrement(rowData)}></Button> */}
                {/* <Button icon="pi pi-minus" className="p-button-outlined p-button-rounded" onClick={mydecrement}></Button> */}
                {/* <Button icon="pi pi-times" className="p-button-outlined p-button-rounded p-button-danger" onClick={reset}></Button> */}
            </React.Fragment>
        );
    };

    const to_the_shopping_cart = () => {
        return <Button label="The shopping cart" className="p-button-help" onClick={func_navigate}/>;
    };

    const func_navigate=()=>{
        navigate('/shoppingCart', {replace:false})
    }


    return (<div>

        <div className="card">

            <DataTable value={listOfPressent.data} sortField="price" sortOrder={-1} header={header} /*footer={footer}*/ tableStyle={{ minWidth: '60rem' }}>
                <Column field="name" header="Name"></Column>
                {/* <Column header="Image" body={imageBodyTemplate}></Column> */}
                <Column field="price" sortable header="Price" body={priceBodyTemplate}></Column>
                <Column field="category.name" sortable header="Category"></Column>
                {/* <Column field="rating" header="Reviews" body={ratingBodyTemplate}></Column> */}
                {/* <Column header="Status" body={statusBodyTemplate}></Column> */}
                <Column header="Add to cart" body={actionBodyTemplate} exportable={false} style={{ minWidth: '12rem' }}></Column>

            </DataTable>
        </div>
        <Toolbar className="mb-4" center={to_the_shopping_cart}></Toolbar>
    </div>
    )
}
export default ListOfPressent;



