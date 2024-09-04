import axios from "axios";
axios.defaults.baseURL = "http://localhost:5261";

export async function loginCostumer(name_manager, password) {
    // try{
    //     axios.defaults.baseURL="http://localhost:5261";
    //     return await axios.get('/Manager/get',
    //     {
    //         "ManName":name_manager,
    //         "Password":password
    //     })
    //     .ther(function(response){
    //         console.log(response);
    // localStorage.setItem('CostumerId',הID שחוזר מהשרת, לפיו טוענים את המתנות של כל לקוח )

    //         return response
    //     })
    // }
    // catch(error)
    // {
    //     console.log(error);
    // };
}
export async function Register(password, name, phone, email) {
    try {
        return await axios.post('/Buyer/register', {
            "password": password,
            "name": name,
            "phone": phone,
            "email": email
        }).then(function (response) {
            console.log(response);
            localStorage.setItem('userId', response.data.id)
            console.log(localStorage.getItem('userId'));
            return response;
        })
    }
    catch (error) {
        console.log(error);
    }
}

export async function getAllPresent() {
    try {
        return await axios.get('/Present/getAll')
            .then(function (response) {
                console.log(response);
                return response
            })
    }
    catch (error) {
        console.log("Error occurred:", error);
    };
}


export async function AddCard(presentID) {
    try {
        const buyerId = localStorage.getItem('userId');
        // if (!buyerId) {
        //     throw new Error("User ID not found in localStorage.");
        // }
        return await axios.post(`/Card/AddNewCard${presentID},${2}`)
        // return await axios.post(`/Card/AddNewCard${presentID},${localStorage.getItem('buyerID')}`)
            .then(function (response) {
                console.log(response);
                return response

            })
    }
    catch (error) {
        console.log(error);
    };
}

export async function DeleteCard(presentID, buyerId) {
    try {
        return await axios.delete(`/Card/RemoveCard${presentID},${2}`)
            .then(function (response) {
                console.log(response);
                return response
            })
    }
    catch (error) {
        console.log(error);
    };
}

export async function AddPurchases(purchase) {
    try {
        return await axios.post('/Purchase/AddNewPurchase',
            {
                "numberOfTicket": purchase.numberOfTicket,
                "buyerID": purchase.buyerID,
                "status": purchase.status
            })
            .then(function (response) {
                console.log(response);
                return response

            })
    }
    catch (error) {
        console.log(error);
    };
}
export async function GetPresentsPurcheses() {
    try {
        return await axios.get(`/Present/getPresentsPurcheses${2}`)
            .then(function (response) {
                console.log(response);
                return response
            })
    }
    catch (error) {
        console.log(error);
    };
}

// export async function FinishPurchase() {
//     try {
//         return await axios.put(`/Purchase/finishPurchase${1}`)
//             .then(function (response) {
//                 console.log(response);
//                 return response
//             })
//     }
//     catch (error) {
//         console.log(error);
//     };
// }

