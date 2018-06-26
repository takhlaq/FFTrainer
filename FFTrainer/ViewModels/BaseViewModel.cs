using FFTrainer.Models;

namespace FFTrainer.ViewModels
{
    public class BaseViewModel
    {
        public static BaseModel model;
        protected Mediator mediator;

        public BaseViewModel(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
