import axios from "axios";
axios.defaults.baseURL = "http://localhost:5261";


export async function loginManager(name_manager, password)
{
    try {
        return await axios.get("/Manager/get",{       //(name_manager,password)      
        }      
        ).then(function(response){
            console.log(response);
            return response
        })
    }
    catch(error)
    {
        console.log(error);
    };
}
    

export async function FinishPurchase() {
    try {
        return await axios.put(`/Purchase/finishPurchase${1}`)
            .then(function (response) {
                console.log(response);
                return response
            })
    }
    catch (error) {
        console.log(error);
    };
}
export async function DeletePresent(id_p){
    return await axios.delete(`/Present/${id_p}`)
    .then(function (response) {
        console.log(response);
        return response
    })    
}
// export async function DeleteSeveralPresents(presents){
//     return await axios.delete(`/Present/deleteSeveralPresents${presents}`)
//     .then(function (response) {
//         console.log(response);
//         return response
//     })    
// }


export async function DeleteSeveralPresents(presents) {
    return await axios.delete('/Present/deleteSeveralPresents', presents)   
    .then(function (response) {
      console.log(response);
      return response;
    })
    .catch(function (error) {
      console.error("There was an error deleting the presents!", error);
      throw error;
    });
  }


export async function GetAllCategories()
{
    return await axios.get('/Category/getAllCategories')
    .then(function (response) {
        console.log(response);
        return response;
      })
      .catch(function (error) {
        console.error("There was an error deleting the presents!", error);
        throw error;
      });
}

// export async function UpdatePresent(id_p, Present_d)
// {
//     return await axios.put('/Present/updatePresent',{
//         "Name": Present_d.Name,
//         "Price": Present_d.Price,
//         "CategoryID": Present_d.CategoryID,
//       })
//     .then(function (response) {
//         console.log(response);
//         return response;
//       })
//       .catch(function (error) {
//         console.error("", error);
//         throw error;
//       });
// }



// export async function UpdatePresent(id_p, Present_d) {
//     try {
//         axios.defaults.baseURL = "http://localhost:5261";
//         return await axios.post('/Present/UpdatePresent',
//         {
//           "Name": Present_d.Name,
//           "Price": Present_d.Price,
//           "CategoryID": Present_d.CategoryID,
//         })
//         .then(function (response) {
//           console.log(response);
//           return response
//         })
//     }
//     catch (error) {
//       console.log(error);
//     };
//   }


  export async function UpdatePresent(id_p,Present_d) {
    let pres = {        
        name: Present_d.name,
        categoryID: Present_d.category.id,
        price: Present_d.price,
    };
    return await axios.put('/Present/updatePresent?id='+id_p, pres)
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);
      });
  
  }

 
  export async function AddPresent(Present_d) {
    let pres = {        
        name: Present_d.name,
        price: Present_d.price,        
        categoryID: Present_d.category.id,
        DonorsID:Present_d.donor.id
    };
    return await axios.post('/Present/AddNewPresent',pres)
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);
      });  
  }

  
  export async function getAllDonors() {  
    
    return await axios.get('/Donors/get')
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);


      });  
  }

  export async function DeleteDonor(id) {  
    
    return await axios.delete(`/Donors/${id}`)
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);


      });  
  }

  export async function updateDonor(id_d,don) {
    let donor = {        
        name: don.name,
        phone:don.phone,
        email:don.email      
    };
    
    return await axios.put('/Donors/updateDonor?id='+id_d, donor)
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);
      });  
  }

  
  export async function AddDonor(don) {
    let donor = {        
      name: don.name,
      phone:don.phone,
      email:don.email      
  };
    return await axios.post('/Donors',donor)
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);
      });  
  }

  export async function ViewAllPurchase(id_p) {
  
    return await axios.get('/Purchase/getUserOfPresent?id='+id_p)
      .then(function (response) {
  
        console.log('response', response);
        return response;
      })
      .catch(function (error) {
        console.log(error);
      });
  
  }