import { useContext, createContext } from 'react';
import { usePageName } from "../hooks/currentPage.hook";

export let CurrentPageContext = createContext({
    name: '',
    setName: () => {},
})

export const useCurrentPageContext = () => useContext(CurrentPageContext)

export const CurrentPageContextProvider = ({children}) => {
    const {name, setName} = usePageName();

    return <CurrentPageContext.Provider value={{name, setName}}>{children}</CurrentPageContext.Provider>
}