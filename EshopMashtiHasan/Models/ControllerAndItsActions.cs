namespace EshopMashtiHasan.Models
{
    
        public class ControllerAndItsActions
        {
            public string Controller { get; }
            public List<string> Actions { get; }

            public ControllerAndItsActions(string controller, List<string> actions) => (Controller, Actions) = (controller, actions);
        }
    
}
