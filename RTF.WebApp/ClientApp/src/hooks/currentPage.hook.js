import { useState } from "react"

export const usePageName = () => {
    const [name, switchName] = useState('');
    const setName = (x) => {
        switchName(x);
    };
    
    return {name, setName};
}
