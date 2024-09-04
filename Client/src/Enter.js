import React from "react";
import { useNavigate } from 'react-router-dom';
//import { Link } from "react-router-dom";




const Enter=()=>{
    
   const navigate = useNavigate();

    const Manager=()=>{ 
        navigate("/Manager", {replace:false})

    }

    const Costumer=()=>{  
        navigate('/Costumer', {replace:false})
    }

return (<div>


    <button onClick={Manager}>Manager</button>
    <button onClick={Costumer}>Costumer</button>

    </div>
)

}
export default Enter;