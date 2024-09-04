import React, { useState, useEffect, useRef } from 'react';
import { classNames } from 'primereact/utils';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Toast } from 'primereact/toast';
import { Button } from 'primereact/button';
import { FileUpload } from 'primereact/fileupload';
import { Rating } from 'primereact/rating';
import { Toolbar } from 'primereact/toolbar';
import { InputTextarea } from 'primereact/inputtextarea';
import { IconField } from 'primereact/iconfield';
import { InputIcon } from 'primereact/inputicon';
import { RadioButton } from 'primereact/radiobutton';
import { InputNumber } from 'primereact/inputnumber';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Tag } from 'primereact/tag';
import { getAllPresent } from '../axios/CostumerApi';
import { AddPresent, DeletePresent } from '../axios/MangerApi';
import { DeleteSeveralPresents } from '../axios/MangerApi';
import { GetAllCategories } from '../axios/MangerApi';
import { UpdatePresent } from '../axios/MangerApi';
import { getAllDonors } from '../axios/MangerApi';
import { updateDonor } from '../axios/MangerApi';
import { DeleteDonor } from '../axios/MangerApi';
import { AddDonor } from '../axios/MangerApi';

const Donor = () => {

    let emptyDonor = {
        id: null,
        name: '',
        phone: '',
        email: '',
    };
    const [Donors, setDonors] = useState([]);
    const [donor, setDonor] = useState(emptyDonor)
    const [donorDialog, setDonorDialog] = useState(false);
    const [deleteDonorDialog, setDeleteDonorDialog] = useState(false);
    const [submitted, setSubmitted] = useState(false);
    const [New_donorDialog, setNew_donorDialog]=useState(false);
    const toast = useRef(null);


    useEffect(() => {
        getAllDonors().then((data) => setDonors(data.data))
    }, [])

    const editdonor = (donor) => {
        setDonor({ ...donor });
        setDonorDialog(true);
    };

    const confirmDeleteDonor = (donor) => {
        setDonor(donor);
        setDeleteDonorDialog(true);
    };
    const openNew = () => {
        setDonor(emptyDonor);
        setSubmitted(false);
        setNew_donorDialog(true);
    };


    const onInputChange = (e, name) => {
        const val = (e.target && e.target.value) || '';
        let _donor = { ...donor };

        _donor[`${name}`] = val;

        setDonor(_donor);
    };


    const deleteDonor = async () => {
        await DeleteDonor(donor.id).then(hideDeleteDonorDialog)
        const a = await getAllDonors();
        setDonors(a.data)
    }
    const hideDialog = () => {
        setDonorDialog(false);
        setNew_donorDialog(false);

    }
    const saveDonor = async () => {
        updateDonor(donor.id, donor).then(
            setSubmitted(true))

        if (donor.name.trim()) {
            let _donors = [...Donors];
            let _donor = { ...donor };

            toast.current.show({ severity: 'success', summary: 'Successful', detail: 'donor Updated', life: 3000 });


            const a = await getAllDonors();
            setDonors(a.data)
            setDonorDialog(false);
            setDonor(emptyDonor);
        }
    }
    const saveNewDonor=async()=>{
        AddDonor(donor).then(async(res)=>
        {
 
             toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Product Created', life: 3000 });
 
             const aa=await getAllPresent();
             setDonors(aa.data);
             setNew_donorDialog(false);
             setDonor(emptyDonor);
         
 
          setSubmitted(true)
        })    

    }
    const hideDeleteDonorDialog = () => {
        setDeleteDonorDialog(false);
    }

    const donorDialogFooter = (
        <React.Fragment>
            <Button label="Cancel" icon="pi pi-times" outlined onClick={hideDialog} />
            <Button label="Save" icon="pi pi-check" onClick={saveDonor} />
        </React.Fragment>
    );
    const deleteDonorDialogFooter = (
        <React.Fragment>
            <Button label="No" icon="pi pi-times" outlined onClick={hideDeleteDonorDialog} />
            <Button label="Yes" icon="pi pi-check" severity="danger" onClick={deleteDonor} />
        </React.Fragment>
    );

    const AddNewDonorDialogFooter = (
        //to change...
        <React.Fragment>
            <Button label="Cancel" icon="pi pi-times" outlined onClick={hideDialog} />
            <Button label="Save" icon="pi pi-check" onClick={saveNewDonor} />
        </React.Fragment>
    );




    const rightToolbarTemplate = () => {
        return (
            <div className="flex flex-wrap gap-2">
                <Button label="New Donor" icon="pi pi-plus" severity="success" onClick={openNew} />
            </div>
        );
    };


    const actionBodyTemplateDonor = (rowData) => {
        return (
            <React.Fragment>
                <Button icon="pi pi-pencil" rounded outlined className="mr-2" onClick={() => editdonor(rowData)} />
                <Button icon="pi pi-trash" rounded outlined severity="danger" onClick={() => confirmDeleteDonor(rowData)} />
            </React.Fragment>
        );
    }

    const headeDonors = (
        <div className="flex flex-wrap gap-2 align-items-center justify-content-between">
            <h4 className="m-0">The Donors</h4>
            <Toolbar className="mb-4" right={rightToolbarTemplate}></Toolbar>
        </div>
    )

    return (
        <div>
            <Toast ref={toast} />
            <div className="card">
                <DataTable value={Donors} tableStyle={{ minWidth: '50rem' }} header={headeDonors}>
                    <Column field="name" header="Name"></Column>
                    <Column field='phone' header="Phone"></Column>
                    <Column field='email' header="Email"></Column>
                    <Column body={actionBodyTemplateDonor} exportable={false} style={{ minWidth: '12rem' }}></Column>
                </DataTable>
            </div>



            {/* donor dialogs */}
            <Dialog visible={donorDialog} style={{ width: '32rem' }} breakpoints={{ '960px': '75vw', '641px': '90vw' }} header="donor Details" modal className="p-fluid" footer={donorDialogFooter} onHide={hideDialog}>
                <div className="field">
                    <label htmlFor="name" className="font-bold">
                        Name
                    </label>
                    <InputText id="name" value={donor.name} onChange={(e) => onInputChange(e, 'name')} required autoFocus className={classNames({ 'p-invalid': submitted && !donor.name })} />
                    {submitted && !donor.name && <small className="p-error">Name is required.</small>}


                    <label htmlFor="phone" className="font-bold">
                        Phone
                    </label>
                    <InputText id="phone" value={donor.phone} onChange={(e) => onInputChange(e, 'phone')} required autoFocus className={classNames({ 'p-invalid': submitted && !donor.name })} />
                    {submitted && !donor.phone && <small className="p-error">phone is required.</small>}
                    <label htmlFor="phone" className="font-bold">
                        Email
                    </label>
                    <InputText id="phone" value={donor.email} onChange={(e) => onInputChange(e, 'email')} required autoFocus className={classNames({ 'p-invalid': submitted && !donor.email })} />
                </div>
            </Dialog>

            <Dialog visible={deleteDonorDialog} style={{ width: '32rem' }} breakpoints={{ '960px': '75vw', '641px': '90vw' }} header="Confirm" modal footer={deleteDonorDialogFooter} onHide={hideDeleteDonorDialog}>
                <div className="confirmation-content">
                    <i className="pi pi-exclamation-triangle mr-3" style={{ fontSize: '2rem' }} />
                    {donor && (
                        <span>
                            Are you sure you want to delete <b>{donor.name}</b>?
                        </span>
                    )}
                </div>
            </Dialog>

            <Dialog visible={New_donorDialog} style={{ width: '32rem' }} breakpoints={{ '960px': '75vw', '641px': '90vw' }} header="Donor Details" modal className="p-fluid" footer={AddNewDonorDialogFooter} onHide={hideDialog}>
            <div className="field">
                    <label htmlFor="name" className="font-bold">
                        Name
                    </label>
                    <InputText id="name" value={donor.name} onChange={(e) => onInputChange(e, 'name')} required autoFocus className={classNames({ 'p-invalid': submitted && !donor.name })} />
                    {submitted && !donor.name && <small className="p-error">Name is required.</small>}


                    <label htmlFor="phone" className="font-bold">
                        Phone
                    </label>
                    <InputText id="phone" value={donor.phone} onChange={(e) => onInputChange(e, 'phone')} required autoFocus className={classNames({ 'p-invalid': submitted && !donor.name })} />
                    {submitted && !donor.phone && <small className="p-error">phone is required.</small>}
                    <label htmlFor="phone" className="font-bold">
                        Email
                    </label>
                    <InputText id="phone" value={donor.email} onChange={(e) => onInputChange(e, 'email')} required autoFocus className={classNames({ 'p-invalid': submitted && !donor.email })} />
                </div>
               
               
            </Dialog>
        </div>
    );

}
export default Donor