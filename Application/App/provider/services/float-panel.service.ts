import { FloatPanelEnum } from "../../shared/enums";

export class FloatPanelService
{    
  private handler;
  private data;
  
  constructor(content, manager){
    this.handler = manager;
    this.data = content;
  }

  ShowLoaderModal = () => {
    this.handler({ 
      which: FloatPanelEnum.Loading,
      isVisible : true
    });
  }

  ShowInformationModal = (name : string, content : string) => {
    this.handler({
      which       : FloatPanelEnum.Information,
      content     : content,
      name        : name,
      isVisible   : true
    });
  }

  ShowConfirmationModal = (name : string, content : string) => {
    this.handler({
      which       : FloatPanelEnum.Confirmation,
      content     : content,
      name        : name,
      isVisible   : true
    });
  }

  HideLoaderModal = () => {
    this.handler({
      which: FloatPanelEnum.Loading,
      isVisible : false
    });
  }

  HideInformationModal = () => {
    this.handler({
      which       : FloatPanelEnum.Information,
      isVisible   : false
    });
  }

  HideConfirmationModal = () => {
    this.handler({
      which       : FloatPanelEnum.Confirmation,
      isVisible   : false
    });
  }
}