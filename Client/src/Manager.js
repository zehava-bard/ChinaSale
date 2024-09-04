import React, { useState } from "react";
import {loginManager} from './axios/MangerApi'
//import { useNavigate } from 'react-router-dom';



const Manager=()=>{
    
    //const navigate = useNavigate();
    const [name, setName]=useState('');
    const [password, setPassword]=useState(0);

    const checkManger=async()=>{
        loginManager(name,password).then(response=>{
            if(response===true){
                // navigate("./",{replace:false});
            }
            else{
                alert("we dont recognize you, try again")
            }
        })

    }
    
return (<div>
        <h1>Welcome Manager!!!</h1>
        <br></br>
        <input type="text" placeholder="name" required onBlur={(e) => setName(e.target.value)}/>
        <input type="password" placeholder="password" required onBlur={(e) => setPassword(e.target.value)}/>
        <button onClick={checkManger}>enter</button>
    </div>
)

}
export default Manager;