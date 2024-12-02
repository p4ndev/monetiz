interface ButtonPropsInterface{
    id? : number | string,
    label? : string,
    i18n? : string,
    icon? : string,
    onClick : () => void
}

interface LobbyButtonPropsInterface extends ButtonPropsInterface{
    colors : Array<string>
}

export { ButtonPropsInterface, LobbyButtonPropsInterface }