import React from "react";
import { loginCostumer } from "../axios/CostumerApi";
import { useState } from "react";
import { useNavigate } from 'react-router-dom';



const Costumer=()=>{
    const [name, setName]=useState('');
    const [password, setPassword]=useState(0);
    
    const navigate = useNavigate();

    const checkCostumer=async()=>{
        loginCostumer(name,password).then(response=>{
            if(response===true){
                // navigate("./",{replace:false});
            }
            else{
                alert("we dont recognize you, register now")
                navigate('/Register', {replace:false})                
            }
        })

    }
    
  
return (<div>
    <h1>Welcome Costumer!!!</h1>
    <input type="text" placeholder="name" required onBlur={(e) => setName(e.target.value)}/>
    <input type="password" placeholder="password" required onBlur={(e) => setPassword(e.target.value)}/>
    <button onClick={checkCostumer}>enter</button>
    </div>
)

}
export default Costumer;