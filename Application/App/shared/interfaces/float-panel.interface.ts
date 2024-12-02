import { FloatPanelEnum } from "../enums/float-panel.enum";

interface FloatPanelStateContent{
    name : string,
    content : string
}

interface FloatPanelStateInterface extends FloatPanelStateContent {
    which : FloatPanelEnum,
    isVisible : boolean
}

export {
    FloatPanelStateContent,
    FloatPanelStateInterface
}