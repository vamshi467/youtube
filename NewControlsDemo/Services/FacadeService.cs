using System;
using Prism.Services;

namespace NewControlsDemo.Services
{
    public class FacadeService
    {
        public IPageDialogService dialogService;
         
        public FacadeService(IPageDialogService dialogService)
        {
            this.dialogService = dialogService;
        }
    }
}
