interface HowToPlayInterface{
    id : number,
    question : string,
    answer : string,
    opened : boolean
}

interface HowToPlayEntryInterface{
    source : HowToPlayInterface,
    onClick : (id : number) => void
}

export { HowToPlayInterface, HowToPlayEntryInterface }