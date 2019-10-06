using System;

namespace Model.ViewModels.ComputingViewModels
{
    public class ComputingViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string Expression { get; set; }
        public double Outcome { get; set; }
    }
}
